using System;

namespace Naspinski.FoodTruck.Data
{
    public class ConnectionStrings
    {
        public string FoodTruckDb { get; set; }
    }

    public class AzureSettings
    {
        public string StorageAccount { get; set; }
        public string StorageAccountPassword { get; set; }
        public string SendgridApiKey { get; set; }
        public string AdminSiteBaseUrl { get; set; }
        public string SiteBaseUrl { get; set; }
        public string HomeUrl { get; set; }
        public string CorsAddresses { get; set; }
    }

    public class SquareSettings
    {
        public bool UseProductionApi { get; set; }
        public string ProductionApplicationId { get; set; }
        public string ProductionAccessToken { get; set; }
        public string ProductionLocationId { get; set; }
        public string SandboxApplicationId { get; set; }
        public string SandboxAccessToken { get; set; }
        public string SandboxLocationId { get; set; }
    }

    public class ElmahSettings
    {
        public string ApiKey { get; set; }
        public Guid LogId { get; set; }
    }
}
