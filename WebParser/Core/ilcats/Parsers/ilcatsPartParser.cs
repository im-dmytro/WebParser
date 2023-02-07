using AngleSharp.Common;
using AngleSharp.Dom;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using WebParser.Core.ilcats.ExstensionMethods;
using WebParser.Core.ParserInterfaces;
using WebParser.Data;
using WebParser.Models;


namespace WebParser.Core.ilcats.Parsers
{
    internal class ilcatsPartParser : IParser<List<Part>>
    {
        ilcatsParserDbContext context;
        public ilcatsPartParser(ilcatsParserDbContext _context) => context = _context;

        public List<Part> list { get; set; } = new List<Part>();

        public List<Part> Parse(IDocument document)
        {
            var allTROfTable = document.QuerySelectorAll("tr");

            var groupedTH = allTROfTable.
                Where(c => c.Children.Where(ch => ch.NodeName == "TH").Count() == 1).
                GroupBy(e => e.GetAttribute("data-id"));

            var groupedTD = allTROfTable.
                Where(c => c.Children.Where(ch => ch.NodeName == "TD").Count() == 4).
                GroupBy(e => e.GetAttribute("data-id"));



            foreach (var group in groupedTD)
            {

                var groupKey = group.Key;
                foreach (var groupedItem in group)
                {

                    int FindSubGroup = Int32.TryParse(allTROfTable.First().BaseUrl.SearchParams.Get("subgroup"), out int subgroup) ? subgroup : -1;
                    var FoundSubGroup = context.PartsSubGroups.FirstOrDefault(m => m.Code == FindSubGroup);
                    if (FoundSubGroup != null)
                    {
                        var dateTimeRange = groupedItem.QuerySelector(".dateRange").TextContent.Split("-", StringSplitOptions.TrimEntries).
                      Select<string, DateTime?>(e => e == "..." ? null : DateTime.ParseExact(e, "MM.yyyy", CultureInfo.InvariantCulture));
                        var ReplacmentCodeElement = groupedItem.QuerySelector(".replaceNumber a");

                        string imageUrl = document.QuerySelector(".ImageArea .Image img").GetAttribute("src");
                        string[] imageNameParams = new string[] { "modification", "group", "subgroup" };
                        string imageName = String.Join("_", Enumerable.Range(0, 2).Select(i => allTROfTable.First().BaseUrl.SearchParams.Get(imageNameParams[i])));
                        ImageDownloader(imageUrl, imageName);

                        var part = new Part()
                        {
                            PartsSubGroup = FoundSubGroup,
                            Tree = groupedTH.First(g => g.Key == groupKey).First().QuerySelector("th").TextContent.Replace(groupKey, "").Trim(),
                            TreeCode = groupKey,
                            Code = groupedItem.QuerySelector(".number").TextContent,
                            Count = Int32.TryParse(groupedItem.QuerySelector(".count").TextContent, out int count) ? count : -1,
                            StartDate = (DateTime)dateTimeRange.ElementAt(0),
                            EndDate = dateTimeRange.ElementAt(1),
                            Info = groupedItem.QuerySelector(".usage").TextContent,
                            ReplacementCode = ReplacmentCodeElement == null ? null : ReplacmentCodeElement.TextContent,
                            ImageName = imageName
                        };
                        list.Add(part);

                        if (context.Parts.Count(c => c.Code.Equals(list[list.Count - 1].Code)) == 0)
                            context.Parts.Add(list[list.Count - 1]);
                    }

                }
            }

            context.SaveChangesWithCheck();
            return list;
        }
        void ImageDownloader(string imageUrl, string fileName)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile($"https:{imageUrl}", $@"C:\Users\Админ\source\repos\WebParser\WebParser\images\{fileName}.png");
            }
        }
    }
}
