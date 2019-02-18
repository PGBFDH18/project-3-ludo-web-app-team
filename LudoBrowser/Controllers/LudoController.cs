using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;


namespace LudoBrowser.Controllers
{
     [Route("api/ludo")]
    public class LudoController : Controller
    {
        private RestClient Client = new RestClient("http://localhost:51489/api");

        [Route("/ludo")]
        public IActionResult Welcome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("/newgame")]   
        public string Newgame()
        {
            var getGameID = new RestRequest("/Ludo", Method.POST);

            IRestResponse<int> ludoGameResponse = Client.Execute<int>(getGameID, Method.POST);
            var GameID = ludoGameResponse.Data;
            return GameID.ToString();
        }


    }

}


