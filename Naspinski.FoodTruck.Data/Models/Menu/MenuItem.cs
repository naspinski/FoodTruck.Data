using Naspinski.Data.Model;
using Naspinski.FoodTruck.Data.Models.Storage;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Models.Menu
{
    public class MenuItem : AuditCreateUpdateDeleteBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? ImageId { get; set; }
        public Image Image { get; set; }
        public int SortOrder { get; set; }
        public string ItemId { get; set; }

        [NotMapped]
        public bool IsCombo {
            get
            {
                return ComboParts != null && ComboParts.Any(x => x.Deleted != null);
            }
        }

        public IEnumerable<Price> Prices { get; set; }
        public IEnumerable<ComboPart> ComboParts { get; set; }
    }
}
