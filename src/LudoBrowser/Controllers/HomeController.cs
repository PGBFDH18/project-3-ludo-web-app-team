using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LudoBrowser.Models;
using RestSharp;

namespace LudoBrowser.Controllers
{
    public class HomeController : Controller
    {
        private RestClient client = new RestClient(" http://localhost:51489/api");

        public IActionResult Index()
        {
            var getAllGamesList = new RestRequest("/ludo", Method.GET);


            IRestResponse<List<int>> ludoGameResponse = client.Execute<List<int>>(getAllGamesList);
            ViewBag.GameIDs = ludoGameResponse.Data;
            return View();
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
