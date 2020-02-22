using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.System;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Commands.Subscriptions
{
    public class Delete : ResultCommandBase<FoodTruckContext, List<Subscription>>
    {
        private readonly Subscription _model;

        public Delete(FoodTruckContext context, string subscriber, string location) : base(context, subscriber)
        {
            _model = new Subscription(subscriber, location);
        }

        protected override List<Subscription> InternalExecute()
        {
            var subscriptions = new List<Subscription>();
            if (!string.IsNullOrWhiteSpace(_model.Location))
                subscriptions.Add(new Queries.Subscriptions.Get(_context, _model.Subscriber, _model.Location).ExecuteAndReturnResults());
            else
                subscriptions = new Queries.Subscriptions.GetAll(_context, subscriber: _model.Subscriber).ExecuteAndReturnResults();

            foreach (var sub in subscriptions.Where(x => x != null))
                _context.Remove(sub);

            _context.SaveChanges();
            return subscriptions;
        }
    }
}
