using Naspinski.Data.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naspinski.FoodTruck.Data.Models.Events
{
    public class Location : AuditCreateUpdateDeleteBase
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        public IEnumerable<Event> Events { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        [NotMapped]
        public string GoogleMapsApiKey;
    }
}
