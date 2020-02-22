using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using Query = Naspinski.FoodTruck.Data.Access.Queries;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.Menu
{
    public class SettingHandler : ICrudHandler<SettingModel, FoodTruckContext, SettingModel>
    {
        private FoodTruckContext _context;

        public SettingHandler(FoodTruckContext context)
        {
            _context = context;
        }

        public IEnumerable<SettingModel> GetAll(bool isDeleted = false)
        {
            return new Query.Settings.Get(_context).ExecuteAndReturnResults().Select(x => new SettingModel(x));
        }
        public IEnumerable<SettingModel> Get(IEnumerable<string> settings)
        {
            return new Query.Settings.Get(_context, settings).ExecuteAndReturnResults()
                .Select(x => new SettingModel(x));
        }

        public void Delete(int id) { throw new NotImplementedException(); }
        
        public SettingModel Get(int id) { throw new NotImplementedException(); }
        
        public SettingModel Upsert(SettingModel model) { throw new NotImplementedException(); }

        public void Restore(int id)
        {
            throw new NotImplementedException();
        }
    }
}
