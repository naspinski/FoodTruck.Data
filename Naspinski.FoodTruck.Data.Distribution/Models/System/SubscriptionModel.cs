using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.System;

namespace Naspinski.FoodTruck.Data.Distribution.Models.System
{
    public class SubscriptionModel : IToModel<Subscription>
    {
        public int Id { get; set; }
        public string Subscriber { get; set; }
        public string Location { get; set; }

        public string Type { get; set; }

        public SubscriptionModel() { }
        public SubscriptionModel(Subscription model)
        {
            Id = model.Id;
            Subscriber = model.Subscriber;
            Location = model.Location;
            Type = model.Type;
        }

        public Subscription ToModel()
        {
            return new Subscription()
            {
                Id = Id,
                Subscriber = Subscriber,
                Location = Location,
                Type = Type
            };
        }
    }
}
