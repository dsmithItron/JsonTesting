namespace JsonTesting
{
    internal class Program
    {
        public static int selectHistCount = 0;
        static void Main(string[] args)
        {
            int Count = 0;
            Console.WriteLine("Start Testing \n");
            
            ApplicationHistory.LoadHistory();
            ApplicationHistory.WriteHistory();
            ApplicationHistory.LoadHistory();
            //TestJsonSelectHist();
            ApplicationHistory.WriteHistory();
            ApplicationHistory.selectLeft = new();
            ApplicationHistory.selectMiddle = new();
            ApplicationHistory.selectRight = new();
            //TestJsonSelectHist();
            ApplicationHistory.LoadHistory();
            //TestJsonSelectHist();


            ApplicationSettings.LoadSettings();
            testJsonSettings();
            ApplicationSettings.LoadSettings();
            ApplicationSettings.WriteSettings();


            testJsonSettings();
        }




        public static void TestJsonSelectHist()
        {
            selectHistCount++;
            Console.WriteLine("\n----------------");
            Console.WriteLine($"-----Test Select Hist {selectHistCount}-----");
            Console.WriteLine("----------------\n");
            Console.WriteLine("\n----ApplicationHistory Select Left Begin----");
            foreach (string selectString in ApplicationHistory.selectLeft)
            {
                Console.WriteLine(selectString);
            }
            Console.WriteLine("----ApplicationHistory Select Left End----\n");

            Console.WriteLine("\n----ApplicationHistory Select Middle Begin----");
            foreach (string selectString in ApplicationHistory.selectMiddle)
            {
                Console.WriteLine(selectString);
            }
            Console.WriteLine("----ApplicationHistory Select Middle End----\n");

            Console.WriteLine("\n----ApplicationHistory Select Right Begin----");
            foreach (string selectString in ApplicationHistory.selectRight)
            {
                Console.WriteLine(selectString);
            }
            Console.WriteLine("----ApplicationHistory Select Right End----\n");
            Console.WriteLine("\n----------------");
            Console.WriteLine($"-----Test Select Hist {selectHistCount}-----");
            Console.WriteLine("----------------\n");
        }

        public static void testJsonSettings()
        {
            Console.WriteLine("\n----------------");
            Console.WriteLine($"-----Test Select Hist {selectHistCount}-----");
            Console.WriteLine("----------------\n");
            Console.WriteLine($"UserName: {ApplicationSettings.Username}");
            Console.WriteLine($"Password: {ApplicationSettings.Password}");
            Console.WriteLine($"MaxSqlSelection: {ApplicationSettings.MaxSqlSelection}");
        }
    }
    
}
