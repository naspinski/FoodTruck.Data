using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Events
{
    public class GetAll : ResultQueryBase<FoodTruckContext, List<Event>>
    {
        private readonly bool _isDeleted;
        private readonly DateTimeOffset _begins;
        private readonly DateTimeOffset _ends;

        public GetAll(FoodTruckContext context, DateTimeOffset begins, DateTimeOffset? ends, bool isDeleted = false) : base(context)
        {
            _isDeleted = isDeleted;
            _begins = begins;
            _ends = ends ?? DateTimeOffset.MaxValue;
        }

        protected override List<Event> InternalExecute()
        {
            return _context.Events
                .Include(x => x.Location)
                .Where(x => 
                    x.Deleted.HasValue == _isDeleted
                    && x.Begins >= _begins
                    && (x.Ends == null || x.Ends <= _ends)
                ).OrderBy(x => x.Begins).ToList();
        }
    }
}
