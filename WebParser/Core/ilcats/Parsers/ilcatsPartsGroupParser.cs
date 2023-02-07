using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Globalization;
using WebParser.Core.ilcats.ExstensionMethods;
using WebParser.Core.ParserInterfaces;
using WebParser.Data;
using WebParser.Models;

namespace WebParser.Core.ilcats.Parsers
{
    internal class ilcatsPartsGroupParser : IParser<List<PartsGroup>>, IParserList<PartsGroup>
    {
        ilcatsParserDbContext context;
        public ilcatsPartsGroupParser(ilcatsParserDbContext _context) => context = _context;
        public List<PartsGroup> list { get; set; } = new List<PartsGroup>();

        public List<PartsGroup> Parse(IDocument document)
        {

            var items = document.QuerySelectorAll(".List .name a");

            AddItemsToList(items);

            return list;
        }

        public void AddItemsToList(IEnumerable<IElement> elements)
        {
            foreach (var itemParts in elements)
            {
                var modelOfComplectation = context.Complectations.FirstOrDefault(m => m.Name == elements.First().BaseUrl.SearchParams.Get("modification"));
                if (modelOfComplectation != null)
                {
                    string href = itemParts.GetAttribute("href");

                    list.Add(new PartsGroup()
                    {
                        Name = itemParts.TextContent,
                        ComplectationId = modelOfComplectation.Id,
                        Code = href.ExtractrtHrefParam("group"),
                        PartsSubGroupUrl = href
                    });
                    if (context.PartsGroups.Count(c => c.Name.Equals(list[list.Count - 1].Name)) == 0 &&
                        context.PartsGroups.Count(c => c.Code.Equals(list[list.Count - 1].Code)) == 0)
                        context.PartsGroups.Add(list[list.Count - 1]);
                    context.SaveChangesWithCheck();
                }
            }
        }
    }
}
