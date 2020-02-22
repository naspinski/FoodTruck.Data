using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.DeliveryDestinations;
using Naspinski.FoodTruck.Data.Models.System;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Commands.DeliveryDestinations
{
    public class Delete : ResultCommandBase<FoodTruckContext, DeliveryDestination>
    {
        private readonly int _id;

        public Delete(FoodTruckContext context, string user, int id) : base(context, user)
        {
            _id = id;
        }

        protected override DeliveryDestination InternalExecute()
        {
            var delete = new Get(_context, _id).ExecuteAndReturnResults();
            delete.Delete(_user);
            if (delete != null)
                _context.SaveChanges();
            return delete;
        }
    }
}
