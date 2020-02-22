using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Storage;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Images
{
    public class Get : ResultQueryBase<FoodTruckContext, Image>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override Image InternalExecute()
        {
            return _context.Images.SingleOrDefault(x => x.Id == _id);
        }
    }
}
