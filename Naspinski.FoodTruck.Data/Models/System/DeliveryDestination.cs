using Naspinski.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naspinski.FoodTruck.Data.Models.System
{
    public class DeliveryDestination :AuditCreateUpdateDeleteBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public bool IsCity { get; set; }

        [Required]
        public bool IsBlacklist { get; set; }

        [NotMapped]
        public bool IsWhiteList {  get { return !IsBlacklist; } }
        [NotMapped]
        public bool IsZipCode { get { return !IsCity; } }
    }
}
