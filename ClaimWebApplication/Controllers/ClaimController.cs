using ClaimWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClaimWebApplication.Controllers
{
    public class ClaimController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ClaimController));
        public IActionResult Sucess()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult ShowList()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("token") == null)
            {
                

                return RedirectToAction("Login");

            }
            else
            {
                _log4net.Info("Claimlist getting Displayed");

                List<Claim> ClaimList = new List<Claim>();
                using (var client = new HttpClient())
                {


                    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);

                    client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                    using (var response = await client.GetAsync("https://localhost:44329/api/Claim"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ClaimList = JsonConvert.DeserializeObject<List<Claim>>(apiResponse);
                    }
                }
                return View(ClaimList);

            }
        }
        [HttpGet]
        public IActionResult AddClaimDetails()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>AddClaimDetails(Claim c)
        {
            if (HttpContext.Session.GetString("token") == null)
            {

                return RedirectToAction("Login", "Login");

            }
            else
            {
                _log4net.Info("Adding Claim Details");
                using (var client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);

                    client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                    using (var response = await client.PostAsync("https://localhost:44329/api/Claim",content))
                    {
                        if(response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Sucess");
                        }
                        else
                        {
                            return RedirectToAction("AddClaimDetails");
                        }
                        
                    }


                }

            }

        }




    }
}
