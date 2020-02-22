using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Menu;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.MenuItems
{
    public class Get : ResultQueryBase<FoodTruckContext, MenuItem>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override MenuItem InternalExecute()
        {
            return _context.MenuItems
                .Include(x => x.Category)
                .Include(x => x.Image)
                .Include(x => x.ComboParts)
                .Include(x => x.Prices)
                    .ThenInclude(x => x.PriceType)
                .SingleOrDefault(x => x.Id == _id);
        }
    }
}
