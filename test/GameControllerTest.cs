// using System;

// using Battleship.com.controller;
// using Battleship.com.model;

// namespace Battleship.test
// {
//     class GameControllerTest
//     {
//         GameController controller;

//         public GameControllerTest()
//         {
//             controller = new GameController();
//             controller.initialization();
//         }   

//         public void coordinateValidationTest()
//         {
            
//             var result = controller.coordinateValidation("A2 h");
//                 Console.WriteLine(result);
//                 result = controller.coordinateValidation("a2 h");
//                 Console.WriteLine(result);
//                 result = controller.coordinateValidation("A10 va");
//                 Console.WriteLine(result);
//                 result = controller.coordinateValidation("a10 vc");
//                 Console.WriteLine(result);
//                 result = controller.coordinateValidation("10a hc");
//                 Console.WriteLine(result);
//                 result = controller.coordinateValidation("10A hc");
//                 Console.WriteLine(result);
//                 result = controller.coordinateValidation("10ac");
//                 Console.WriteLine(result);
//         }
//     }
// }
