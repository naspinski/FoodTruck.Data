using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.Specials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Naspinski.FoodTruck.Data.Distribution.Models.Specials
{
    public class SpecialModel : IToModel<Special>
    {
        private const string DateTimeFormat = "hh:mm tt";

        [Required]
        public int Id { get; set; }
        public bool IsNew { get { return Id == 0; } }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public TimeSpan? Begins { get; set; }
        public string BeginsString
        { get { return TimeSpanToString(Begins); } }
        public TimeSpan? Ends { get; set; }
        public string EndsString
        { get { return TimeSpanToString(Ends); } }

        [Display(Name = "Sunday")]
        [JsonIgnore]
        public bool IsSunday { get; set; }
        [Display(Name = "Monday")]
        [JsonIgnore]
        public bool IsMonday{ get; set; }
        [Display(Name = "Tuesday")]
        [JsonIgnore]
        public bool IsTuesday { get; set; }
        [Display(Name = "Wednesday")]
        [JsonIgnore]
        public bool IsWednesday { get; set; }
        [Display(Name = "Thursday")]
        [JsonIgnore]
        public bool IsThursday { get; set; }
        [Display(Name = "Friday")]
        [JsonIgnore]
        public bool IsFriday { get; set; }
        [Display(Name = "Saturday")]
        [JsonIgnore]
        public bool IsSaturday { get; set; }
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public string[] Days
        {
            get
            {
                var days = new List<string>();
                if (IsSunday) days.Add("Sunday");
                if (IsMonday) days.Add("Monday");
                if (IsTuesday) days.Add("Tuesday");
                if (IsWednesday) days.Add("Wednesday");
                if (IsThursday) days.Add("Thursday");
                if (IsFriday) days.Add("Friday");
                if (IsSaturday) days.Add("Saturday");
                return days.ToArray();
            }
        }

        [JsonIgnore]
        public string DayList
        {
            get
            {
                return string.Join(", ", Days);
            }
        }

        public SpecialModel() { }
        public SpecialModel(Special model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            Begins = model.Begins;
            Ends = model.Ends;
            IsSunday = model.IsSunday;
            IsMonday = model.IsMonday;
            IsTuesday = model.IsTuesday;
            IsWednesday = model.IsWednesday;
            IsFriday = model.IsFriday;
            IsSaturday = model.IsSaturday;
            IsDeleted = model.Deleted != null;
        }

        public Special ToModel()
        {
            return new Special
            { 
                Id = Id,
                Name = Name, 
                Description = Description,
                Begins = Begins,
                Ends = Ends,
                IsSunday = IsSunday,
                IsMonday = IsMonday,
                IsTuesday = IsTuesday,
                IsWednesday = IsWednesday,
                IsFriday = IsFriday,
                IsSaturday = IsSaturday
            };
        }

        private string TimeSpanToString(TimeSpan? ts)
        {
            return ts.HasValue ? DateTime.Today.Add(ts.Value).ToString(DateTimeFormat) : string.Empty;
        }
    }
}
