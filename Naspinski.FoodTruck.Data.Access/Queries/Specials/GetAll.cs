using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Specials;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Specials
{
    public class GetAll : ResultQueryBase<FoodTruckContext, List<Special>>
    {
        private readonly bool _isDeleted;

        public GetAll(FoodTruckContext context, bool isDeleted = false) : base(context)
        {
            _isDeleted = isDeleted;
        }

        protected override List<Special> InternalExecute()
        {
            return _context.Specials.Where(x => x.Deleted.HasValue == _isDeleted).ToList();
        }
    }
}
