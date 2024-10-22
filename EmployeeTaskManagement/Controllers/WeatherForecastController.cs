using EmployeeTaskManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceEmployeeTask.Interfaces;

namespace EmployeeTaskManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IAccountService _accountService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IAccountService account)
        {
            _logger = logger;
            _accountService = account;
        }

        [Authorize]
        [HttpPost]
        [Route("AddNewBrand")]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {

                //_accountService.Login(loginModel);
                return Ok("Brand Added Successfully");
            }
            catch (Exception)
            {
                return BadRequest("Brand Already Exist.");
            }
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
