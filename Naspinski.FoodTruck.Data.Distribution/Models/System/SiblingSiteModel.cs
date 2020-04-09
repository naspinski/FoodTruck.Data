using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.System;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Distribution.Models.System
{
    public class SiblingSiteModel : IToModel<SiblingSite>
    {
        public int Id { get; set; }
        public bool IsNew { get { return Id == 0; } }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public bool IsDeleted { get; set; }

        public SiblingSiteModel() { }

        public SiblingSiteModel(SiblingSite model)
        {
            Id = model.Id;
            Name = model.Name;
            Url = model.Url;
            IsDeleted = model.Deleted.HasValue;
        }

        public SiblingSite ToModel()
        {
            return new SiblingSite()
            {
                Id = Id,
                Name = Name,
                Url = Url
            };
        }
    }
}
