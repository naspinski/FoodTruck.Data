using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Menu;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Categories
{
    public class Get : ResultQueryBase<FoodTruckContext, Category>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override Category InternalExecute()
        {
            return _context.Categories.SingleOrDefault(x => x.Id == _id);
        }
    }
}
