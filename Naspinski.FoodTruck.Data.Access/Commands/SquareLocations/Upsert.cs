using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.SquareLocations;
using Naspinski.FoodTruck.Data.Models.System;

namespace Naspinski.FoodTruck.Data.Access.Commands.SquareLocations
{
    public class Upsert : ResultCommandBase<FoodTruckContext, SquareLocation>
    {
        private readonly SquareLocation _model;

        public Upsert(FoodTruckContext context, string user, SquareLocation model) : base(context, user)
        {
            _model = model;
        }

        protected override SquareLocation InternalExecute()
        {
            var isNew = _model.Id == 0;

            var upsert = isNew ? new SquareLocation() : new Get(_context, _model.Id).ExecuteAndReturnResults();

            upsert.Name = _model.Name;
            upsert.AccessToken = _model.AccessToken;
            upsert.ApplicationId = _model.ApplicationId;
            upsert.LocationId = _model.LocationId;

            if (isNew)
            {
                upsert.Create(_user);
                _context.SquareLocations.Add(upsert);
            }
            else upsert.Update(_user);
            _context.SaveChanges();
            
            return upsert;
        }
    }
}
