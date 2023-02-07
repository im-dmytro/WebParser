using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebParser.Core.ilcats.ExstensionMethods;
using WebParser.Core.ParserInterfaces;
using WebParser.Data;
using WebParser.Models;

namespace WebParser.Core.ilcats.Parsers
{
    internal class ilcatsPartsSubGroupParser : IParser<List<PartsSubGroup>>, IParserList<PartsSubGroup>
    {
        ilcatsParserDbContext context;
        public ilcatsPartsSubGroupParser(ilcatsParserDbContext _context) => context = _context;
        public List<PartsSubGroup> list { get; set; } = new List<PartsSubGroup>();

        public List<PartsSubGroup> Parse(IDocument document)
        {

            var items = document.QuerySelectorAll(".name a");

            AddItemsToList(items);

            return list;
        }

        public void AddItemsToList(IEnumerable<IElement> elements)
        {
            foreach (var itemParts in elements)
            {

                var partGroup = context.PartsGroups.FirstOrDefault(p => p.Code == Int32.Parse(elements.First().BaseUrl.SearchParams.Get("group")));
                if (partGroup != null)
                {
                    string href = itemParts.GetAttribute("href");
                    list.Add(new PartsSubGroup()
                    {
                        Name = itemParts.TextContent,
                        PartsGroupId = partGroup.Id,
                        Code = href.ExtractrtHrefParam("subgroup"),
                        PartsUrl = href
                    });
                    if (context.PartsSubGroups.Count(c => c.Name.Equals(list[list.Count - 1].Name)) == 0 &&
                        context.PartsSubGroups.Count(c => c.Code.Equals(list[list.Count - 1].Code)) == 0)
                        context.PartsSubGroups.Add(list[list.Count - 1]);
                }
            }
            context.SaveChangesWithCheck();
        }


    }
}
