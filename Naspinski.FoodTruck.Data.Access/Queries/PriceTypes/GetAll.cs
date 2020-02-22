using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Menu;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.PriceTypes
{
    public class GetAll : ResultQueryBase<FoodTruckContext, List<PriceType>>
    {
        private readonly bool _isDeleted;

        public GetAll(FoodTruckContext context, bool isDeleted = false) : base(context)
        {
            _isDeleted = isDeleted;
        }

        protected override List<PriceType> InternalExecute()
        {
            return _context.PriceTypes.Where(x => x.Deleted.HasValue == _isDeleted).ToList();
        }
    }
}
