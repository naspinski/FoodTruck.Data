using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Storage;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Images
{
    public class GetAll : ResultQueryBase<FoodTruckContext, List<Image>>
    {
        private readonly bool _isDeleted;

        public GetAll(FoodTruckContext context, bool isDeleted = false) : base(context)
        {
            _isDeleted = isDeleted;
        }

        protected override List<Image> InternalExecute()
        {
            return _context.Images.Where(x => x.Deleted.HasValue == _isDeleted).ToList();
        }
    }
}
