/*
    Class  : WordFactory
    Author : Sangyeo(Harry) Kim
    Date   : 28/2/19
    Content: manage all words and sentences of this game.
 */

using System;

namespace Battleship.com.model
{
    class WordFactory
    {
        public string des_Welcome
        {
            get 
            {
                string _des_Welcome   = "Welcome to the Battleship game!";   
                    _des_Welcome    += "\n";

                 return _des_Welcome; 
            }
        }

        public string des_ModeSelection
        {
            get 
            { 
                string _des_ModeSelection   = "";
                    _des_ModeSelection  += "Select player mode";
                    _des_ModeSelection  += "\n";
                    _des_ModeSelection  += "  (1) : 1 Player vs Computer (not realized)";
                    _des_ModeSelection  += "\n";                    
                    _des_ModeSelection  += "  (2) : 1 Player vs 2 Player";
                    _des_ModeSelection  += "\n";
                    _des_ModeSelection  += ": ";

                return _des_ModeSelection; 
            }
        }

        public string des_SetUpShips
        {
            get
            {
                string _des_SetUpShips = "";
                    _des_SetUpShips += "How many Battleships do you place on?";
                    _des_SetUpShips += "\n";
                    _des_SetUpShips += ": ";

                return _des_SetUpShips;
            }
        }

        public string des_SetUpShipsLength
        {
            get
            {
                string _des_SetUpShipsLength  = "";
                    _des_SetUpShipsLength   += "Please set the lenght of ship(s)";
                    _des_SetUpShipsLength   += "\n";

                return _des_SetUpShipsLength;
            }
        }
    
        public string des_EachShipsLengthErr
        {
            get
            {
                string _des_EachShipsLengthErr = "";
                    _des_EachShipsLengthErr    += "== Please input a proper 'digit' for the length! ==";
                    _des_EachShipsLengthErr    += "\n";

                return _des_EachShipsLengthErr;
            }
        }

        public string des_EachShipsLength
        {
            get
            {
                string _des_EachShipsLength = "";
                    _des_EachShipsLength    = "'s size : ";

                return _des_EachShipsLength;
            }
        }

        public string des_PlaceShips
        {
            get
            {
                string _des_PlaceShips  = "";
                        _des_PlaceShips = " turn! : Please place your ships (vertical : v / horizantal : h )";
                        _des_PlaceShips += "\n";

                return _des_PlaceShips;
            }
        }

        public string des_LocatedShips
        {
            get
            {
                string _des_LocatedShips  = "";
                        _des_LocatedShips = "'s location (ex : 1A v or 1A h) : ";

                return _des_LocatedShips;
            }
        }

        public string des_InputErr
        {
            get
            {
                string _des_InputErr  = "";
                        _des_InputErr += "== Please input a proper input type! ==";
                        _des_InputErr += "\n";

                return _des_InputErr;
            }
        }

        public string des_DuplicateErr
        {
            get
            {
                string _des_DuplicateErr  = "";
                        _des_DuplicateErr += "== Your position already has been taken! ==";
                        _des_DuplicateErr += "\n";
  
                return _des_DuplicateErr;
            }
        }

        public string des_PlaceErr
        {
            get
            {
                string _des_PlaceErr  = "";
                        _des_PlaceErr += "== Please place your ship into the board! ==";
                        _des_PlaceErr += "\n";
  
                return _des_PlaceErr;
            }
        }        

        public string des_Attack
        {
            get
            {
                string _des_Attack  = "";
                        _des_Attack += " attack! (ex 1A) : ";
  
                return _des_Attack;
            }
        }

        public string des_AttackHit
        {
            get
            {
                string _des_AttackHit  = "";
                        _des_AttackHit += " Hit! ";
                        _des_AttackHit += "\n";
  
                return _des_AttackHit;
            }
        }

        public string des_AttackMiss
        {
            get
            {
                string _des_AttackMiss  = "";
                        _des_AttackMiss += " Miss! ";
                        _des_AttackMiss += "\n";

                return _des_AttackMiss;
            }
        }        

        public string des_AttackSunk
        {
            get
            {
                string _des_AttackSunk  = "";
                        _des_AttackSunk += " is sunk! ";
                        _des_AttackSunk += "\n";
                        
  
                return _des_AttackSunk;
            }
        }

        public string des_AttackWin
        {
            get
            {
                string _des_AttackWin  = "";
                        _des_AttackWin += " is Winner!! ";
                        _des_AttackWin += "\n";
                        
  
                return _des_AttackWin;
            }
        }

    }

}