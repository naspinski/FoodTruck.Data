using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.Events;
using Naspinski.FoodTruck.Data.Models.Events;

namespace Naspinski.FoodTruck.Data.Access.Commands.Events
{
    public class Upsert : ResultCommandBase<FoodTruckContext, Event>
    {
        private readonly Event _model;

        public Upsert(FoodTruckContext context, string user, Event model) : base(context, user)
        {
            _model = model;
        }

        protected override Event InternalExecute()
        {
            var isNew = _model.Id == 0;

            var upsert = isNew ? new Event() : new Get(_context, _model.Id).ExecuteAndReturnResults();

            upsert.Begins = _model.Begins;
            upsert.Ends = _model.Ends;
            upsert.LocationId = _model.LocationId;

            if (isNew)
            {
                upsert.Create(_user);
                _context.Events.Add(upsert);
            }
            else upsert.Update(_user);

            _context.SaveChanges();
            return upsert;
        }
    }
}
