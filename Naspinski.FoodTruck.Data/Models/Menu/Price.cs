using Naspinski.Data.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Models.Menu
{
    public class Price : AuditCreateUpdateDeleteBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }
        
        public int? PriceTypeId { get; set; }
        public PriceType PriceType { get; set; }

        [Required]
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
    }
}
