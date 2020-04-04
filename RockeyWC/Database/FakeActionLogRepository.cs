using RockeyWC.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RockeyWC.Database
{
    // Provide a replacement for a datatabase
    public class FakeActionLogRepository : IActionLogRepository
    {
        // Local store of action logs
        private List<ActionLog> LogList;

        // Location of Action Log list 
        private string filePath = @"ActionLogs.json";

        // Fulfillment of the IActionLogRepository interface
        public IQueryable<ActionLog> LogListing => LogList.AsQueryable<ActionLog>();

        // Constructor to create the fake database each time this is run
        public FakeActionLogRepository()
        {
            // Make a new empty log list
            LogList = new List<ActionLog>();

            // Only open an Order file if it exists
            FileInfo actionLogFile = new FileInfo(filePath);
            if (actionLogFile.Exists)
            {
                // Read in any order from a file and convert it from Json to Order
                using (TextReader reader = File.OpenText(filePath))
                {
                    string JsonString = reader.ReadToEnd();
                    reader.Close();
                    LogList = JsonConvert.DeserializeObject<List<ActionLog>>(JsonString);
                }
            }
               }

        //Save a single log entry
        public void SaveLogAction(ActionLog actionLog)
        {
            // Save the action log
            actionLog.Id = LogList.Count + 1;
            LogList.Add(actionLog);
            SaveDatabase();
        }

        // Delete all log entries
        public void DeleteAllLogActions()
        {
            LogList.Clear();
            SaveDatabase();
        }

        // Delete single log entry
        public ActionLog DeleteLogAction(int logID)
        {
            ActionLog dbEntry = LogListing.FirstOrDefault(p => p.Id == logID);
            if (dbEntry != null)
            {
                LogList.Remove(dbEntry);
                SaveDatabase();
            }
            return dbEntry;
        }

        // Save the database into a file
        private void SaveDatabase()
        {
            // Make a serialized string of the order list
            string jsonMain = JsonConvert.SerializeObject(LogList, Formatting.Indented);

            // Save the order in a file (auto-overwrite any existing file)
            using (TextWriter writer = File.CreateText(filePath))
            {
                writer.Write(jsonMain);
                writer.Close();
            }
        }
    }
}