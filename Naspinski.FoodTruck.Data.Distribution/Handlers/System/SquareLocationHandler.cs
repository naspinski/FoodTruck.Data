using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.System;
using Naspinski.FoodTruck.Data.Models.System;
using System.Collections.Generic;
using System.Linq;
using Command = Naspinski.FoodTruck.Data.Access.Commands;
using Query = Naspinski.FoodTruck.Data.Access.Queries;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.System
{
    public class SquareLocationHandler : ICrudHandler<SquareLocationModel, FoodTruckContext, SquareLocationModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public SquareLocationHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }
        public SquareLocationModel Get(int id)
        {
            return id == 0 ? new SquareLocationModel() : new SquareLocationModel(new Query.SquareLocations.Get(_context, id).ExecuteAndReturnResults());
        }

        public IEnumerable<SquareLocationModel> GetAll(bool isDeleted = false)
        {
            return new Query.SquareLocations.GetAll(_context, isDeleted).ExecuteAndReturnResults().Select(x => new SquareLocationModel(x)).OrderBy(x => x.Name);
        }

        public SquareLocationModel Upsert(SquareLocationModel model)
        {
            return new SquareLocationModel(new Command.SquareLocations.Upsert(_context, _user, model.ToModel()).ExecuteAndReturnResults());
        }

        public void Delete(int id)
        {
            new Command.SquareLocations.DeleteRestore(_context, _user, id, false).Execute();
        }

        public void Restore(int id)
        {
            new Command.SquareLocations.DeleteRestore(_context, _user, id, true).Execute();
        }
    }
}
