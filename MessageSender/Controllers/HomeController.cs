using MessageSender.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace MessageSender.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        public IActionResult Index()
        {
            return View(new MessageModel());
        }
        [HttpPost]
        public IActionResult Index(MessageModel model)
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            //string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            //string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(_appSettings.appSettingsTwillio.accountSid) && string.IsNullOrEmpty(_appSettings.appSettingsTwillio.authToken) && string.IsNullOrEmpty(_appSettings.appSettingsTwillio.TwilloNumber))
                {
                    return Json("Please enter Twillio AccountSid and AothToken and twillio Mobile Number" );

                }

                TwilioClient.Init(_appSettings.appSettingsTwillio.accountSid, _appSettings.appSettingsTwillio.authToken);

                try
                {
                    var message = MessageResource.Create(
                        body: model.MessageText,
                        from: new Twilio.Types.PhoneNumber(_appSettings.appSettingsTwillio.TwilloNumber),
                        to: new Twilio.Types.PhoneNumber("+"+model.MobileNumber)
                    );
                }
                catch(Exception e)
                {
                    return Json(e.Message);
                   
                }
                return Json("Success");

            }
            return Json("Validation error" );

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}