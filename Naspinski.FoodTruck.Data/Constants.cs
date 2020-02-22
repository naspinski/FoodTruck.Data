using System.Collections.Generic;

namespace Naspinski.FoodTruck.Data
{
    public static class Constants
    {
        public static class SettingName
        {
            public const string IsOrderingOn = "IsOrderingOn";
            public const string LogoImageUrl = "LogoImageUrl";
            public const string FaviconImageUrl = "FaviconImageUrl";
            public const string AppleTouchIconImageUrl = "AppleTouchIconImageUrl";
            public const string Title = "Title";
            public const string SubTitle = "SubTitle";
            public const string Description = "Description";
            public const string Tagline = "Tagline";
            public const string OrderConfirmationEmailSubject = "OrderConfirmationEmailSubject";
            public const string ContactPreHeader = "ContactPreHeader";
            public const string ContactHeader = "ContactHeader";
            public const string ContactPostHeader = "ContactPostHeader";
            public const string Facebook = "Facebook";
            public const string Twitter = "Twitter";
            public const string Instagram = "Instagram";
            public const string LinkedIn = "LinkedIn";
            public const string Pinterest = "Pinterest";
            public const string ContactEmail = "ContactEmail";
            public const string ContactPhone = "ContactPhone";
            public const string Keywords = "Keywords";
            public const string Author = "Author";
            public const string GoogleMapsApiKey = "GoogleMapsApiKey";
            public const string GoogleMapsDeveloperApiKey = "GoogleMapsDeveloperApiKey";
            public const string DaysInFutureToDisplay = "DaysInFutureToDisplay";
            public const string TwilioSid = "TwilioSid";
            public const string TwilioAuthToken = "TwilioAuthToken";
            public const string TwilioPhoneNumber = "TwilioPhoneNumber";
            public const string TimeZoneOffsetFromUtcInHours = "TimeZoneOffsetFromUtcInHours";
            public const string IcalUrl = "IcalUrl";
            public const string OrderNotificationEmails = "OrderNotificationEmails";
            public const string OrderNotificationPhoneNumbers = "OrderNotificationPhoneNumbers";
            public const string SquareOnlineTaxId = "SquareOnlineTaxId";
            public const string AutoNotificationDelayInMinutes = "AutoNotificationDelayInMinutes";
            public const string BrickAndMortarMode = "BrickAndMortarMode";
            public const string Location = "Location";
            public const string IsApplyOn = "IsApplyOn";
            public const string ApplyText = "ApplyText";
            public const string GrubHubLink = "GrubHubLink";
            public const string DoorDashLink = "DoorDashLink";
            public const string PostmatesLink = "PostmatesLink";
            public const string OrderServiceText = "OrderServiceText";

            public const string SundayOpen = "SundayOpen";
            public const string SundayClose = "SundayClose";
            public const string MondayOpen = "MondayOpen";
            public const string MondayClose = "MondayClose";
            public const string TuesdayOpen = "TuesdayOpen";
            public const string TuesdayClose = "TuesdayClose";
            public const string WednesdayOpen = "WednesdayOpen";
            public const string WednesdayClose = "WednesdayClose";
            public const string ThursdayOpen = "ThursdayOpen";
            public const string ThursdayClose = "ThursdayClose";
            public const string FridayOpen = "FridayOpen";
            public const string FridayClose = "FridayClose";
            public const string SaturdayOpen = "SaturdayOpen";
            public const string SaturdayClose = "SaturdayClose";
        }

        public static class DataType
        {
            public const string Integer = "int";
            public const string Decimal = "decimal";
            public const string DropdownId = "dropdownId";
            public const string DropdownString = "dropdownString";
            public const string String = "string";
            public const string LongString = "longString";
            public const string Boolean = "bool";
            public const string DateTime = "dateTime";
            public const string Date = "date";
            public const string Time = "time";
        }

        public class OrderType
        {
            public const string FoodTruck = "FoodTruck";
            public const string Delivery = "Delivery";
            public const string Carryout = "Carryout";
        }

        public static class SettingCategory
        {
            public const string Images = "Images";
            public const string General = "General";
            public const string Contact = "Email";
            public const string Social = "Social";
            public const string Meta = "Meta";
            public const string Calendar = "Calendar";
            public const string ExternalApps = "External App Settings";
            public const string OrderNotification = "Order Notification";
            public const string HoursOfOperation = "Hours of Operation";
        }

        public static Dictionary<string, string> DataTypes
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    { DataType.Integer,  "^\\d+$" },
                    { DataType.Decimal, "^[0-9]+(\\.[0-9]{1,2})?$" },
                    { DataType.DropdownId,  "^\\d+$" },
                    { DataType.DropdownString,  string.Empty },
                    { DataType.String, string.Empty },
                    { DataType.Boolean, "^(?i:true|false)$" }
                };
            }
        }
    }
}
