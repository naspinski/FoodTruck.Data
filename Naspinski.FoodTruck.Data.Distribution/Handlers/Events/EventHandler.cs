using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Distribution.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using Command = Naspinski.FoodTruck.Data.Access.Commands;
using Query = Naspinski.FoodTruck.Data.Access.Queries;

namespace Naspinski.FoodTruck.Data.Distribution.Handlers.Events
{
    public class EventHandler : ICrudHandler<EventModel, FoodTruckContext, EventModel>
    {
        private FoodTruckContext _context;
        private string _user;

        public EventHandler(FoodTruckContext context, string user)
        {
            _context = context;
            _user = user;
        }
        public EventModel Get(int id)
        {
            return id == 0 ? new EventModel() { Begins = DateTime.Now } : new EventModel(new Query.Events.Get(_context, id).ExecuteAndReturnResults());
        }

        public IEnumerable<EventModel> GetAll(bool isDeleted = false)
        {
            return new Query.Events.GetAll(_context, DateTime.MinValue.AddYears(1), DateTime.MaxValue.AddYears(-1), isDeleted).ExecuteAndReturnResults().Select(x => new EventModel(x));
        }

        public IEnumerable<EventModel> GetAll(DateTime from, DateTime? to = null, bool isDeleted = false)
        {
            return new Query.Events.GetAll(_context, from, to ?? DateTime.MaxValue.AddYears(-1), isDeleted).ExecuteAndReturnResults().Select(x => new EventModel(x));
        }

        public IEnumerable<EventModel> GetByDates(DateTimeOffset? begins = null, DateTimeOffset? ends = null, bool isDeleted = false)
        {
            begins = begins ?? DateTime.Now;
            return new Query.Events.GetAll(_context, begins.Value, ends, isDeleted).ExecuteAndReturnResults().Select(x => new EventModel(x));
        }

        public EventModel Upsert(EventModel model)
        {
            return new EventModel(new Command.Events.Upsert(_context, _user, model.ToModel()).ExecuteAndReturnResults());
        }

        public void Delete(int id)
        {
            new Command.Events.DeleteRestore(_context, _user, id, false).Execute();
        }

        public void Restore(int id)
        {
            new Command.Events.DeleteRestore(_context, _user, id, true).Execute();
        }
    }
}
