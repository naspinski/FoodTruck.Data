using Naspinski.Data.CommandQuery.Base;
using Naspinski.FoodTruck.Data.Models.System;
using System.Collections.Generic;
using System.Linq;

namespace Naspinski.FoodTruck.Data.Access.Queries.Subscriptions
{
    public class GetAll : ResultQueryBase<FoodTruckContext, List<Subscription>>
    {
        private readonly bool? _isEmail;
        public IEnumerable<string> _locations;
        public string _subscriber;

        public GetAll(FoodTruckContext context, bool? isEmail = null, IEnumerable<string> locations = null, string subscriber = "") : base(context)
        {
            _isEmail = isEmail;
            _locations = locations?.Select(x => Subscription.SanitizeLocation(x)).Distinct() ?? null;
            _subscriber = subscriber.ToLower().Trim();
        }

        protected override List<Subscription> InternalExecute()
        {
            return _context.Subscriptions.Where(x =>
                (_isEmail == null
                    || x.Type == (_isEmail.Value ? Subscription.Types.Email : Subscription.Types.Text)
                ) && (_locations == null
                    || _locations.Any(y => y.StartsWith(x.Location))
                ) && (string.IsNullOrWhiteSpace(_subscriber)
                    || x.Subscriber == _subscriber
                )
            ).ToList();
        }
    }
}
