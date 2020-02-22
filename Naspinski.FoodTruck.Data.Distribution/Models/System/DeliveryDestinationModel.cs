using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.System;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Distribution.Models.System
{
    public class DeliveryDestinationModel : IToModel<DeliveryDestination>
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public bool IsCity { get; set; }

        [Required]
        [Display(Name = "Blacklist?")]
        public bool IsBlacklist { get; set; }

        public bool IsWhiteList { get { return !IsBlacklist; } }
        public bool IsZipCode { get { return !IsCity; } }

        public DeliveryDestinationModel() { }
        public DeliveryDestinationModel(DeliveryDestination model)
        {
            Id = model.Id;
            Value = model.Value;
            IsCity = model.IsCity;
            IsBlacklist = model.IsBlacklist;
        }

        public DeliveryDestination ToModel()
        {
            return new DeliveryDestination()
            {
                Id = Id,
                Value = Value,
                IsCity = IsCity,
                IsBlacklist = IsBlacklist
            };
        }
    }
}
