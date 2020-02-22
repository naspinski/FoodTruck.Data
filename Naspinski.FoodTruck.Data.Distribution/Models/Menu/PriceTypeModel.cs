using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.Menu;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Distribution.Models.Menu
{
    public class PriceTypeModel : IToModel<PriceType>
    {
        public int Id { get; set; }
        public bool IsNew { get { return Id == 0; } }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Sort Order")]
        public int SortOrder { get; set; }

        public PriceTypeModel() { }

        public PriceTypeModel(PriceType model)
        {
            Id = model.Id;
            Name = model.Name;
            SortOrder = model.SortOrder;
        }

        public PriceType ToModel()
        {
            return new PriceType()
            {
                Id = Id,
                Name = Name,
                SortOrder = SortOrder
            };
        }
    }
}
