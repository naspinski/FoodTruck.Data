using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.Specials;
using Naspinski.FoodTruck.Data.Models.Specials;

namespace Naspinski.FoodTruck.Data.Access.Commands.Specials
{
    public class Upsert : ResultCommandBase<FoodTruckContext, Special>
    {
        private readonly Special _model;

        public Upsert(FoodTruckContext context, string user, Special model) : base(context, user)
        {
            _model = model;
        }

        protected override Special InternalExecute()
        {
            var isNew = _model.Id == 0;

            var upsert = isNew ? new Special() : new Get(_context, _model.Id).ExecuteAndReturnResults();

            upsert.Name = _model.Name;
            upsert.Description = _model.Description;
            upsert.Begins = _model.Begins;
            upsert.Ends = _model.Ends;
            upsert.IsSunday = _model.IsSunday;
            upsert.IsMonday = _model.IsMonday;
            upsert.IsTuesday = _model.IsTuesday;
            upsert.IsWednesday = _model.IsWednesday;
            upsert.IsThursday = _model.IsThursday;
            upsert.IsFriday = _model.IsFriday;
            upsert.IsSaturday = _model.IsSaturday;

            if (isNew)
            {
                upsert.Create(_user);
                _context.Specials.Add(upsert);
            }
            else upsert.Update(_user);
            _context.SaveChanges();
            
            return upsert;
        }
    }
}
