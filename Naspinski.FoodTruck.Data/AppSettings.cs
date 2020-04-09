using System;
using System.Collections.Generic;

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
        public string CorsAddresses { get; set; }
    }

    public class ElmahSettings
    {
        public string ApiKey { get; set; }
        public Guid LogId { get; set; }
    }
}
