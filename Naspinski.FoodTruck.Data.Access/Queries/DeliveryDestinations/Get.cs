using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.System;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.DeliveryDestinations
{
    public class Get : ResultQueryBase<FoodTruckContext, DeliveryDestination>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override DeliveryDestination InternalExecute()
        {
            return _context.DeliveryDestinations.FirstOrDefault(x => x.Id == _id);
        }
    }
}
