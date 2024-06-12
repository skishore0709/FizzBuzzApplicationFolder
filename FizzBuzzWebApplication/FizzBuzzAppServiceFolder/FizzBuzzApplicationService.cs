using FizzBuzzApp.DivisionFolder;
using FizzBuzzApp.Interfaces;
using FizzBuzzApp.Models;
using System.Collections.Generic;

namespace FizzBuzzApp.FizzBuzzAppServiceFolder
{
    public class FizzBuzzService : IFizzBuzzService
    {

        private readonly IDivisionService _divisionService;


        public FizzBuzzService(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }

        public FizzBuzzResponse ProcessValues(string[] values)
        {
            var result = new FizzBuzzResponse { ResponseValues = new List<string>() };

            foreach (var value in values)
            {
                if (int.TryParse(value, out int number))
                {
                    bool divisibleBy3 = number % 3 == 0;
                    bool divisibleBy5 = number % 5 == 0;

                    if (divisibleBy3 && divisibleBy5)
                    {
                        result.ResponseValues.Add(FizzBuzzConstants.FizzBuzz);
                    }
                    else if (divisibleBy3)
                    {
                        result.ResponseValues.Add(FizzBuzzConstants.Fizz);
                    }
                    else if (divisibleBy5)
                    {
                        result.ResponseValues.Add(FizzBuzzConstants.Buzz);
                    }
                    else
                    {
                        AddDividedByResults(result, number);

                    }
                }
                else
                {
                    result.ResponseValues.Add(FizzBuzzConstants.Invalid_Item);
                }
            }
            return result;
        }

        private void AddDividedByResults(FizzBuzzResponse result, int number)
        {
            var dividedResults = _divisionService.DivideBy(number, 3, 5);
            result.ResponseValues.AddRange(dividedResults);
        }
    }
}
