using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.Menu;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Distribution.Models.Menu
{
    public class CategoryModel : IToModel<Category>
    {
        public int Id { get; set; }
        public bool IsNew { get { return Id == 0; } }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public bool HasDescription { get { return !string.IsNullOrWhiteSpace(Description); } }

        [Display(Name="Sort Order")]
        public int SortOrder { get; set; }

        [Display(Name = "Exclude From Menu")]
        public bool ExcludeFromMenu { get; set; } = false;

        [Display(Name = "Exclude From Ordering")]
        public bool ExcludeFromOrdering { get; set; } = false;

        public CategoryModel() { }
        public List<MenuItemModel> MenuItems = new List<MenuItemModel>();

        public CategoryModel(Category model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            SortOrder = model.SortOrder;
            ExcludeFromMenu = model.ExcludeFromMenu;
            ExcludeFromOrdering = model.ExcludeFromOrdering;
        }

        public Category ToModel()
        {
            return new Category()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                SortOrder = SortOrder,
                ExcludeFromMenu = ExcludeFromMenu,
                ExcludeFromOrdering = ExcludeFromOrdering
            };
        }
    }
}
