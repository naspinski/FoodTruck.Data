using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.System;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Subscriptions
{
    public class Get : ResultQueryBase<FoodTruckContext, Subscription>
    {
        private readonly string _subscriber;
        private readonly string _location;

        public Get(FoodTruckContext context, string subscriber, string location) : base(context)
        {
            bool dummy;
            _location = Subscription.SanitizeLocation(location);
            try { _subscriber = Subscription.SanitizeSubscriber(subscriber, out dummy); }
            catch { _subscriber = string.Empty; }
        }

        protected override Subscription InternalExecute()
        {
            return _context.Subscriptions.FirstOrDefault(x => x.Subscriber == _subscriber && x.Location == _location);
        }
    }
}
