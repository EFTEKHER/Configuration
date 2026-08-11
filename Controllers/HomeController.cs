using Microsoft.AspNetCore.Mvc;

namespace Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.MyKey = _configuration["MyKey"];
            ViewBag.MyKeyValue = _configuration.GetValue<string>("MyKey");
            ViewBag.MyKeyValueWithDefault = _configuration.GetValue<int>("x", 10);
            //ViewBag.WeatherClientID= _configuration["weatherapi:ClientId"];
            //ViewBag.WeatherClientSecret= _configuration["weatherapi:ClientSecret"];
            ViewBag.ClientID=_configuration.GetSection("weatherapi")["ClientId"];
            ViewBag.ClientSecret=_configuration.GetSection("weatherapi")["ClientSecret"];
            IConfiguration weatherapiSection = _configuration.GetSection("weaterapi");
            ViewBag.wa=weatherapiSection;

            return View();
        }
    }
}
