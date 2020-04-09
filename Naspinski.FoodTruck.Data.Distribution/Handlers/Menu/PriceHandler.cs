using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.Menu;
using System;
using System.Collections.Generic;
using Command = Naspinski.FoodTruck.Data.Access.Commands;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.Menu
{
    public class PriceHandler : ICrudHandler<PriceModel, FoodTruckContext, PriceModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public PriceHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }

        public void Delete(int id)
        {
            new Command.Prices.Delete(_context, _user, id).Execute();
        }

        public PriceModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PriceModel> GetAll(bool isDeleted = false)
        {
            throw new NotImplementedException();
        }

        public void Restore(int id)
        {
            throw new NotImplementedException();
        }

        public PriceModel Upsert(PriceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
