using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Access.Queries.Locations;
using Naspinski.FoodTruck.Data.Models.Events;
using Naspinski.Maps.Implementations.Google;
using Naspinski.Maps.Interfaces;

namespace Naspinski.FoodTruck.Data.Access.Commands.Locations
{
    public class Upsert : ResultCommandBase<FoodTruckContext, Location>
    {
        private readonly Location _model;

        public Upsert(FoodTruckContext context, string user, Location model) : base(context, user)
        {
            _model = model;
        }

        protected override Location InternalExecute()
        {
            var isNew = _model.Id == 0;

            var upsert = isNew ? new Location() : new Get(_context, _model.Id).ExecuteAndReturnResults();

            SetLatLon();

            upsert.Name = _model.Name;
            upsert.Address = _model.Address;
            upsert.City = _model.City;
            upsert.State = _model.State;
            upsert.Zip = _model.Zip;
            upsert.Latitude = _model.Latitude;
            upsert.Longitude = _model.Longitude;

            if (isNew)
            {
                upsert.Create(_user);
                _context.Locations.Add(upsert);
            }
            else upsert.Update(_user);

            _context.SaveChanges();
            return upsert;
        }

        private void SetLatLon()
        {
            if (string.IsNullOrWhiteSpace(_model.GoogleMapsApiKey)) return;
            IMap map = new GoogleMap(_model.GoogleMapsApiKey);
            var address = map.GetAddress($"{_model.Address}, {_model.City}, {_model.State} {_model.Zip}");

            _model.Latitude = address.Location.Latitude;
            _model.Longitude = address.Location.Longitude;
        }
    }
}
