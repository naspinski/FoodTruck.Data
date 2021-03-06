﻿using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.System;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Commands.Settings
{
    public class Update : ResultCommandBase<FoodTruckContext, IEnumerable<Setting>>
    {
        private readonly IEnumerable<Setting> _settings;
        private readonly bool _singleUpdate;

        public Update(FoodTruckContext context, string user, IEnumerable<Setting> settings) : base(context, user)
        {
            _settings = settings;
            _singleUpdate = false;
        }
        public Update(FoodTruckContext context, string user, Setting setting) : base(context, user)
        {
            _settings = new List<Setting>() { setting };
            _singleUpdate = true;
        }

        protected override IEnumerable<Setting> InternalExecute()
        {
            var settings = new Queries.Settings.Get(_context).ExecuteAndReturnResults();

            if (_singleUpdate)
                settings = settings.Where(x => x.Name == (_settings.FirstOrDefault()?.Name ?? "")).ToList();

            foreach (var setting in settings)
            {
                var s = _settings.SingleOrDefault(x => x.Name == setting.Name);
                if (s != null)
                {
                    setting.Value = s.Value;
                    if (setting.DataType == Constants.DataType.Boolean)
                    {
                        var v = s.Value.ToLower();
                        setting.Value = (v == "true" || v == "on" || v == "1") ? true.ToString() : false.ToString();
                    }
                }
                else if (setting.DataType == Constants.DataType.Boolean && !setting.IsHidden)
                    setting.Value = false.ToString();

                setting.Update(_user);
            }

            _context.SaveChanges();
            return settings;
        }
    }
}
