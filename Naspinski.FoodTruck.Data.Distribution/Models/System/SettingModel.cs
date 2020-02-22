using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.System;

namespace Naspinski.FoodTruck.Data.Distribution.Models.System
{
    public class SettingModel : IToModel<Setting>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Order { get; set; }

        public SettingModel() { }
        public SettingModel(Setting model)
        {
            Id = model.Id;
            Name = model.Name;
            Value = model.Value;
            Order = model.Order;
        }

        public Setting ToModel()
        {
            return new Setting()
            {
                Id = Id,
                Name = Name,
                Value = Value,
                Order = Order
            };
        }
    }
}
