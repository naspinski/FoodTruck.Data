using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.Specials;
using System;
using System.Collections.Generic;
using System.Linq;
using Command = Naspinski.FoodTruck.Data.Access.Commands;
using Query = Naspinski.FoodTruck.Data.Access.Queries;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.Specials
{
    public class SpecialHandler : ICrudHandler<SpecialModel, FoodTruckContext, SpecialModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public SpecialHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }
        public SpecialModel Get(int id)
        {
            return id == 0 ? new SpecialModel() : new SpecialModel(new Query.Specials.Get(_context, id).ExecuteAndReturnResults());
        }

        public IEnumerable<SpecialModel> GetAll(bool isDeleted = false)
        {
            return new Query.Specials.GetAll(_context, isDeleted).ExecuteAndReturnResults().Select(x => new SpecialModel(x));
        }

        public SpecialModel Upsert(SpecialModel model)
        {
            return new SpecialModel(new Command.Specials.Upsert(_context, _user, model.ToModel()).ExecuteAndReturnResults());
        }

        public void Delete(int id)
        {
            new Command.Specials.DeleteRestore(_context, _user, id, false).Execute();
        }

        public void Restore(int id)
        {
            new Command.Specials.DeleteRestore(_context, _user, id, true).Execute();
        }
    }
}
