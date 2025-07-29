// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using Playground.Common;
using Playground.InputHandler;
using Playground.OutputHandler;
using Playground.RateCalculator;

IRateCalculatorService rateCalculatorService = new RateCalculatorService();

var events = JsonConvert.DeserializeObject<List<Events>>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "events.json")));

var weight = InputHandler.GetWeight("What is the weight of the package");
var fromPostCode = InputHandler.GetPostCode("From where is it being shipped");
var toPostCode = InputHandler.GetPostCode("To where is it being shipped");

var rates = rateCalculatorService.GetRatesForLocation(
    weight,
    fromPostCode,
    toPostCode,
    events
);

OutputHandler.PrintRates(rates);