using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.System;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Distribution.Models.System
{
    public class SquareLocationModel : IToModel<SquareLocation>
    {
        public int Id { get; set; }
        public bool IsNew { get { return Id == 0; } }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Application ID")]
        public string ApplicationId { get; set; }
        
        [Required]
        [Display(Name = "Access Token")]
        public string AccessToken { get; set; }
        
        [Required]
        [Display(Name="Location ID")]
        public string LocationId { get; set; }
        public bool IsDeleted { get; set; }

        public SquareLocationModel() { }

        public SquareLocationModel(SquareLocation model)
        {
            Id = model.Id;
            Name = model.Name;
            ApplicationId = model.ApplicationId;
            AccessToken = model.AccessToken;
            LocationId = model.LocationId;
            IsDeleted = model.Deleted.HasValue;
        }

        public SquareLocation ToModel()
        {
            return new SquareLocation()
            {
                Id = Id,
                Name = Name,
                ApplicationId = ApplicationId,
                AccessToken = AccessToken,
                LocationId = LocationId
            };
        }
    }
}
