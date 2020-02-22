using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.System;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.DeliveryDestinations
{
    public class GetAll : ResultQueryBase<FoodTruckContext, List<DeliveryDestination>>
    {
        private readonly bool _isDeleted;

        public GetAll(FoodTruckContext context, bool isDeleted = false) : base(context)
        {
            _isDeleted = isDeleted;
        }

        protected override List<DeliveryDestination> InternalExecute()
        {
            return _context.DeliveryDestinations.Where(x => x.Deleted.HasValue == _isDeleted).ToList();
        }
    }
}
