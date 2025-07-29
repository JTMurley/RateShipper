using Playground.Common;
using Playground.RateCalculator;

namespace Playground.UnitTests
{
    [TestClass]
    public class RateCalculatorServiceTests
    {
        private readonly IRateCalculatorService _rateCalculatorService;
        public RateCalculatorServiceTests()
        {
            _rateCalculatorService = new RateCalculatorService();
        }

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void RateCalculatorService_MELBToSyd_Returns1Location()
        {
            //Arrange
            var testData = new List<Events>
            {
                new Events
                {
                    Event = "ZoneDefined",
                    Data = new Data
                    {
                        Name = "MEL",
                        PostCodes = new List<int> { 3000, 3001, 3002 }
                    }
                },
                new Events
                {
                    Event = "ZoneDefined",
                    Data = new Data
                    {
                        Name = "SYD",
                        PostCodes = new List<int> { 2000, 2001, 2002 }
                    }
                },
                new Events
                {
                    Event = "RateDefined",
                    Data = new Data
                    {
                        ID = "MEL-SYD-2kg",
                        MaxWeight = 2,
                        Cost = 2.5,
                        FromZone = "MEL",
                        ToZone = "SYD"
                    }
                }
            };

            //Act
            var rates = _rateCalculatorService.GetRatesForLocation(1.1, 3000, 2000, testData);

            //Assert
            Assert.IsTrue(rates.Any(), "Rates should not be empty");
            Assert.IsTrue(rates.Count() == 1, "There should be exactly one rate returned");
            Assert.IsTrue(rates.First().Data.ID == "MEL-SYD-2kg", "The rate ID should match the expected value");
        }

        [TestMethod]
        public void RateCalculatorService_MELBToSyd_WeightTooHigh_NoRateReturned()
        {
            // Arrange
            var testData = new List<Events>
            {
                new Events
                {
                    Event = "ZoneDefined",
                    Data = new Data
                    {
                        Name = "MEL",
                        PostCodes = new List<int> { 3000, 3001, 3002 }
                    }
                },
                new Events
                {
                    Event = "ZoneDefined",
                    Data = new Data
                    {
                        Name = "SYD",
                        PostCodes = new List<int> { 2000, 2001, 2002 }
                    }
                },
                new Events
                {
                    Event = "RateDefined",
                    Data = new Data
                    {
                        ID = "MEL-SYD-2kg",
                        MaxWeight = 2,
                        Cost = 2.5,
                        FromZone = "MEL",
                        ToZone = "SYD"
                    }
                }
            };

            // Act
            var rates = _rateCalculatorService.GetRatesForLocation(3.0, 3000, 2000, testData);

            // Assert
            Assert.IsFalse(rates.Any(), "No rates should be returned for weight > max weight");
        }

        [TestMethod]
        public void RateCalculatorService_InvalidPostcode_NoRateReturned()
        {
            // Arrange
            var testData = new List<Events>
            {
                new Events
                {
                    Event = "ZoneDefined",
                    Data = new Data
                    {
                        Name = "MEL",
                        PostCodes = new List<int> { 3000, 3001, 3002 }
                    }
                },
                new Events
                {
                    Event = "ZoneDefined",
                    Data = new Data
                    {
                        Name = "SYD",
                        PostCodes = new List<int> { 2000, 2001, 2002 }
                    }
                },
                new Events
                {
                    Event = "RateDefined",
                    Data = new Data
                    {
                        ID = "MEL-SYD-2kg",
                        MaxWeight = 2,
                        Cost = 2.5,
                        FromZone = "MEL",
                        ToZone = "SYD"
                    }
                }
            };

            // Act
            // Using a postcode not in either zone (e.g., 9999 and 8888)
            var rates = _rateCalculatorService.GetRatesForLocation(1.0, 9999, 8888, testData);

            // Assert
            Assert.IsFalse(rates.Any(), "No rates should be returned for unmatched postcodes");
        }
    }
}
