using WebParser.Data;

namespace WebParser.Core.ilcats.ExstensionMethods
{
    static class SaveChangesErrorHandling
    {
        public static void SaveChangesWithCheck(this ilcatsParserDbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.InnerException);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
