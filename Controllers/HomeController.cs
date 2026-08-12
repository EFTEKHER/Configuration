using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Configuration.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IConfiguration _configuration;
        private readonly WeatherApiOptions _options; 
        private readonly MyKeyOptions _myKeyOptions;
        //public HomeController(IConfiguration configuration)
        public HomeController(IOptions <WeatherApiOptions> options, IOptions<MyKeyOptions> myKeyOptions)
        {
            _options=options.Value;
            _myKeyOptions=myKeyOptions.Value;
        }
        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.MyKey = _configuration["MyKey"];
            //ViewBag.MyKeyValue = _configuration.GetValue<string>("MyKey");
            //ViewBag.MyKeyValueWithDefault = _configuration.GetValue<int>("x", 10);

            ViewBag.MyKey = _myKeyOptions.MyKey;
            ViewBag.MyKeyValue = _myKeyOptions.MyKey;
            ViewBag.MyKeyValueWithDefault = _myKeyOptions.X;
            //ViewBag.WeatherClientID= _configuration["weatherapi:ClientId"];
            //ViewBag.WeatherClientSecret= _configuration["weatherapi:ClientSecret"];
            //ViewBag.ClientID=_configuration.GetSection("weatherapi")["ClientId"];
            //ViewBag.ClientSecret=_configuration.GetSection("weatherapi")["ClientSecret"];
            //IConfiguration weatherapiSection = _configuration.GetSection("weaterapi");
            //ViewBag.wa=weatherapiSection;
            //WeatherApiOptions? options= _configuration.GetSection("weatherapi").Get<WeatherApiOptions>();

            //WeatherApiOptions? options = new WeatherApiOptions();
            //_configuration.GetSection("weatherapi").Bind(options);
            ViewBag.ClientID= _options?.ClientId;
            ViewBag.ClientSecret= _options?.ClientSecret;
            //program section  configuaration values into a new options object;
            //Bind:Loads configuration values into existing object 
            return View();
        }
    }
}
