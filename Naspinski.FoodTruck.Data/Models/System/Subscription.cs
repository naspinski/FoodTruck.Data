using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Naspinski.FoodTruck.Data.Models.System
{
    public class Subscription
    {
        [NotMapped]
        public static class Types
        {
            public const string Email = "email";
            public const string Text = "text";
        }

        [Key]
        public int Id { get; set; }

        [NotMapped] private string _subscriber;
        [Required]
        public string Subscriber
        {
            get { return _subscriber;  }
            set
            {
                bool isEmail;
                _subscriber = SanitizeSubscriber(value, out isEmail);
                Type = isEmail ? Types.Email : Types.Text;
            }
        }

        [NotMapped] private string _location;
        [Required]
        public string Location
        {
            get { return _location; }
            set { _location = SanitizeLocation(value); }
        }

        [Required]
        public string Type { get; set; }

        public Subscription() { }
        public Subscription(string subscriber, string location)
        {
            Subscriber = subscriber;
            Location = SanitizeLocation(location);
        }

        public static string SanitizeLocation(string location)
        {
            location = location.ToLower().Trim();
            var idx = location.IndexOf(":");
            if (idx > 0)
                location = location.Substring(0, idx);
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            return rgx.Replace(location, "");
        }
        
        public static string SanitizeSubscriber(string subscriber, out bool isEmail)
        {
            subscriber = subscriber.ToLower().Trim();
            try
            {
                var email = new MailAddress(subscriber);
                isEmail = true;
            }
            catch { isEmail = false; }

            if (!isEmail)
            {
                subscriber = (new string(subscriber.Where(c => char.IsDigit(c)).ToArray())).TrimStart('1');
                if (subscriber.Length != 10)
                    throw new ArgumentException("input is not valid phone number or email");
            }
            return subscriber;
        }
    }
}
