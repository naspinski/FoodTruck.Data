using Naspinski.FoodTruck.Data.Models.System;
using System.Collections.Generic;
using static Naspinski.FoodTruck.Data.Constants;

namespace Naspinski.FoodTruck.Data
{
    public static class Seeds
    {
        public static IEnumerable<Setting> Settings
        {
            get
            {
                return new List<Setting>()
                {
                    new Setting() { Name = SettingName.LogoImageUrl, DataType = Constants.DataType.DropdownString, Category = SettingCategory.Images, Value = string.Empty },
                    new Setting() { Name = SettingName.BannerImageUrl, DataType = Constants.DataType.DropdownString, Category = SettingCategory.Images, Value = string.Empty },
                    new Setting() { Name = SettingName.FaviconImageUrl, DataType = Constants.DataType.DropdownString, Category = SettingCategory.Images, Value = string.Empty },
                    new Setting() { Name = SettingName.AppleTouchIconImageUrl, DataType = Constants.DataType.DropdownString, Category = SettingCategory.Images, Value = string.Empty },

                    new Setting() { Name = SettingName.BrickAndMortarMode, DataType = Constants.DataType.Boolean, Category = SettingCategory.General, Value = false.ToString() },
                    new Setting() { Name = SettingName.IsOrderingOn, DataType = Constants.DataType.Boolean, Category = SettingCategory.General, IsHidden = true, Value = false.ToString() },
                    new Setting() { Name = SettingName.Title, DataType = Constants.DataType.String, Category = SettingCategory.General, Value = "Food Truck" },
                    new Setting() { Name = SettingName.SubTitle, DataType = Constants.DataType.String, Category = SettingCategory.General, Value = "subtitle" },
                    new Setting() { Name = SettingName.Description, DataType = Constants.DataType.LongString, Category = SettingCategory.General, Value = "description" },
                    new Setting() { Name = SettingName.Tagline, DataType = Constants.DataType.String, Category = SettingCategory.General, Value = "tagline" },
                    new Setting() { Name = SettingName.TimeZoneOffsetFromUtcInHours, DataType = Constants.DataType.Integer, Category = SettingCategory.General, Value = (-6).ToString() },
                    new Setting() { Name = SettingName.Location, DataType = Constants.DataType.DropdownId, Category = SettingCategory.General, Value = string.Empty },

                    new Setting() { Name = SettingName.OrderConfirmationEmailSubject, DataType = Constants.DataType.String, Category = SettingCategory.Contact, Value = "Thank you" },
                    new Setting() { Name = SettingName.ContactPreHeader, DataType = Constants.DataType.String, Category = SettingCategory.Contact, Value = "contact pre header" },
                    new Setting() { Name = SettingName.ContactHeader, DataType = Constants.DataType.String, Category = SettingCategory.Contact, Value = "contact header" },
                    new Setting() { Name = SettingName.ContactPostHeader, DataType = Constants.DataType.String, Category = SettingCategory.Contact, Value = "contact post header" },
                    new Setting() { Name = SettingName.ContactEmail, DataType = Constants.DataType.String, Category = SettingCategory.Contact, Value = "eat@food.truck" },
                    new Setting() { Name = SettingName.ContactPhone, DataType = Constants.DataType.String, Category = SettingCategory.Contact, Value = "555-555-5555" },
                    new Setting() { Name = SettingName.IsApplyOn, DataType = Constants.DataType.Boolean, Category = SettingCategory.Contact, Value = false.ToString() },
                    new Setting() { Name = SettingName.ApplyText, DataType = Constants.DataType.LongString, Category = SettingCategory.Contact, Value = string.Empty },

                    new Setting() { Name = SettingName.Facebook, DataType = Constants.DataType.String, Category = SettingCategory.Social, Value = string.Empty },
                    new Setting() { Name = SettingName.Twitter, DataType = Constants.DataType.String, Category = SettingCategory.Social, Value = string.Empty },
                    new Setting() { Name = SettingName.Instagram, DataType = Constants.DataType.String, Category = SettingCategory.Social, Value = string.Empty },
                    new Setting() { Name = SettingName.LinkedIn, DataType = Constants.DataType.String, Category = SettingCategory.Social, Value = string.Empty },
                    new Setting() { Name = SettingName.Pinterest, DataType = Constants.DataType.String, Category = SettingCategory.Social, Value = string.Empty },

                    new Setting() { Name = SettingName.Keywords, DataType = Constants.DataType.LongString, Category = SettingCategory.Meta, Value = string.Empty },
                    new Setting() { Name = SettingName.Author, DataType = Constants.DataType.String, Category = SettingCategory.Meta, Value = string.Empty },

                    new Setting() { Name = SettingName.GoogleMapsApiKey, DataType = Constants.DataType.String, Category = SettingCategory.ExternalApps, Value = string.Empty },
                    new Setting() { Name = SettingName.GoogleMapsDeveloperApiKey, DataType = Constants.DataType.String, Category = SettingCategory.ExternalApps, Value = string.Empty },
                    new Setting() { Name = SettingName.TwilioAuthToken, DataType = Constants.DataType.String, Category = SettingCategory.ExternalApps, Value = string.Empty },
                    new Setting() { Name = SettingName.TwilioPhoneNumber, DataType = Constants.DataType.String, Category = SettingCategory.ExternalApps, Value = string.Empty },
                    new Setting() { Name = SettingName.TwilioSid, DataType = Constants.DataType.String, Category = SettingCategory.ExternalApps, Value = string.Empty },
                    new Setting() { Name = SettingName.DoorDashLink, DataType = Constants.DataType.String, Category = SettingCategory.ExternalApps, Value = string.Empty },
                    new Setting() { Name = SettingName.PostmatesLink, DataType = Constants.DataType.String, Category = SettingCategory.ExternalApps, Value = string.Empty },
                    new Setting() { Name = SettingName.GrubHubLink, DataType = Constants.DataType.String, Category = SettingCategory.ExternalApps, Value = string.Empty },
                    new Setting() { Name = SettingName.OrderServiceText, DataType = Constants.DataType.LongString, Category = SettingCategory.ExternalApps, Value = string.Empty },

                    new Setting() { Name = SettingName.OrderNotificationEmails, DataType = Constants.DataType.LongString, Category = SettingCategory.OrderNotification, Value = string.Empty },
                    new Setting() { Name = SettingName.OrderNotificationPhoneNumbers, DataType = Constants.DataType.LongString, Category = SettingCategory.OrderNotification, Value = string.Empty },
                    new Setting() { Name = SettingName.AutoNotificationDelayInMinutes, DataType = Constants.DataType.Integer, Category = SettingCategory.OrderNotification, Value = string.Empty },

                    new Setting() { Name = SettingName.DaysInFutureToDisplay, DataType = Constants.DataType.Integer, Category = SettingCategory.Calendar, Value = 30.ToString() },
                    new Setting() { Name = SettingName.IcalUrl, DataType = Constants.DataType.String, Category = SettingCategory.Calendar, Value = string.Empty },

                    new Setting() { Name = SettingName.SundayOpen, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 0},
                    new Setting() { Name = SettingName.SundayClose, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 1 },
                    new Setting() { Name = SettingName.MondayOpen, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 2 },
                    new Setting() { Name = SettingName.MondayClose, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 3 },
                    new Setting() { Name = SettingName.TuesdayOpen, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 4 },
                    new Setting() { Name = SettingName.TuesdayClose, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 5 },
                    new Setting() { Name = SettingName.WednesdayOpen, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 6 },
                    new Setting() { Name = SettingName.WednesdayClose, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 7 },
                    new Setting() { Name = SettingName.ThursdayOpen, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 8 },
                    new Setting() { Name = SettingName.ThursdayClose, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 9 },
                    new Setting() { Name = SettingName.FridayOpen, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 10 },
                    new Setting() { Name = SettingName.FridayClose, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 11 },
                    new Setting() { Name = SettingName.SaturdayOpen, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 12 },
                    new Setting() { Name = SettingName.SaturdayClose, DataType = Constants.DataType.Time, Category = SettingCategory.HoursOfOperation, Value = string.Empty, Order = 13 },
                };
            }
        }
    }
}