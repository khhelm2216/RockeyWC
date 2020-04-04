using System.Collections.Generic;

namespace RockeyWC.FilterLibrary
{
    // Used for filter demonstrations - just for the messages
    public interface IFilterDiagnostics
    {
        IEnumerable<string> Messages { get; }

        void AddMessage(string message);
    }
}