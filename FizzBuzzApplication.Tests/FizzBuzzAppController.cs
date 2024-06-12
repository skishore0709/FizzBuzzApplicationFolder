using FizzBuzzApp.Controllers;
using FizzBuzzApp.Interfaces;
using FizzBuzzApp.Models;
using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using FizzBuzzApp.FizzBuzzAppServiceFolder;

namespace FizzBuzzApp.Tests
{
    public class FizzBuzzAppControllerTests
    {
        private FizzBuzzAppController _controller;
        private Mock<IFizzBuzzService> _mockService;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IFizzBuzzService>();
            _controller = new FizzBuzzAppController(_mockService.Object);
        }

        [Test]
        public void Post_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var request = new FizzBuzzRequest { RequestingValues = new[] { "3", "5", "15" } };
            var response = new FizzBuzzResponse { ResponseValues = new List<string> { "Fizz", "Buzz", "FizzBuzz" } };
            _mockService.Setup(service => service.ProcessValues(request.RequestingValues)).Returns(response);

            // Act
            var result = _controller.Post(request);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(response, okResult.Value);
        }


        [Test]
        public void Post_EmptyRequest_ReturnsEmptyResponse()
        {
            // Arrange
            var request = new FizzBuzzRequest { RequestingValues = new string[0] };
            var response = new FizzBuzzResponse { ResponseValues = new List<string>() };
            _mockService.Setup(service => service.ProcessValues(request.RequestingValues)).Returns(response);

            // Act
            var result = _controller.Post(request);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(response, okResult.Value);
        }

        [Test]
        public void Post_AllDivisibleBy3_ReturnsFizzForAll()
        {
            // Arrange
            var request = new FizzBuzzRequest { RequestingValues = new[] { "3", "6", "9" } };
            var response = new FizzBuzzResponse { ResponseValues = new List<string> { "Fizz", "Fizz", "Fizz" } };
            _mockService.Setup(service => service.ProcessValues(request.RequestingValues)).Returns(response);

            // Act
            var result = _controller.Post(request);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(response, okResult.Value);
        }

        [Test]
        public void Post_AllDivisibleBy5_ReturnsBuzzForAll()
        {
            // Arrange
            var request = new FizzBuzzRequest { RequestingValues = new[] { "5", "10", "20" } };
            var response = new FizzBuzzResponse { ResponseValues = new List<string> { "Buzz", "Buzz", "Buzz" } };
            _mockService.Setup(service => service.ProcessValues(request.RequestingValues)).Returns(response);

            // Act
            var result = _controller.Post(request);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(response, okResult.Value);
        }

        [Test]
        public void Post_AllDivisibleBy3And5_ReturnsFizzBuzzForAll()
        {
            // Arrange
            var request = new FizzBuzzRequest { RequestingValues = new[] { "15", "30", "45" } };
            var response = new FizzBuzzResponse { ResponseValues = new List<string> { "FizzBuzz", "FizzBuzz", "FizzBuzz" } };
            _mockService.Setup(service => service.ProcessValues(request.RequestingValues)).Returns(response);

            // Act
            var result = _controller.Post(request);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(response, okResult.Value);
        }

        [Test]
        public void Post_InvalidRequest_ReturnsInvalidItem()
        {
            // Arrange
            var request = new FizzBuzzRequest { RequestingValues = new[] { "abc" } };
            var response = new FizzBuzzResponse { ResponseValues = new List<string> { "Invalid item" } };
            _mockService.Setup(service => service.ProcessValues(request.RequestingValues)).Returns(response);

            // Act
            var result = _controller.Post(request);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(response, okResult.Value);
        }
    }
}
