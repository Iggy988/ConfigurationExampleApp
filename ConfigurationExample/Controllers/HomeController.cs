using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        //private field
        //private readonly IConfiguration _configuration;
        private readonly WeatherApiOptions _options;
        //constructor (for DI)
        public HomeController(IOptions<WeatherApiOptions> weatherApiOptions)
        {
            _options = weatherApiOptions.Value;
        }

        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.ClientID = _configuration["weatherapi:ClientID"];
            //ViewBag.ClientSecret = _configuration.GetValue<string>("weatherapi:ClientSecret", "default secret key");
            //return View();

            //ViewBag.ClientID = _configuration.GetSection("weatherapi")["ClientID"];
            //ViewBag.ClientSecret = _configuration.GetSection("weatherapi")["ClientSecret"];
            //IConfigurationSection wheatherapiSection = _configuration.GetSection("weatherapi");

            //Get: Loads configuration values into new Options object
            //WeatherApiOptions options = _configuration.GetSection("weatherapi").Get<WeatherApiOptions>();

            //ViewBag.ClientID = wheatherapiSection["ClientID"];
            //ViewBag.ClientSecret = wheatherapiSection["ClientSecret"];

            //Bind: Loads configuration values into existing Options object
            //WeatherApiOptions options = new WeatherApiOptions();
            //_configuration.GetSection("weatherapi").Bind(options);

            ViewBag.ClientID = _options.ClientID;
            ViewBag.ClientSecret = _options.ClientSecret;

            return View();
        }
    }
}
