using AngleSharp;
using AngleSharp.Dom;
using WebParser.Core.ParserInterfaces;

namespace WebParser.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;
        public HtmlLoader(IParserSettigs settigs)
        {
            client = new HttpClient();
            url = $"{settigs.BaseUrl}{settigs.Prefix}#/";
        }
        public IDocument GetDocumentPage()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            return context.OpenAsync(url).Result;
        }

    }
}
