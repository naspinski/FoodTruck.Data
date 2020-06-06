using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Orders
{
    public class GetAll : ResultQueryBase<FoodTruckContext, List<Order>>
    {
        private readonly bool _isDeleted;
        private readonly bool _isSandbox;
        private readonly bool _showMade;
        private readonly DateTimeOffset _begins;
        private readonly DateTimeOffset _ends;

        public GetAll(FoodTruckContext context, DateTimeOffset begins, DateTimeOffset? ends = null, bool isDeleted = false, bool isSandbox = false, bool showMade = false) : base(context)
        {
            _isDeleted = isDeleted;
            _isSandbox = isSandbox;
            _showMade = showMade;
            _begins = begins;
            _ends = ends ?? _begins.AddDays(1);
        }

        protected override List<Order> InternalExecute()
        {
            return _context.Orders
                .Where(x => 
                    x.Deleted.HasValue == _isDeleted
                    && (_showMade || x.Made == null)
                    && x.IsSandbox == _isSandbox
                    && x.Created >= _begins
                    && x.Created <= _ends
                ).ToList()
                .Where(x => x.IsTransactionComplete)
                .ToList();
        }
    }
}
