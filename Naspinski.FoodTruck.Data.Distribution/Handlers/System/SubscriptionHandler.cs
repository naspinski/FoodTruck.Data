using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using Query = Naspinski.FoodTruck.Data.Access.Queries;
using Command = Naspinski.FoodTruck.Data.Access.Commands;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.System
{
    public class SubscriptionHandler
    {
        private FoodTruckContext _context;

        public SubscriptionHandler(FoodTruckContext context)
        {
            _context = context;
        }

        public IEnumerable<SubscriptionModel> GetAll(bool? isEmail, IEnumerable<string> locations = null)
        {
            return new Query.Subscriptions.GetAll(_context, isEmail, locations).ExecuteAndReturnResults().Select(x => new SubscriptionModel(x));
        }

        public void Delete(string subscriber, string location)
        {
            new Command.Subscriptions.Delete(_context, subscriber, location).Execute();
        }
        
        public SubscriptionModel Insert(string subscriber, string location)
        {
            return new SubscriptionModel(new Command.Subscriptions.Insert(_context, subscriber, location).ExecuteAndReturnResults());
        }
    }
}
