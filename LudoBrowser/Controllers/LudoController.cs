using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LudoBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;


namespace LudoBrowser.Controllers
{
    public class LudoController : Controller
    {
        [Route("/ludo")]

        public IActionResult Welcome()
        {
            return View();
        }


        [HttpGet("/ludo/board")] 

        public IActionResult Index()
        {
            return View();
        }
                                        
                                        
        [HttpGet("/newgame")]
        public string NewGame()
        {
            var client = new RestClient("http://localhost:51489/api");

            var getGameID = new RestRequest("/ludo", Method.POST);
            
            IRestResponse<int> ludoGameResponse = client.Execute<int>(getGameID, Method.POST);
            var GameID = ludoGameResponse.Data;

            var request = new RestRequest("/ludo" + GameID + "/players", Method.POST);



            IRestResponse addPlayer = client.Execute(request);
            var playerCreateResponse = addPlayer.ResponseStatus;

            var getGamePlayer = new RestRequest("/Ludo/" + GameID + "/players", Method.GET);

            IRestResponse<List<LudoPlayer>> playerResponse = client.Execute<List<LudoPlayer>>(getGamePlayer);

         

            var playeradd = playerResponse.Data;
            playeradd.ToString();

            if (playerCreateResponse == ResponseStatus.Completed)

                return "New player has been added and game started!";
            else
                return "Write your Name and choose your Color!";
           
                

        }

        [HttpPost("/addplayer")]
            public string addplayer()
            {
            return null;
            }
    }

}


