using ClaimWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClaimWebApplication.Controllers
{
    public class AuthController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            _log4net.Info("User Login");
            using (var httpClient = new HttpClient())
            {
                
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response1 = await httpClient.PostAsync("https://localhost:44367/api/Auth/Login", content1))
                {
                    if (!response1.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Login");
                    }

                    string apiResponse1 = await response1.Content.ReadAsStringAsync();

                    JWT jwt = JsonConvert.DeserializeObject<JWT>(apiResponse1);

                    HttpContext.Session.SetString("token", jwt.Token);
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
                    HttpContext.Session.SetInt32("Userid", user.Id);
                    HttpContext.Session.SetString("Username", user.Username);
                    ViewBag.Message = "User logged in successfully!";

                    return RedirectToAction("ShowList", "Claim");


                }
            }
        }
        public ActionResult Logout()
        {
            _log4net.Info("User Log Out");
            HttpContext.Session.Clear();
            // HttpContext.Session.SetString("user", null);

            return View("Login");
        }


    }
}
