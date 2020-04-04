namespace RockeyWC.Models
{
    // Simple log info
    public partial class ActionLog
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string HttpMethod { get; set; }
        public string URL { get; set; }
        public System.DateTime ActionDate { get; set; }
    }
}
