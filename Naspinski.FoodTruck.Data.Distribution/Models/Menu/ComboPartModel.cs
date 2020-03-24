using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.Menu;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Distribution.Models.Menu
{
    public class ComboPartModel : IToModel<ComboPart>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int MenuItemId { get; set; }
        public IEnumerable<DropDownItem> Options { get; set; } = new List<DropDownItem>();

        public ComboPartModel() { }
        public ComboPartModel(ComboPart model)
        {
            Id = model.Id;
            CategoryId = model.CategoryId;
            MenuItemId = model.MenuItemId;
        }

        public ComboPart ToModel()
        {
            return new ComboPart()
            {
                Id = Id,
                CategoryId = CategoryId,
                MenuItemId = MenuItemId
            };
        }

        public void PopulateOptions(IEnumerable<CategoryModel> categories)
        {
            var category = categories.FirstOrDefault(x => x.Id == CategoryId);
            if (category == null) return;

            Options = category.MenuItems.Select(x => new DropDownItem() { Id = x.Id, Name = x.Name });
        }

        public class DropDownItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
