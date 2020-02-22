using Naspinski.Data.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Models.Menu
{
    public class Category : AuditCreateUpdateDeleteBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int SortOrder { get; set; }

        public bool ExcludeFromMenu { get; set; } = false;

        public bool ExcludeFromOrdering { get; set; } = false;

        public List<MenuItem> MenuItems { get; set; }
    }
}
