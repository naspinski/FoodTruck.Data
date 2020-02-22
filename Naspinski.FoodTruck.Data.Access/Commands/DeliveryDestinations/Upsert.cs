using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.System;
using Naspinski.FoodTruck.Data.Access.Queries.DeliveryDestinations;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Commands.DeliveryDestinations
{
    public class Upsert : ResultCommandBase<FoodTruckContext, DeliveryDestination>
    {
        private readonly DeliveryDestination _model;

        public Upsert(FoodTruckContext context, string user, DeliveryDestination model) : base(context, user)
        {
            _model = model;
        }

        protected override DeliveryDestination InternalExecute()
        {
            var isNew = _model.Id == 0;

            var dupes = _context.DeliveryDestinations.Where(x => x.Deleted == null && x.IsCity == _model.IsCity
                && x.Value.Trim().Equals(_model.Value.Trim(), System.StringComparison.InvariantCultureIgnoreCase));

            if (dupes.Any())
                return dupes.First();

            var upsert = isNew ? new DeliveryDestination() : new Get(_context, _model.Id).ExecuteAndReturnResults();

            upsert.Value = _model.Value;
            upsert.IsCity = _model.IsCity;
            upsert.IsBlacklist = _model.IsBlacklist;

            if (isNew)
            {
                upsert.Create(_user);
                _context.DeliveryDestinations.Add(upsert);
            }
            else upsert.Update(_user);

            _context.SaveChanges();
            return upsert;
        }
    }
}
