using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.InputHandler
{
    public static class InputHandler
    {
        public static double GetWeight(string input)
        {
            Console.WriteLine(input);
            var userInput = Console.ReadLine();
            var weight = double.TryParse(userInput, out double parsedWeight);

            if (!weight)
            {
                Console.WriteLine("Invalid weight. Please enter a valid weight such as 1.2 .");
                GetWeight(input);
            }

            return parsedWeight;
        }

        public static int GetPostCode(string input)
        {
            Console.WriteLine(input);
            var userInput = Console.ReadLine();
            var postCode = int.TryParse(userInput, out int parsedPostCode);

            if (!postCode)
            {
                Console.WriteLine("Invalid postcode. Please enter a valid postcode as an integer such as 3000.");
                GetPostCode(input);
            }

            return parsedPostCode;
        }
    }
}
