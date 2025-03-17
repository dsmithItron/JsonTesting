using System;
using System.Text.Json;

namespace JsonTesting
{
    internal class ApplicationHistory
    {
        public SortedDictionary<string, SortedDictionary<string, List<string>>> tableConditions;

        public ApplicationHistory()
        {
            tableConditions = new();
            foreach (string tableName in Program.tableNames)
            {
                tableConditions[tableName] = new();
                tableConditions[tableName]["Select"] = new();
                tableConditions[tableName]["Update"] = new();
                tableConditions[tableName]["Insert"] = new();
            }
        }
        /// <summary>
        /// Summary: <br></br>Checks to see if SqlFormHistory.json exists in current directory.
        /// <br></br><br></br>
        /// <remark>Remark: If file is moved to different location this needs to be updated</remark>
        /// </summary>
        /// <returns></returns>
        public static bool CheckForHistory()
        {
            if (File.Exists("SqlFormHistory.json"))
            {
                return true;
            }
            return false;
        }

        public bool AddQueryToHistory(string query, string table, string type)
        {
            tableConditions[table][type].Add(query);
            return true;
        }
    }
}
