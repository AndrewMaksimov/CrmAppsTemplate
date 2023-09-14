namespace CrmAppsTemplate.Options
{
    public class CrmConnectionOptions
    {
        public const string CrmConnection = "CrmConnection";

        public string CrmUri { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}