using FizzBuzzApp.Interfaces;
using FizzBuzzApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzBuzzAppController : ControllerBase
    {
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzAppController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpPost]
        public ActionResult<FizzBuzzResponse> Post([FromQuery] FizzBuzzRequest request)
        {
            var result = _fizzBuzzService.ProcessValues(request.RequestingValues);
            return Ok(result);
        }
    }
}
