using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Distribution.Models.Menu
{
    public class MenuItemsModel
    {
        private List<MenuItemModel> _menuItems;
        public List<CategoryModel> Categories { get; set; }

        public MenuItemsModel() { }
        public MenuItemsModel(IEnumerable<MenuItemModel> models)
        {
            _menuItems = models.ToList(); ;
            Categories = new List<CategoryModel>();
            foreach (var item in _menuItems)
            {
                if (!Categories.Any(x => x.Id == item.CategoryId)) Categories.Add(item.Category ?? new CategoryModel());

                var cat = Categories.First(x => item.CategoryId == null ? x.Id == 0 : item.CategoryId == x.Id);
                item.Category = null;
                cat.MenuItems.Add(item);
            }
            Categories = Categories.OrderBy(x => x.SortOrder).ToList();
        }
    }
}
