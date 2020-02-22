using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.System;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Settings
{
    public class Get : ResultQueryBase<FoodTruckContext, List<Setting>>
    {
        private readonly IEnumerable<string> _keys;
        
        public Get(FoodTruckContext context, IEnumerable<string> keys = null) : base(context)
        {
            _keys = keys == null || !keys.Any() ? null : keys.Select(x => x);
        }

        protected override List<Setting> InternalExecute()
        {
            return _keys == null ? _context.Settings.ToList() : _context.Settings.Where(x => _keys.Contains(x.Name)).ToList();
        }
    }
}
