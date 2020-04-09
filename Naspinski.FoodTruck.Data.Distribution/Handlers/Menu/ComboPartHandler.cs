using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.Menu;
using System;
using System.Collections.Generic;
using Command = Naspinski.FoodTruck.Data.Access.Commands;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.Menu
{
    public class ComboPartHandler : ICrudHandler<ComboPartModel, FoodTruckContext, ComboPartModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public ComboPartHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }

        public void Delete(int id)
        {
            new Command.ComboParts.Delete(_context, _user, id).Execute();
        }

        public ComboPartModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ComboPartModel> GetAll(bool isDeleted = false)
        {
            throw new NotImplementedException();
        }

        public void Restore(int id)
        {
            throw new NotImplementedException();
        }

        public ComboPartModel Upsert(ComboPartModel model)
        {
            throw new NotImplementedException();
        }
    }
}
