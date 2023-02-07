using AngleSharp.Dom;


namespace WebParser.Core.ParserInterfaces
{
    internal interface IParserList<T> where T : class
    {
        public List<T> list { get; set; }
        void AddItemsToList(IEnumerable<IElement> elements);
    }
}
