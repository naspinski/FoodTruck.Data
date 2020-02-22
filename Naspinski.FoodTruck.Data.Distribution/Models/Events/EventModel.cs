using Naspinski.Data.Interfaces;
using Naspinski.FoodTruck.Data.Models.Events;
using System;
using System.ComponentModel.DataAnnotations;

namespace Naspinski.FoodTruck.Data.Distribution.Models.Events
{
    public class EventModel : IToModel<Event>
    {
        private const string MONTH = "MMM";
        private const string DAY = "dd";
        private const string TIME = "hh:mm tt";

        [Required]
        public int Id { get; set; }
        public bool IsNew { get { return Id == 0; } }

        [Required]
        public DateTime Begins { get; set; }
        public string BeginsMonth { get { return Begins.ToString(MONTH); } }
        public string BeginsDay { get { return Begins.ToString(DAY); } }
        public string BeginsTime { get { return Begins.ToString(TIME); } }

        public DateTime? Ends { get; set; }
        public string EndsTime { get { return Ends.HasValue ? Ends.Value.ToString(TIME) : string.Empty; } }

        [Required]
        public int LocationId { get; set; }
        public LocationModel Location { get; set; }
        public bool IsDeleted { get; set; }

        public EventModel() { }

        public EventModel(Event model)
        {
            Id = model.Id;
            Begins = model.Begins.DateTime;
            Ends = model.Ends.HasValue ? model.Ends.Value.DateTime : (DateTime?)null;
            LocationId = model.LocationId;
            Location = model.Location == null ? new LocationModel() : new LocationModel(model.Location);
            IsDeleted = model.Deleted != null;
        }

        public Event ToModel()
        {
            return new Event()
            {
                Id = Id,
                Begins = Begins,
                Ends = Ends,
                LocationId = LocationId
            };
        }
    }
}
