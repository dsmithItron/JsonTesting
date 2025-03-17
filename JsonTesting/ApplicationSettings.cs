
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace JsonTesting
{
    internal static class ApplicationSettings
    {
        public static List<Profile> Profiles = new();

        public class Profile
        {
            public string ProfileName { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public bool HideToolTips { get; set; }
            public int MaxSqlSelection { get; set; }
            public ApplicationHistory history;

            public Profile()
            {
                ProfileName = "";
                Username = "";
                Password = "";
            }
            public Profile(string profileName, string userName, string password, bool hideToolTips, int maxSqlSelection, ApplicationHistory history)
            {
                ProfileName = profileName;
                Username= userName;
                Password = password;
                HideToolTips = hideToolTips;
                MaxSqlSelection = maxSqlSelection;
                this.history = history;
            }
        }

        public static string ProfileName = "";
        public static string Username = "";
        public static string Password = "";
        public static bool HideToolTips = false;
        public static int MaxSqlSelection = 1;
        public static ApplicationHistory history = new();

        /// <summary>
        /// Summary: <br></br>Fill Setting data using SqlFormSettings.json
        /// <br></br><br></br>
        /// <remarks>Remark: Needs to be changed if more fields are added</remarks>
        /// </summary>
        public static void LoadSettings()
        {
            if (File.Exists("SqlFormSettings.json"))
            {
                try
                {
                    string json = File.ReadAllText("SqlFormSettings.json");
                    JsonDocument doc = JsonDocument.Parse(json);
                    var profilesArray = doc.RootElement.GetProperty("Profiles").EnumerateArray();
                    Profiles.Clear();
                    foreach (JsonElement profile in profilesArray)
                    {
                        Profiles.Add(new Profile
                        {
                            ProfileName = profile.GetProperty("ProfileName").ToString(),
                            Username = profile.GetProperty("Username").ToString(),
                            Password = profile.GetProperty("Password").ToString(),
                            HideToolTips = bool.Parse(profile.GetProperty("HideToolTips").ToString()),
                            MaxSqlSelection = int.Parse(profile.GetProperty("MaxSqlSelection").ToString()),
                            history = ParseHistory(profile.GetProperty("History"))
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in Loading Settings: {ex}");
                }
            }
        }
        /// <summary>
        /// Summary: <br></br>Checks if SqlFormSettings.json exists
        /// <br></br><br></br>
        /// <remarks>Remark: <br></br>Needs to be updated if location of SqlFormSettings.json changes</remarks>
        /// </summary>
        /// <returns>True if SqlFormSettings.json exists</returns>
        public static bool CheckForSettings()
        {
            if (File.Exists("SqlFormSettings.json"))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Summary: <br></br>Writes to SqlFormSettings.json
        /// <br></br><br></br>
        /// <remarks>Remark: <br></br>Needs to be updated if wanting to add or update settings fields</remarks>
        /// </summary>
        /// <returns>True if SqlFormSettings.json exists after runtime</returns>
        public static bool WriteSettings()
        {
            // Changing this means prior settings file needs to be deleted
            var settings = new
            {
                Profiles = new List<object>
                {
                    new
                    {
                        ProfileName,
                        Username,
                        Password,
                        HideToolTips,
                        MaxSqlSelection,
                        History = history.tableConditions
                    }
                }
            };

            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("SqlFormSettings.json", json);
            return CheckForSettings();
        }

        public static ApplicationHistory ParseHistory(JsonElement jsonHistory)
        {
            ApplicationHistory parse = new ApplicationHistory();

            foreach (var table in Program.tableNames)
            {
                var jsonTable = jsonHistory.GetProperty(table);

                foreach(var query in jsonTable.GetProperty("Insert").EnumerateArray())
                {
                    parse.tableConditions[table]["Insert"].Add(query.GetString());
                }
                foreach (var query in jsonTable.GetProperty("Update").EnumerateArray())
                {
                    parse.tableConditions[table]["Update"].Add(query.GetString());
                }
                foreach (var query in jsonTable.GetProperty("Select").EnumerateArray())
                {
                    parse.tableConditions[table]["Select"].Add(query.GetString());
                }
            }

            return parse;
        }

        public static void AddCurrentProfile()
        {
            Profile add = new Profile(ProfileName,Username,Password,HideToolTips,MaxSqlSelection,history);
            Profiles.Add(add);
        }
    }
}
