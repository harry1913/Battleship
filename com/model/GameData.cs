/*
    Class  : GameData
    Author : Sangyeo(Harry) Kim
    Date   : 28/2/19
    Content: manage game data such as player and board infomation
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Battleship.com.model
{
    class GameData
    {

        public enum Mode
        {
            p1VersusCom     = 1,
            p1VersusP2      = 2,
        }

        public enum columnStart { A  = 64 }

        private int _playMode;
        public int playMode
        {
            get 
            {
                switch(_playMode)
                {
                    case (int) GameData.Mode.p1VersusP2 :
                        break;
                    case (int) GameData.Mode.p1VersusCom :
                        break;
                    default :
                        return 0;
                }

                return _playMode;
            }
            set
            {
                _playMode   = value;
            }
        }
        public int[] battleShipSizes{get; set;}
    }

    class Player
    {
        public Player(string _name, string[, ] _playerBoard)
        {
            Name        = _name;
            playerBoard = _playerBoard;
            playerErr   = false;
        } 

        public string Name{ get; set; }
        
        public string[, ] playerBoard{ get; set; }

        // public List<Dictionary<string, string>> playerBattleShips;
        public Dictionary<string, string> playerBattleShips { get; set; }

        public bool playerErr { get; set; }
 

    }

    class PlaceShips
    {
        // private string _location;

        // public string Getlocation()
        // {
        //     return _location;
        // }

        // public void Setlocation(string value)
        // {
        //     _location = value;
        // }

        // public int[] cellToCoordinate(string cell)
        // {
        //     int[] rtn       = new int[2];
            
        //     string tempX    = Regex.Replace(cell, @"\D", "");
        //     char[] tempY    = Regex.Replace(cell,tempX, "").ToUpper().ToCharArray();

        //     rtn[0]          = int.Parse(tempX);
        //     rtn[1]          = Convert.ToInt32(tempY[0]) - (int) GameData.columnStart.A;

        //     return rtn;
        // }




    }

}