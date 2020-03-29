using Naspinski.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Models.System
{
    public class SiblingSite : AuditCreateUpdateDeleteBase
    {
        //wtf
        [Key]
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Url { get; set; }
    }
}
