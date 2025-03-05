
using System.Text.Json;

namespace JsonTesting
{
    internal static class ApplicationSettings
    {
        public static string Username = "";
        public static string Password = "";
        public static int MaxSqlSelection = 1;

        public static void LoadSettings()
        {
            if (File.Exists("SqlFormSettings.json"))
            {
                string json = File.ReadAllText("SqlFormSettings.json");
                JsonDocument doc = JsonDocument.Parse(json);
                var settingsArray = doc.RootElement.GetProperty("Settings").EnumerateArray();
                foreach (var historyItem in settingsArray)
                {
                    Username = historyItem.GetProperty("Username").ToString();
                    Password = historyItem.GetProperty("Password").ToString();
                    MaxSqlSelection = Int32.Parse(historyItem.GetProperty("MaxSqlSelection").ToString());
                }
            }
        }
        public static bool CheckForSettings()
        {
            if (File.Exists("SqlFormSettings.json"))
            {
                return true;
            }
            return false;
        }
        public static bool WriteSettings()
        {
            var settings = new
            {
                Settings = new[]
                {
                    new
                    {
                        Username,
                        Password,
                        MaxSqlSelection
                    }
                }
            };
            
            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText("SqlFormSettings.json", json);
            if (CheckForSettings()) { return true; }
            return false;
        }
    }
}
