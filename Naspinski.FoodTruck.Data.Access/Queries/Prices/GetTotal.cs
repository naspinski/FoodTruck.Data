using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.AdditionalModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Prices
{ 
    public class GetTotal : ResultQueryBase<FoodTruckContext, TotalResult>
    {
        private IEnumerable<PriceAndQuantity> _priceAndQuantity;

        public GetTotal(FoodTruckContext context, IEnumerable<PriceAndQuantity> priceAndQuantity): base(context)
        {
            _priceAndQuantity = priceAndQuantity;
        }

        protected override TotalResult InternalExecute()
        {
            var priceIds = _priceAndQuantity.Select(y => y.PriceId).ToList();
            var prices = _context.Prices.Where(x => priceIds.Contains(x.Id)).Distinct().ToList();
            var total = _priceAndQuantity.Sum(x => x.Quantity * prices.Single(y => y.Id == x.PriceId).Amount);
            return new TotalResult() { TotalInCents = Convert.ToInt32(total * 100) };
        }
    }
}
