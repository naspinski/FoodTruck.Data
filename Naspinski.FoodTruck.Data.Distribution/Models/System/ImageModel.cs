using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.Storage;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Distribution.Models.System
{
    public class ImageModel : IToModel<Image>
    {
        public int Id { get; set; }
        public bool IsNew { get { return Id == 0; } }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }
        public bool IsDeleted { get; set; }

        public ImageModel() { }

        public ImageModel(Image model)
        {
            Id = model.Id;
            Name = model.Name;
            Location = model.Location;
            IsDeleted = model.Deleted.HasValue;
        }

        public Image ToModel()
        {
            return new Image()
            {
                Id = Id,
                Name = Name,
                Location = Location
            };
        }
    }
}
