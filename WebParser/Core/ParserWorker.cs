using AngleSharp;
using AngleSharp.Html.Parser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParser.Core.ParserInterfaces;
using WebParser.Data;

namespace WebParser.Core
{
    class ParserWorker<T> where T : class
    {
        ilcatsParserDbContext db = new ilcatsParserDbContext();

        IParser<T> parser;
        IParserSettigs parserSettigs;
        HtmlLoader loader;
        bool isActive;
        #region Properties
        public IParser<T> Parser
        {
            get { return parser; }
            set { parser = value; }
        }
        public IParserSettigs Settigs
        {
            get { return parserSettigs; }
            set
            {
                parserSettigs = value;

            }
        }
        #endregion

        public event Action<object, T> OnNewData;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }
        public ParserWorker(IParser<T> parser, IParserSettigs parserSettigs) : this(parser)
        {
            this.parserSettigs = parserSettigs;
            loader = new HtmlLoader(parserSettigs);
        }

        public void Start()
        {
            isActive = true;
            Worker();
        }
        public async void Worker()
        {
            if (!isActive) return;

            var result = parser.Parse(loader.GetDocumentPage());

            OnNewData?.Invoke(this, result);

        }
    }
}
