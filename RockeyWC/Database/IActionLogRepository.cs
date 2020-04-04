using RockeyWC.Models;
using System.Linq;

namespace RockeyWC.Database
{
    // Just the contents of the Action Log Repository
    public interface IActionLogRepository
    {
        IQueryable<ActionLog> LogListing { get; }

        void SaveLogAction(ActionLog logAction);

        void DeleteAllLogActions();

        ActionLog DeleteLogAction(int logID);
    }
}
