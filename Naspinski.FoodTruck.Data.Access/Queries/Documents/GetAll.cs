using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Storage;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Documents
{
    public class GetAll : ResultQueryBase<FoodTruckContext, List<Document>>
    {
        private readonly bool _isDeleted;
        private readonly string _category;

        public GetAll(FoodTruckContext context, bool isDeleted = false) : base(context)
        {
            _isDeleted = isDeleted;
        }
        public GetAll(FoodTruckContext context, string category, bool isDeleted = false) : base(context)
        {
            _isDeleted = isDeleted;
            _category = category;
        }

        protected override List<Document> InternalExecute()
        {
            return _context.Documents
                .Where(x => x.Deleted.HasValue == _isDeleted 
                    && (string.IsNullOrEmpty(_category) || x.Category == _category))
                .ToList();
        }
    }
}
