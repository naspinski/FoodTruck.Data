using Naspinski.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Naspinski.FoodTruck.Data.Models.Specials
{
    public class Special : AuditCreateUpdateDeleteBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? Begins { get; set; }
        public DateTimeOffset? Ends { get; set; }

        [Required]
        public bool IsSunday { get; set; }
        [Required]
        public bool IsMonday { get; set; }
        [Required]
        public bool IsTuesday { get; set; }
        [Required]
        public bool IsWednesday { get; set; }
        [Required]
        public bool IsThursday { get; set; }
        [Required]
        public bool IsFriday { get; set; }
        [Required]
        public bool IsSaturday { get; set; }

        [NotMapped]
        public bool IsAllDay { get { return Begins == null && Ends == null; } }
    }
}
