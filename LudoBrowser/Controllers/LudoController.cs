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


        /*
           var request = new RestRequest("/ludo" + GameID + "/players", Method.POST);



           LudoBrowser.Models.LudoPlayer player = new LudoBrowser.Models.LudoPlayer()
           {

           };


           request.RequestFormat = DataFormat.Json;
           request.AddBody(player);

           IRestResponse addPlayer = client.Execute(request);
           var playerCreateResponse = addPlayer.ResponseStatus;

           var getGamePlayer = new RestRequest("/Ludo/" + GameID + "/players", Method.GET);

           IRestResponse<List<LudoPlayer>> playerResponse = client.Execute<List<LudoPlayer>>(getGamePlayer);


           var playeradd = playerResponse.Data;
           playeradd.ToString();
           if (playerCreateResponse == ResponseStatus.Completed)

               return "New player has been added and game started!";
           else
               return "Write your Name and choose your Color!";*/




        [Route("/game/{gameId}")]
        public IActionResult GameInformation(int gameID)
        {
            var getGameInformation = new RestRequest("/Ludo/" + gameID, Method.GET);

            IRestResponse<GameModel> ludoGameResponse = Client.Execute<GameModel>(getGameInformation);
            ViewData.Model = ludoGameResponse.Data;
            return View();
        }

    }

}


