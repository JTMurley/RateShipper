using Playground.Common;

namespace Playground.RateCalculator
{
    /// <summary>
    /// Service for generating rates based on weight and postcodes.
    /// </summary>
    public interface IRateCalculatorService
    {
        /// <summary>
        /// Gets a list of rates for a given weight and postcode based off of the event data
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="fromPostCode"></param>
        /// <param name="toPostCode"></param>
        /// <param name="events"></param>
        /// <returns>A list of events that you can ship a package to. Note it returns null if no suitable rate was found for the location</returns>
        IEnumerable<Events> GetRatesForLocation(double weight, int fromPostCode, int toPostCode, IEnumerable<Events> events);
    }
}