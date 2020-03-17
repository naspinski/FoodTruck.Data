using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.Specials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Naspinski.FoodTruck.Data.Distribution.Models.Specials
{
    public class SpecialModel : IToModel<Special>
    {
        [Required]
        public int Id { get; set; }
        public bool IsNew { get { return Id == 0; } }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime? Begins { get; set; }
        public DateTime? Ends { get; set; }

        public bool IsSunday { get; set; }
        public bool IsMonday{ get; set; }
        public bool IsTuesday { get; set; }
        public bool IsWednesday { get; set; }
        public bool IsThursday { get; set; }
        public bool IsFriday { get; set; }
        public bool IsSaturday { get; set; }
        public bool IsDeleted { get; set; }

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
            Begins = model.Begins.HasValue ? model.Begins.Value.DateTime : (DateTime?)null;
            Ends = model.Ends.HasValue ? model.Ends.Value.DateTime : (DateTime?)null; ;
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
    }
}
