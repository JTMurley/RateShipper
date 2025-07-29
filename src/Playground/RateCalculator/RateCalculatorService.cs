using Playground.Common;

namespace Playground.RateCalculator
{
    public class RateCalculatorService : IRateCalculatorService
    {
        public IEnumerable<Events> GetRatesForLocation(double weight, int fromPostCode, int toPostCode, IEnumerable<Events> events)
        {
            var fromZone = GetDeliveryZone(fromPostCode, events);
            var toZone = GetDeliveryZone(toPostCode, events);

            if (fromZone == null || toZone == null)
            {
                return Enumerable.Empty<Events>();
            }

            var locationId = GetLocationId(fromZone, toZone);

            var matchingLocations = GetMatchingLocations(weight, locationId, events);

            return matchingLocations;
        }

        /// <summary>
        /// Gets the delivery zone based on the postcode and events.
        /// </summary>
        /// <param name="postCode"></param>
        /// <param name="events"></param>
        /// <returns>zThe delivery zone that the package can be sent to or null if no zone exists</returns>
        private Events? GetDeliveryZone(int postCode, IEnumerable<Events> events)
        {
            var deliveryZone = events
                .Where(x => x.Event == Constants.ZoneDefinedEvent)
                .Where(x => x.Data.PostCodes.Contains(postCode))
                .FirstOrDefault();

            return deliveryZone;
        }

        /// <summary>
        /// Gets the location ID based on the from and to zones.
        /// </summary>
        /// <param name="fromZone"></param>
        /// <param name="toZone"></param>
        /// <returns>The partial location ID with the weight left off</returns>
        private string GetLocationId(Events fromZone, Events toZone)
        {
            return $"{fromZone.Data.Name}-{toZone.Data.Name}";
        }

        /// <summary>
        /// Gets the matching locations based on the weight and location ID.
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="locationId"></param>
        /// <param name="events"></param>
        /// <returns>A list of all matching locations</returns>
        private IEnumerable<Events> GetMatchingLocations(double weight, string locationId, IEnumerable<Events> events)
        {
            var matchingLocations = events
                .Where(x => x.Event == Constants.RateDefinedEvent)
                .Where(x => x.Data.ID.Contains(locationId))
                .Where(x => weight < x.Data.MaxWeight);

            return matchingLocations;
        }
    }
}
