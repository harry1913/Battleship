/*
    Class  : GameController
    Author : Sangyeo(Harry) Kim
    Date   : 28/2/19
    Content: control this game, model, and view
 */
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Battleship.com.model;
using Battleship.com.view;

namespace Battleship.com.controller
{
    class GameController
    {
        private GameData gameData;              // set the game data
        private GameDisplay gameDisplay;        // set the game view
        private WordFactory wordFactory;        // set the language of the game

        private string[, ] initBoard;
        private List<Player> playerList;

        private int errorCounter    =   5;      // if a user inputs a wrong data, the limit is '5'

        /* initialization : Initializaing this game data */
        public bool initialization()
        {

            int x           = 10;
            int y           = 10;

            gameData        = new GameData();
            wordFactory     = new WordFactory();
            gameDisplay     = new GameDisplay(x, y);
            initBoard       = new String[x, y];

            /* initializaing a player board */
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    initBoard[i, j]    = "";
            
            return true;
        }

        /* startUp : Set and start up the game */
        private void startUp() 
        {
            Console.Write(wordFactory.des_Welcome);
            
            /* before start the game, given parameters from a user */
            if(modeSelection() && setUpShips() && placeShipsOnBoard())
            {
                /* Start game with the parameter */
                startGame();
            }
            else
            {
                goodBye();
            }

        }

        /* modeSelection : User can selct a game mode (1 vs 2 or 1 vs computer - 1 vs computer is not realized) */
        private bool modeSelection()
        {
            // Console.Clear();

            int mode;
            int errcounter = errorCounter;
            do
            {
                Console.Write(wordFactory.des_ModeSelection);
                if(int.TryParse(Console.ReadLine(), out mode) && mode == (int) GameData.Mode.p1VersusP2)
                {
                    /* game player set up (player vs computer mode is not realized) */
                    gameData.playMode   = mode;
                    playerList          = new List<Player>();
                    /* set up an initial player data */
                    for (int i = 0; i < gameData.playMode; i++)
                    {
                        Player p        = new Player("Player " + (i + 1), initBoard.Clone() as String[, ]);
                        playerList.Add(p);
                    }
                    return true;
                }
               errcounter--;
            } 
            while (errcounter > 0);
            
            return false;
        }

        /* setUpShips : set up battleships */
        private bool setUpShips()
        {
            Console.Clear();
            Console.Write(wordFactory.des_SetUpShips);

            int shipCount;

            /* Set up the count of battleships */
            if(int.TryParse(Console.ReadLine(), out shipCount))
            {
                int n           = 0;
                int errCounter  = 0;

                Console.Write(wordFactory.des_SetUpShipsLength);
                gameData.battleShipSizes = new int[shipCount];
                
                /* Set up each ship's length */
                do
                {
                    Console.Write("  " + (n + 1) + wordFactory.des_EachShipsLength);
                    if(int.TryParse(Console.ReadLine(), out gameData.battleShipSizes[n]))
                    {
                        shipCount--;
                        n++;
                    }
                    else
                    {
                        Console.Write(wordFactory.des_EachShipsLengthErr);
                        errCounter++;
                    }
                    
                    if (errCounter >= errorCounter) return false;

                }
                while(shipCount > 0);

                return true;
            }            
            return false;
        }
        /* fireInputValidation */
        private bool fireInputValidation(string input)
        {
            string pattern   = @"";
                    pattern += "([A-Z])([0-9])";
                    pattern += "|([a-z])([0-9])";
                    pattern += "|([0-9])([A-Z])";
                    pattern += "|([0-9])([a-z])";
                    pattern += "|([A-Z])([1])([0])";
                    pattern += "|([a-z])([1])([0])";
                    pattern += "|([1])([0])([a-z])";
                    pattern += "|([1])([0])([A-Z])";

            Match m          = Regex.Match(input, pattern);
            if (m.Success)
                return true;

            Console.WriteLine(wordFactory.des_InputErr);
            return false;
        }
        /* coordinateValidation : validated a user input with Regex */
        private bool coordinateValidation(string input)
        {

            string pattern   = @"";
                    pattern += "([A-Z])([0-9])\\s([v|h])";
                    pattern += "|([a-z])([0-9])\\s([v|h])";
                    pattern += "|([0-9])([A-Z])\\s([v|h])";
                    pattern += "|([0-9])([a-z])\\s([v|h])";
                    pattern += "|([A-Z])([1])([0])\\s([v|h])";
                    pattern += "|([a-z])([1])([0])\\s([v|h])";
                    pattern += "|([1])([0])([a-z])\\s([v|h])";
                    pattern += "|([1])([0])([A-Z])\\s([v|h])";
            
            Match m          = Regex.Match(input, pattern);
            if (m.Success)
            {
                string[] split  = Regex.Split(input, "\\s");
                if (split[1].Length > 1)
                    return false;

                return true;
            }

            Console.WriteLine(wordFactory.des_InputErr);
            return false;
        }

