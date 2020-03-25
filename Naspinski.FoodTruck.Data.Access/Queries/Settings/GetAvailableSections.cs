using Naspinski.Data.CommandQuery.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using static Naspinski.FoodTruck.Data.Constants;

namespace Naspinski.FoodTruck.Data.Access.Queries.Settings
{
    public class GetAvailableSections : ResultQueryBase<FoodTruckContext, List<string>>
    {
        private readonly List<string> _sections = new List<string>();
        
        public GetAvailableSections(FoodTruckContext context) : base(context)
        { 
        
        }

        protected override List<string> InternalExecute()
        {
            CheckMenu();
            CheckCalendar();
            CheckSpecials();

            return _sections;
        }

        private void CheckMenu()
        {
            if (_context.MenuItems.Any(x =>!x.Deleted.HasValue && (x.Category == null || !x.Category.ExcludeFromMenu)))
                _sections.Add("menu");
        }

        private void CheckCalendar()
        {
            var displayDaysIntoFuture = 30;
            var displayDaysIntoFutureSetting = new Settings.Get(_context, new[] { SettingName.DaysInFutureToDisplay }).ExecuteAndReturnResults().FirstOrDefault();
            if (displayDaysIntoFutureSetting != null)
                int.TryParse(displayDaysIntoFutureSetting.Value, out displayDaysIntoFuture);
            if (new Events.GetAll(_context, DateTime.Now, DateTime.Now.AddDays(displayDaysIntoFuture > 0 ? displayDaysIntoFuture : 1)).ExecuteAndReturnResults().Any())
                _sections.Add("calendar");

        }

        private void CheckSpecials()
        {
            if (_context.Specials.Any(x => !x.Deleted.HasValue))
                _sections.Add("specials");
        }
    }
}
