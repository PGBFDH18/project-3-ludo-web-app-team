info:
  version: "1.0.0"
  title: LudobrowserDoc
  server: https://http://localhost:51489/ 
paths:
  Ludo/:
    get:
      description: Gets all current games that has been created.
      responses:
        '200':
          description: OK, Returns all games ID available.
          schema:
            context: text/json
            type: String
  ludo/newgame:
    get: 
      description: Sends a post request to API and gets a new gameID
      responses:
        '200':
          description: OK, new game created
          
  ludo/game/{gameid}:
    get: 
      description: Gets back a specific game 
      responses:
        '200':
          description: OK, Returns back specific game.
          
  ludo/delete/{gameid}:
    delete: 
      description: Deletes an existing game
      responses:
        '200':
          description: OK
  startgame/{gameid}:
    get:
      description: Adds player to a specific game and then starts the game
      responses:
        '200':
          description: OK
  move/{gameid}:
    get:
      description: Sends a put request to Api Moves and moves a specific chosen piece
      responses:
        '200':
          description: Ok
        

