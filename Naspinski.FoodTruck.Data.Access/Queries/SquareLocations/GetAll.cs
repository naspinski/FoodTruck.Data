using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.System;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.SquareLocations
{
    public class GetAll : ResultQueryBase<FoodTruckContext, List<SquareLocation>>
    {
        private readonly bool _isDeleted;

        public GetAll(FoodTruckContext context, bool isDeleted = false) : base(context)
        {
            _isDeleted = isDeleted;
        }

        protected override List<SquareLocation> InternalExecute()
        {
            return _context.SquareLocations.Where(x => x.Deleted.HasValue == _isDeleted).ToList();
        }
    }
}
