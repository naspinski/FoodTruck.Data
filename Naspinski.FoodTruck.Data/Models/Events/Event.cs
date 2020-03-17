using Naspinski.Data.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Models.Events
{
    public class Event : AuditCreateUpdateDeleteBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTimeOffset Begins { get; set; }

        public DateTimeOffset? Ends { get; set; }

        [Required]
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
