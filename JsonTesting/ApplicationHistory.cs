using System.Text.Json;
using System.Text.Json.Nodes;

namespace JsonTesting
{
    internal static class ApplicationHistory
    {
        public static List<string> selectLeft = new();
        public static List<string> selectMiddle = new();
        public static List<string> selectRight = new();

        public static bool CheckForHistory()
        {
            if (File.Exists("SqlFormHistory.json"))
            {
                return true;
            }
            return false;
        }
        public static void LoadHistory()
        {
            if (File.Exists("SqlFormHistory.json"))
            {
                string json = File.ReadAllText("SqlFormHistory.json");
                JsonDocument doc = JsonDocument.Parse(json);
                var historyArray = doc.RootElement.GetProperty("History").EnumerateArray();
                foreach (var historyItem in historyArray)
                {
                    var selectHistoryArray = historyItem.GetProperty("SelectHistory").EnumerateArray();
                    var insertHistoryArray = historyItem.GetProperty("InsertHistory").EnumerateArray();
                    var deleteHistoryArray = historyItem.GetProperty("DeleteHistory").EnumerateArray();
                    var updateHistoryArray = historyItem.GetProperty("UpdateHistory").EnumerateArray();
                    foreach (var selectHistoryItem in selectHistoryArray)
                    {
                        var selectLeftJson = selectHistoryItem.GetProperty("selectLeft").EnumerateArray();
                        var selectMiddleJson = selectHistoryItem.GetProperty("selectMiddle").EnumerateArray();
                        var selectRightJson = selectHistoryItem.GetProperty("selectRight").EnumerateArray();
                        foreach(var left in selectLeftJson)
                        {
                            if (!selectLeft.Contains(left.ToString()))
                            {
                                selectLeft.Add(left.ToString());
                            }
                        }
                        foreach(var middle in selectMiddleJson)
                        {
                            if (!selectMiddle.Contains(middle.ToString()))
                            {
                                selectMiddle.Add(middle.ToString());
                            }
                        }
                        foreach (var right in selectRightJson)
                        {
                            if (!selectRight.Contains(right.ToString()))
                            {
                                selectRight.Add(right.ToString());
                            }
                        }
                    }
                }
            }
        }
        public static bool WriteHistory()
        {
            var history = new
            {
                History = new[]
                {
                    new
                    {
                        SelectHistory = new[]
                        {
                            new
                            {
                                selectLeft,
                                selectMiddle,
                                selectRight
                            }
                        },
                        InsertHistory = new[]
                        {
                            new
                            {

                            }
                        },
                        DeleteHistory = new[]
                        {
                            new
                            {

                            }
                        },
                        UpdateHistory = new[]
                        {
                            new
                            {

                            }
                        }
                    }
                }
            };


            string json = JsonSerializer.Serialize(history, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("SqlFormHistory.json", json);
            if (CheckForHistory()) { return true; }
            return false;
        }
    }
}
