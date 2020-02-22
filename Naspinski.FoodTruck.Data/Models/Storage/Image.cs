using Naspinski.Data.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Models.Storage
{
    public class Image : AuditCreateUpdateDeleteBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Location { get; set; }
    }
}
