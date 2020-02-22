using Naspinski.Data.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Models.Menu
{
    public class PriceType : AuditCreateUpdateDeleteBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int SortOrder { get; set; }

        public IEnumerable<Price> Prices { get; set; }
    }
}
