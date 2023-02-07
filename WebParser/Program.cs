
using AngleSharp.Browser;
using Microsoft.IdentityModel.Tokens;
using WebParser.Core;
using WebParser.Core.ilcats;
using WebParser.Core.ilcats.Parsers;
using WebParser.Data;
using WebParser.Models;

namespace WebParser.Program
{
    class Program
    {
        static ParserWorker<List<Model>> parserModel;

        public static void Main(string[] args)
        {
            parserModel = new ParserWorker<List<Model>>(new ilcatsModelParser(new ilcatsParserDbContext()), new ilcatsSettings());
            parserModel.OnNewData += Parser_OnNewData;
            parserModel.Start();
        }
        private static void Parser_OnNewData(object arg1, List<Part> arg2)
        {
            foreach (var item in arg2)
            {
                Console.WriteLine(item.Tree);
            }

            parserModel.Start();
        }
        private static void Parser_OnNewData(object arg1, List<PartsSubGroup> arg2)
        {
            foreach (var item in arg2)
            {
                Console.WriteLine(item.Name);
            }
            string? choosedPartsSubGroupName;
        A1:
            Console.WriteLine("Choose what parts sub group by name to parse:");
            choosedPartsSubGroupName = Console.ReadLine();
            var foundPartsSubGroup = arg2.FirstOrDefault(m => m.Name == choosedPartsSubGroupName);

            if (choosedPartsSubGroupName.IsNullOrEmpty() || foundPartsSubGroup == null)
            {
                Console.WriteLine("You entred null value or not existed parse sub group name.");
                goto A1;
            }
            Console.WriteLine(new string('-', 30));

            ParserWorker<List<Part>> parserParts;
            parserParts = new ParserWorker<List<Part>>
                (new ilcatsPartParser(new ilcatsParserDbContext()), new ilcatsSettings() { Prefix = foundPartsSubGroup.PartsUrl });
            parserParts.OnNewData += Parser_OnNewData;
            parserParts.Start();


        }
        private static void Parser_OnNewData(object arg1, List<PartsGroup> arg2)
        {
            foreach (var item in arg2)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine(new string('-', 30));

            string? choosedPartsGroupName;
        A1:
            Console.WriteLine("Choose what parts group by name to parse:");
            choosedPartsGroupName = Console.ReadLine();
            var foundPartsGroup = arg2.FirstOrDefault(m => m.Name == choosedPartsGroupName);

            if (choosedPartsGroupName.IsNullOrEmpty() || foundPartsGroup == null)
            {
                Console.WriteLine("You entred null value or not existed complectation name.");
                goto A1;
            }
            Console.WriteLine(new string('-', 30));

            ParserWorker<List<PartsSubGroup>> parserSubGroups;
            parserSubGroups = new ParserWorker<List<PartsSubGroup>>
                (new ilcatsPartsSubGroupParser(new ilcatsParserDbContext()), new ilcatsSettings() { Prefix = foundPartsGroup.PartsSubGroupUrl });
            parserSubGroups.OnNewData += Parser_OnNewData;
            parserSubGroups.Start();
        }
        private static void Parser_OnNewData(object arg1, List<Complectation> arg2)
        {
            foreach (var item in arg2)
            {
                Console.WriteLine(item.Name);
            }
            string? choosedComplecationName;
        A1:
            Console.WriteLine("Choose what complectation by name to parse:");
            choosedComplecationName = Console.ReadLine();
            var foundComplectation = arg2.FirstOrDefault(m => m.Name == choosedComplecationName);

            if (choosedComplecationName.IsNullOrEmpty() || foundComplectation == null)
            {
                Console.WriteLine("You entred null value or not existed parse group name.");
                goto A1;
            }
            Console.WriteLine(new string('-', 30));

            ParserWorker<List<PartsGroup>> parserPartsGroups;
            parserPartsGroups = new ParserWorker<List<PartsGroup>>
                (new ilcatsPartsGroupParser(new ilcatsParserDbContext()), new ilcatsSettings() { Prefix = foundComplectation.GroupPartUrl });
            parserPartsGroups.OnNewData += Parser_OnNewData;
            parserPartsGroups.Start();
        }
        private static void Parser_OnNewData(object arg1, List<Model> arg2)
        {
            foreach (var item in arg2)
            {
                Console.WriteLine(item);
            }
            string choosedModelCode = "";

        A1:
            Console.WriteLine("Choose code to parse complectations of that model:");
            choosedModelCode = Console.ReadLine();
            var foundModel = arg2.FirstOrDefault(m => m.Code == choosedModelCode);

            if (choosedModelCode.IsNullOrEmpty() || foundModel == null)
            {
                Console.WriteLine("You entred null value or not existed code of mode.");
                goto A1;
            }
            Console.WriteLine(new string('-', 30));

            ParserWorker<List<Complectation>> parserComplectation;
            parserComplectation = new ParserWorker<List<Complectation>>
                (new ilcatsComplectationParser(new ilcatsParserDbContext()), new ilcatsSettings() { Prefix = foundModel.ComplecationUrl });
            parserComplectation.OnNewData += Parser_OnNewData;
            parserComplectation.Start();
        }
    }
}