        /* placeShipsOnBoard : place player's ships on player's board */
        private bool placeShipsOnBoard()
        {
            Console.Clear();
            
            int mode            = 0;
            int prefix          = 0;
            int errCounter      = 0;

            string shipName     = "";
            string userInput    = "";

            string[] input;

            if(gameDisplay.displayGrid("Initial Board", initBoard))         // show a example matrix to support the selection of ships' position
            {
                mode    = (int) GameData.Mode.p1VersusP2;               // check a mode
                if (gameData.playMode == mode)                          
                {
                    for (int i = 0; i < playerList.Count; i++)              // check a player counter
                    {   
                        Console.Write(playerList[i].Name + wordFactory.des_PlaceShips);
                        prefix    = (int) GameData.columnStart.A + 1;
                        
                        playerList[i].playerBattleShips = new Dictionary<string, string>();

                        for (int j = 0; j < gameData.battleShipSizes.Count(); j++)
                        {
                            shipName        = ((char) (prefix + j)).ToString() + gameData.battleShipSizes[j];      // generate a ship's name (start from 'A' + 'ship's lenght')
                            errCounter      = 0;
                            do
                            {
                                Console.Write("  "+ shipName + wordFactory.des_LocatedShips);
                                userInput       = Console.ReadLine();
                                
                                errCounter++;
                                if(errCounter == errorCounter)
                                    goodBye();
                                

                            }
                            while(!coordinateValidation(userInput));        // check a user input 
                            
                            input           = Regex.Split(userInput, "\\s");   // split a user input by a space
                            playerList[i]   = gameDisplay.placeShipsOnBaord(input[0], input[1], gameData.battleShipSizes[j], shipName, playerList[i]);
                            
                            if(!playerList[i].playerErr)
                            {
                                Console.Clear();
                                gameDisplay.displayGrid(playerList[i].Name, playerList[i].playerBoard);
                            }
                            else
                            {
                                
                                j = (j == 0) ? -1 : j - 1;      // if get a error, try to ask the position again
                                
                                errCounter++;
                                if(errCounter == errorCounter)
                                    goodBye();
                            }

                        }
                        Console.Clear();
                        gameDisplay.displayGrid("Initial Board", initBoard);
                    }
                
                }
                return true;
            }

            return false;
        }

        /* fire : given a target coordinate and judge its attack 'hit' or 'miss' */
        private int fire(Player _player, string name)
        {
            string target       = "";
            string cell         = "";
            string value        = "";
            int restShips       = _player.playerBattleShips.Count();        // total battleships on each player board
            int currentShips    = 0;

            Console.Write(name + wordFactory.des_Attack);

            try
            {
                cell        = Console.ReadLine();
                if (cell != null && fireInputValidation(cell))
                {
                    target      = gameDisplay.shipKeyGenerator(cell);               // change a user input to a key

                    if(_player.playerBattleShips.ContainsKey(target))               // find the key in shipsinfo
                    {
                        /* a player hit an opponent  */
                        currentShips    = 0;
                        Console.WriteLine(wordFactory.des_AttackHit);

                        value           = _player.playerBattleShips[target];        // get Ship's name 
                        _player.playerBattleShips.Remove(target);                   // delete the ship form total batlleships 

                        currentShips    = _player.playerBattleShips                 // count the rest of battleships 
                                            .Select(m => m)
                                                .Where(k => k.Value.Equals(value))
                                                .Count();
                        restShips --;                   

                        /* if the count of the ship in the total battlships list is '0' that means the player distoried the ship */
                        if (currentShips == 0)
                            Console.WriteLine(value + wordFactory.des_AttackSunk);

                        /* if the count of total battleship is '0', it is win */
                        if(restShips == 0) 
                            return 0;
                    }
                    else
                    {
                        /* a player miss an opponent  */
                        Console.WriteLine(wordFactory.des_AttackMiss);
                    }  

                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Opps! \n " + e);
                System.Environment.Exit(1);
            }


            return restShips;
        }

        /* startGame : given target coodinates from users */
        private void startGame()
        {
            
            bool flag       = true;             // check next turn
            int restShipsP1 = 0;                // the rest of battleships (win point that should be '0')
            int restShipsP2 = 0;

            /* loop for user input (attacking) */
            do
            {
                if (flag)
                {
                    /* Player 1 turn */
                    restShipsP1 = fire(playerList[1], playerList[0].Name);
                    if (restShipsP1 == 0)
                    {
                        Console.WriteLine(playerList[0].Name +  wordFactory.des_AttackWin);
                        goodBye();
                    }
                    flag    = false;
                }
                else
                {
                    /* Player 2 turn */
                    restShipsP2 = fire(playerList[0], playerList[1].Name);
                    if (restShipsP2 == 0)
                    {
                        Console.WriteLine(playerList[1].Name +  wordFactory.des_AttackWin);
                        goodBye();
                    }
                    flag    = true;
                }

            }
            while (restShipsP1 > 0 || restShipsP2 > 0);

        }

        /* goodBye : Close console application */
        private void goodBye()
        {
            Console.WriteLine("Thank you for enjoying this game!");
            System.Environment.Exit(1);
        }

        /* run : Initialziation and set up the battleship game*/
        public void run()
        {
            if(initialization())
                startUp();
            else
                goodBye();
        }
    }
}
