using AngleSharp.Dom;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebParser.Core.ilcats.ExstensionMethods;
using WebParser.Core.ParserInterfaces;
using WebParser.Data;
using WebParser.Models;
namespace WebParser.Core.ilcats.Parsers
{
    class ilcatsModelParser : IParser<List<Model>>, IParserList<Model>
    {
        ilcatsParserDbContext context;
        public ilcatsModelParser(ilcatsParserDbContext _context) => context = _context;

        public List<Model> list { get; set; } = new List<Model>();

        public List<Model> Parse(IDocument document)
        {

            var items = document.QuerySelectorAll(".List").Where(e => e.Children
            .Where(c => c.ClassName == "Header").Count() > 0);

            AddItemsToList(items);

            return list;
        }

        public void AddItemsToList(IEnumerable<IElement> elements)
        {
            foreach (var itemParts in elements)
            {
                string nameItemPart = itemParts.QuerySelector(".name").TextContent;

                foreach (var item in itemParts.QuerySelectorAll(".List ").Children(".List"))
                {
                    var dateTimeRange = item.QuerySelector(".dateRange").TextContent.Split('-', StringSplitOptions.TrimEntries).
                        Select<string, DateTime?>(e => e == "..." ? null : DateTime.ParseExact(e, "MM.yyyy", CultureInfo.InvariantCulture));

                    var modelCodeElem = item.QuerySelector(".id a");
                    list.Add(
                           new Model()
                           {
                               Name = nameItemPart,
                               StartDate = (DateTime)dateTimeRange.ElementAt(0),
                               EndDate = dateTimeRange.ElementAt(1),
                               Assembly = item.QuerySelector(".modelCode").TextContent,
                               Code = modelCodeElem.TextContent,
                               ComplecationUrl = modelCodeElem.GetAttribute("href")
                           });
                    if (context.Models.Count(c => c.Code.Equals(list[list.Count - 1].Code)) == 0)
                        context.Models.Add(list[list.Count - 1]);

                }
            }
            context.SaveChangesWithCheck();
        }
    }
}
