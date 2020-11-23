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
    public class ClaimAuthController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ClaimAuthController));
        public IActionResult GetById()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> GetById(Claim c)
        {
            if (HttpContext.Session.GetString("token") == null)
            {

                return RedirectToAction("Login", "Login");

            }
            else
            {
                _log4net.Info("Getting Bill Amount");
                using (var client = new HttpClient())
                {
                   
                    var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);

                    client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                    using (var response = await client.GetAsync("https://localhost:44326/api/ClaimAuth/"+c.Id))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            Double apiResponse = Double.Parse(await response.Content.ReadAsStringAsync());
                            //Bill b = JsonConvert.DeserializeObject<>(apiResponse);
                            ViewBag.amount = apiResponse;
                            return View("GetBilling");
                        }
                        else
                        {
                            _log4net.Info("No Record Found");
                            return RedirectToAction("AddClaimDetails");
                        }

                    }


                }

            }

        }
    }
}
