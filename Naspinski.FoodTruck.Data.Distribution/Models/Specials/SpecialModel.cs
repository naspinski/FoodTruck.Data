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
