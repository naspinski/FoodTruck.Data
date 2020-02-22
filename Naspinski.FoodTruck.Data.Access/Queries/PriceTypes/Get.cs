using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Menu;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.PriceTypes
{
    public class Get : ResultQueryBase<FoodTruckContext, PriceType>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override PriceType InternalExecute()
        {
            return _context.PriceTypes.SingleOrDefault(x => x.Id == _id);
        }
    }
}
