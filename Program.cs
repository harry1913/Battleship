/*
    Class  : Program
    Author : Sangyeo(Harry) Kim
    Date   : 28/2/19
    Content: console main class
 */
using System;
using Battleship.com.controller;

namespace Battleship
{
    /* Program Main class */
    class Program
    {
        static void Main(string[] args)
        {
            /* Game Controller running */
            GameController controller = new GameController();
            controller.run();
        }
    }
}
