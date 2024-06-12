namespace FizzBuzzApp.Interfaces
{
    using FizzBuzzApp.Models;

    public interface IFizzBuzzService
    {
        FizzBuzzResponse ProcessValues(string[] values);
    }
}
