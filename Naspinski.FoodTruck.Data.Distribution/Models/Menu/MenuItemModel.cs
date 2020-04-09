using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.Menu;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Distribution.Models.Menu
{
    public class MenuItemModel : IToModel<MenuItem>
    {
        public int Id { get; set; }
        public bool IsNew { get { return Id == 0; } }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public bool IsCombo { get; set; }

        [Display(Name = "Image")]
        public int? ImageId { get; set; }
        
        public string ImageLocation { get; set; }

        public bool HasImage { get { return !string.IsNullOrWhiteSpace(ImageLocation); } }

        [Display(Name = "Sort Order")]
        public int SortOrder { get; set; }

        public List<PriceModel> Prices { get; set; }

        public List<ComboPartModel> ComboParts { get; set; }

        [Display(Name = "Square Item Id")]
        public string ItemId { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<string> PriceTypeNames
        {
            get
            {
                return Prices?.Where(x => string.IsNullOrEmpty(x.PriceTypeName)).Select(x => x.PriceTypeName) ?? new List<string>();
            }
        }
        
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public CategoryModel Category;

        public MenuItemModel() { }

        public MenuItemModel(MenuItem model)
        {
            Id = model.Id;
            Name = model.Name;
            Description = model.Description;
            CategoryId = model.CategoryId;
            Category = model.Category == null ? null : new CategoryModel(model.Category);
            Prices = model.Prices?.ToList().Where(x => x.Deleted == null && (x.PriceType == null || x.PriceType.Deleted == null))
                .Select(x => new PriceModel(x)).OrderBy(x => x.PriceTypeSortOrder).ToList() ?? new List<PriceModel>();
            IsCombo = model.IsCombo;
            ComboParts = model.ComboParts?.ToList().Where(x => x.Deleted == null).Select(x => new ComboPartModel(x)).ToList();
            ImageId = model.ImageId;
            ImageLocation = model?.Image?.Location ?? string.Empty;
            SortOrder = model.SortOrder;
            IsDeleted = model.Deleted.HasValue;
            ItemId = model.ItemId;
        }

        public MenuItem ToModel()
        {
            return new MenuItem()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                CategoryId = CategoryId == null || CategoryId < 1 ? null : CategoryId,
                Prices = Prices.Select(x => x.ToModel()),
                ComboParts = ComboParts.Select(x => x.ToModel()),
                ImageId = ImageId,
                SortOrder = SortOrder,
                ItemId = ItemId
            };
        }
    }
}
