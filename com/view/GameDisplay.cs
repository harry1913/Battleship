/*
    Class  : Program
    Author : Sangyeo(Harry) Kim
    Date   : 28/2/19
    Content: draw and re-draw grid
 */
using System;
using System.Text;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

using Battleship.com.model;

namespace Battleship.com.view
{
    class GameDisplay
    {
        private int gridX           = 0;
        private int gridY           = 0;

        private WordFactory wordFactory;
        
        // GameDisplay : set up board x and y
        public GameDisplay(int _x, int _y)
        {

            gridX           = _x;
            gridY           = _y;
            wordFactory     = new WordFactory();

        }

        /* cellToCoordinate : change string type cell to int type coordinate */
        private int[] cellToCoordinate(string cell)
        {
            int[] rtn       = new int[2];
            
            string tempX    = Regex.Replace(cell, @"\D", "");                           // find string type
            char[] tempY    = Regex.Replace(cell,tempX, "").ToUpper().ToCharArray();    // change the string type to a upper case

            rtn[0]          = int.Parse(tempX) - 1;
            rtn[1]          = Convert.ToInt32(tempY[0]) - (int) GameData.columnStart.A - 1;

            return rtn;
        }

        /* shipKeyGenerator : change user input to key with sprint type*/
        public String shipKeyGenerator(string cell)
        {
            int[] xy = cellToCoordinate(cell);
            return shipKeyGenerator(xy[0], xy[1]);
        }

        /* shipKeyGenerator : change user input to key with int type*/
        private String shipKeyGenerator(int keyX, int keyY)
        {
            string key = keyX.ToString() + "?" + keyY.ToString();       // custom key format (ex '1?1')
            return key;
        }

        /* placeShipsOnBoard : place battleships on (10 x 10) matrix board */
        public Player placeShipsOnBaord(string cell, string direction, int size, string value, Player _player)
        {

            int[] xy    = cellToCoordinate(cell);
            List<int> x = new List<int>();
            List<int> y = new List<int>();

            /* check direction and set value into playerboard */
            try
            {
                for (int i = 0; i < size; i++)
                {
                    switch(direction)
                    {
                        case "h" :          // horizantal ships
                            if(i != 0)
                                xy[1] ++;
                            
                            // check a duplication ship
                            if(_player.playerBattleShips.ContainsKey(shipKeyGenerator(xy[0], xy[1])))
                            {
                                Console.WriteLine(wordFactory.des_DuplicateErr);
                                _player.playerErr   =   true;
                                return _player;                                
                            }
                            break;
                        case "v" :          // vertical ships
                            if(i != 0)
                                xy[0] ++;

                            // check a duplication ship
                            if(_player.playerBattleShips.ContainsKey(shipKeyGenerator(xy[0], xy[1])))
                            {
                                Console.WriteLine(wordFactory.des_DuplicateErr);
                                _player.playerErr   =   true;
                                return _player;
                            }
                            break;
                    }

                    if (xy[0] >= 10 || xy[1] >= 10)
                    {
                        Console.WriteLine(wordFactory.des_PlaceErr);
                        _player.playerErr   =   true;
                        return _player;     
                    }

                    x.Add(xy[0]);
                    y.Add(xy[1]);
                }

                for (int j = 0; j < x.Count(); j++)
                {
                    /* set the value into a board and add coordinate key and ship's name */
                    _player.playerBoard[x[j], y[j]] = value;    
                    _player.playerBattleShips.Add(shipKeyGenerator(x[j], y[j]), value);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Opps!");
                System.Environment.Exit(1);
           }

            _player.playerErr   =   false;
            return _player;

        }

        /* displayGrid : show 2-dimential matrix in a console */
        public bool displayGrid(string pname, string[, ] board)
        {
            int lengthY         = (int) Math.Log10(gridX) + 1;          // set the length of cell's width
          
            string digitFormat  = "{0, " + lengthY + "}";               // set a format in order to set the width
            string space        = " ";
            string gridLine     = "|";                                  // column line
            string column       = "";
            
            StringBuilder rowData = new StringBuilder();
            
            /* construct a matrix grid */
            rowData.Append("========= " + pname + " ===========");
            rowData.Append(Environment.NewLine);
            
            // expect O(n pow 2), if the board would be bigger than 10 x 10, this logic must be replaced to O(n).
            for (int i = 0; i <= gridY; i++)
            {
                if (i == 0)
                    rowData.Append(String.Format(digitFormat, space));
                else
                    rowData.Append(String.Format(digitFormat, i));

                for (int j = 0; j <= gridX; j++)
                {
                    if (i == 0 && j != 0)
                    {
                        column           = ((char) (GameData.columnStart.A + j)).ToString();
                        rowData.Append(gridLine + String.Format("{0, "+ (column.Length + 1) + "}", column));        // set up columns (A,B,C..)
                    }
                    else if (j != 0)
                    {
                        rowData.Append(gridLine + String.Format("{0, "+ (column.Length + 1) + "}", board[i - 1, j - 1]));       // set up the ship's name (value)
                    }
                }

                rowData.Append(gridLine);
                rowData.Append(Environment.NewLine);
            }
            Console.WriteLine(rowData.ToString());      // output the matrix grid

            return true;
        }
    }

    /* ArrayExt : spare method to draw a grid with O(n) time complexity. this method get from Stack overFlow */
//     public static class ArrayExt
//     {
//         public static T[] GetRow<T>(this T[,] array, int row)
//         {
//             if (!typeof(T).IsPrimitive)
//                 throw new InvalidOperationException("Not supported for managed types.");

//             if (array == null)
//                 throw new ArgumentNullException("array");

//             int cols = array.GetUpperBound(1) + 1;
//             T[] result = new T[cols];

//             int size;

//             if (typeof(T) == typeof(bool))
//                 size = 1;
//             else if (typeof(T) == typeof(char))
//                 size = 2;
//             else
//                 size = Marshal.SizeOf<T>();

//             Buffer.BlockCopy(array, row*cols*size, result, 0, cols*size);

//             return result;
//         }
//    }    

}
