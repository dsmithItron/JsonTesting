namespace JsonTesting
{
    internal class Program
    {
        public static int selectHistCount = 0;
        public static List<string> tableNames = new() {("table1"),("table2")};
        public string currentProfile = "base";
        static void Main(string[] args)
        {
            int Count = 0;
            ApplicationSettings.LoadSettings();
            /*
            ApplicationSettings.ProfileName = "Base";
            ApplicationSettings.history.tableConditions["table1"]["Insert"].Add("table1Insert");
            ApplicationSettings.history.tableConditions["table1"]["Insert"].Add("table1Insert1");
            ApplicationSettings.history.tableConditions["table1"]["Insert"].Add("table1Insert2");
            ApplicationSettings.history.tableConditions["table1"]["Update"].Add("table1Update");
            ApplicationSettings.history.tableConditions["table1"]["Update"].Add("table1Update3");
            ApplicationSettings.history.tableConditions["table1"]["Update"].Add("table1Update2");
            ApplicationSettings.history.tableConditions["table1"]["Select"].Add("table1Select");
            ApplicationSettings.history.tableConditions["table1"]["Select"].Add("table1Select2");
            ApplicationSettings.history.tableConditions["table1"]["Select"].Add("table1Select3");
            ApplicationSettings.history.tableConditions["table2"]["Insert"].Add("table1Insert");
            ApplicationSettings.history.tableConditions["table2"]["Insert"].Add("table1Insert1");
            ApplicationSettings.history.tableConditions["table2"]["Insert"].Add("table1Insert2");
            ApplicationSettings.history.tableConditions["table2"]["Update"].Add("table1Update");
            ApplicationSettings.history.tableConditions["table2"]["Update"].Add("table1Update3");
            ApplicationSettings.history.tableConditions["table2"]["Update"].Add("table1Update2");
            ApplicationSettings.history.tableConditions["table2"]["Select"].Add("table1Select");
            ApplicationSettings.history.tableConditions["table1"]["Select"].Add("table1Select2");
            ApplicationSettings.history.tableConditions["table2"]["Select"].Add("table1Select3");
            */

            ApplicationSettings.WriteSettings();
            Console.WriteLine("Success");
        }




        public static void TestJsonSelectHist()
        {
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
