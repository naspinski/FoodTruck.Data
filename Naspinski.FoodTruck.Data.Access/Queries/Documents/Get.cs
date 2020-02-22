using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Storage;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Documents
{
    public class Get : ResultQueryBase<FoodTruckContext, Document>
    {
        private readonly int _id;

        public Get(FoodTruckContext context, int id) : base(context)
        {
            _id = id;
        }

        protected override Document InternalExecute()
        {
            return _context.Documents.SingleOrDefault(x => x.Id == _id);
        }
    }
}
