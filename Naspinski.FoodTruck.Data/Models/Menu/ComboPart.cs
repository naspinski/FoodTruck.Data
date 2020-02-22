using Naspinski.Data.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Models.Menu
{
    public class ComboPart : AuditCreateUpdateDeleteBase
    {
        [Key]
        public int Id { get; set; }
        
        public int MenuItemId { get; set; }
        
        public MenuItem MenuItem { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [NotMapped]
        public IEnumerable<MenuItem> MenuItems
        {
            get
            {
                return Category?.MenuItems?.Where(x => x.Deleted == null) ?? new List<MenuItem>();
            }
        }
    }
}
