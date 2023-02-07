using AngleSharp.Dom;
using AngleSharp.Html.Dom;


namespace WebParser.Core.ParserInterfaces
{
    interface IParser<T> where T : class
    {
        T Parse(IDocument document);
    }
}
