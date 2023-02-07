using AngleSharp.Common;
using AngleSharp.Dom;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Text.RegularExpressions;
using WebParser.Core.ilcats.ExstensionMethods;
using WebParser.Core.ParserInterfaces;
using WebParser.Data;
using WebParser.Models;

namespace WebParser.Core.ilcats.Parsers
{
    class ilcatsComplectationParser : IParser<List<Complectation>>, IParserList<Complectation>
    {
        ilcatsParserDbContext context;

        public List<Complectation> list { get; set; } = new List<Complectation>();

        public ilcatsComplectationParser(ilcatsParserDbContext _context) => context = _context;
        public List<Complectation> Parse(IDocument document)
        {
            var tablesItems = document.QuerySelectorAll("tr");

            var ElemsForDbColumnsName = tablesItems.Where(e => e.Children.
            Where(c => c.NodeName == "TH").Count() > 2).First().Children.Select(c => Regex.Replace(c.TextContent, "[^a-zA-Z0-9]", string.Empty));

            var itemsComplectation = tablesItems.Where(e => e.Children
            .Where(c => c.QuerySelector("td div.dateRange") != null).Count() > 0);

            var dic = Enumerable.Range(0, ElemsForDbColumnsName.Count()).
                ToDictionary(i => ElemsForDbColumnsName.ElementAt(i), i => itemsComplectation.Select(e => e.Children.ElementAt(i)));

            AddItemsToList(itemsComplectation);

            foreach (var item in dic)
            {
                if (item.Key == "Complectation" || item.Key == "Date") continue;

                string tableName = $"[dbo].[{nameof(context.Complectations)}]";
                string columnName = item.Key;
                string query = $@"IF NOT EXISTS (
                                  SELECT * 
                                  FROM   sys.columns 
                                  WHERE  object_id = OBJECT_ID(N'{tableName}') 
                                         AND name = '{columnName}')
                                BEGIN
                                    ALTER TABLE {tableName}
                                    ADD {columnName} varchar(255) NULL;
                                END;";

                context.Database.ExecuteSqlRaw(query);


                for (int i = 0; i < item.Value.Count(); i++)
                {
                    string settedValue = $"'{ item.Value.ElementAt(i).TextContent}'";
                    if (settedValue.Length==2) settedValue = null;
                    string whereValue = dic.First().Value.ElementAt(i).TextContent;
                    string queryUpdate = $"UPDATE {tableName} SET {columnName} = {settedValue} WHERE Name = '{whereValue}';";

                    context.Database.ExecuteSqlRaw(queryUpdate);
                }
            }

            context.SaveChangesWithCheck();
            return list;
        }
        public void AddItemsToList(IEnumerable<IElement> elements)
        {
            var modelOfComplectation = context.Models.FirstOrDefault(m => m.Code == elements.First().BaseUrl.SearchParams.Get("model"));

            if (modelOfComplectation != null)
                foreach (var item in elements)
                {
                    var dateTimeRange = item.QuerySelector(".dateRange").TextContent.Split("-", StringSplitOptions.TrimEntries).
                        Select<string, DateTime?>(e => e == "..." ? null : DateTime.ParseExact(e, "MM.yyyy", CultureInfo.InvariantCulture));
                    IElement complectationElement = item.QuerySelector("a");
                    list.Add(
                    new Complectation()
                    {
                        Model = modelOfComplectation,
                        Name = complectationElement.TextContent,
                        StartDate = (DateTime)dateTimeRange.ElementAt(0),
                        EndDate = dateTimeRange.ElementAt(1),
                        GroupPartUrl = complectationElement.GetAttribute("href")
                    });

                    if (context.Complectations.Count(c => c.Name.Equals(list[list.Count - 1].Name)) == 0)
                        context.Complectations.Add(list[list.Count - 1]);
                }

            context.SaveChangesWithCheck();
        }
    }
}
