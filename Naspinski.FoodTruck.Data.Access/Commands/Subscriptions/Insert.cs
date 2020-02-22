using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.System;

namespace Naspinski.FoodTruck.Data.Access.Commands.Subscriptions
{
    public class Insert : ResultCommandBase<FoodTruckContext, Subscription>
    {
        private readonly Subscription _model;

        public Insert(FoodTruckContext context, string subscriber, string location) : base(context, "system")
        {
            _model = new Subscription(subscriber, location);
        }

        protected override Subscription InternalExecute()
        {
            var exists = new Queries.Subscriptions.Get(_context, _model.Subscriber, _model.Location).ExecuteAndReturnResults();
            if (exists != null)
                return exists;

            _context.Subscriptions.Add(_model);
            _context.SaveChanges();
            return _model;
        }
    }
}
