using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Menu;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.MenuItems
{
    public class GetAll : ResultQueryBase<FoodTruckContext, List<MenuItem>>
    {
        private readonly bool _isDeleted;
        private readonly bool _includeDeleted;

        public GetAll(FoodTruckContext context, bool includeDetails = true, bool isDeleted = false) : base(context)
        {
            _isDeleted = isDeleted;
            _includeDeleted = includeDetails;
        }

        protected override List<MenuItem> InternalExecute()
        {
            var set = (!_includeDeleted
                ? _context.MenuItems.AsQueryable()
                : _context.MenuItems
                    .Include(x => x.Category)
                    .Include(x => x.Image)
                    .Include(x => x.ComboParts)
                        .ThenInclude(x => x.Category)
                            .ThenInclude(x => x.MenuItems)
                    .Include(x => x.Prices)
                        .ThenInclude(x => x.PriceType));
            return set.Where(x => x.Deleted.HasValue == _isDeleted).ToList();
        }
    }
}
