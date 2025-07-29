using Playground.Common;

namespace Playground.OutputHandler
{
    public static class OutputHandler
    {
        public static void PrintRates(IEnumerable<Events> rates)
        {
            if (rates == null || !rates.Any())
            {
                Console.WriteLine("No rates were found for the given locations.");
                return;
            }

            foreach (var rate in rates)
            {
                Console.WriteLine($"----");
                Console.WriteLine($"RateID: {rate.Data.ID}");
                Console.WriteLine($"Cost: {rate.Data.Cost}");
            }
        }
    }
}
