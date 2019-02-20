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

        [HttpGet("{gameId}")]
        public string addplayer()
        {

            return null;
        }
        [Route("/delete/{gameID}")]
        public IActionResult delete(int gameID)
        {
            var getGameInformation = new RestRequest("/Ludo/" + gameID, Method.DELETE);

            IRestResponse<GameModel> ludoGameResponse = Client.Execute<GameModel>(getGameInformation);

            return Redirect("/");
        }
        [HttpGet("/startgame/{gameID}")]
        public IActionResult startgame(int gameID, string name1, string name2, string name3, string name4)
        {


            //List<string> PlayerNames = new List<string>() { name1, name2, name3, name4 };   
            if (name1 != null)
            {

                LudoPlayer player = new LudoPlayer()
                {
                    Color = "red",
                    Id = 0,
                    Name = name1
                };
                addUser(gameID, player);
            }
            if (name2 != null)
            {

                LudoPlayer player = new LudoPlayer()
                {
                    Color = "yellow",
                    Id = 1,
                    Name = name2
                };
                addUser(gameID, player);
            }
            if (name3 != null)
            {

                LudoPlayer player = new LudoPlayer()
                {
                    Color = "green",
                    Id = 2,
                    Name = name3
                };
                addUser(gameID, player);
            }
            if (name4 != null)
            {
                LudoPlayer player = new LudoPlayer()
                {
                    Color = "blue",
                    Id = 3,
                    Name = name4
                };
                addUser(gameID, player);
            }
            var request = new RestRequest("/ludo/" + gameID + "/players", Method.GET);

            IRestResponse<List<LudoPlayer>> PlayersListResponse = Client.Execute<List<LudoPlayer>>(request);
            List<LudoPlayer> Playerlist = PlayersListResponse.Data;
            Playerlist.ToString();
            ViewBag.gameID = gameID;
            return View(Playerlist);
        }
        private void addUser(int gameID, LudoPlayer player)
        {
            var request = new RestRequest("/ludo/" + gameID + "/players", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(player);
            IRestResponse addPlayer = Client.Execute(request);
            addPlayer.ToString();
        }
        [HttpGet("/move/{gameID}")]
        public void PlayGame(int gameID, int numberoffield, int pieceid, int playerid)
        {
            var request = new RestRequest("/ludo/" + gameID, Method.PUT);
            MovePiece movePiece = new MovePiece()
            {
                NumberOfFields = 6,
                PieceId = 0,
                PlayerId = 0,
            };
            request.RequestFormat = DataFormat.Json;
            request.AddBody(movePiece);
            IRestResponse restResponse = Client.Execute(request);

        }
    }

}