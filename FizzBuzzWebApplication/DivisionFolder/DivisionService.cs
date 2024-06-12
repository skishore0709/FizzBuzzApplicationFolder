namespace FizzBuzzApp.DivisionFolder
{
    public class DivisionService : IDivisionService
    {
        public string[] DivideBy(int number, params int[] divisors)
        {
            var results = new List<string>();

            foreach (var divisor in divisors)
            {
                results.Add($"Divided {number} by {divisor}");
            }

            return results.ToArray();
        }
    }
}
