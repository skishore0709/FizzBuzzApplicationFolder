namespace FizzBuzzApp.DivisionFolder
{
    public interface IDivisionService
    {
        string[] DivideBy(int number, params int[] divisors);
    }
}
