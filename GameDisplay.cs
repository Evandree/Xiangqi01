using System;
namespace Xiangqi01
{
    public class GameDisplay
    {

        /*  public static void DrawingBoard()
          {

              Console.Clear();

              for (int a = 0; a < 19; a++)
              {
                  Console.BackgroundColor = ConsoleColor.White;
                  for (int b = 0; b < 18; b++)
                  {

                      if (GameBoard.board[a / 2, b / 2] == null)
                          Console.ForegroundColor = ConsoleColor.Blue;
                      else if (GameBoard.board[a / 2, b / 2].Side == Side.red)
                      {
                          if (b % 2 == 1 || a % 2 == 1)
                              Console.ForegroundColor = ConsoleColor.Blue;
                          else Console.ForegroundColor = ConsoleColor.DarkMagenta;
                      }
                      else if (GameBoard.board[a / 2, b / 2].Side == Side.black)
                      {
                          if (b % 2 == 1 || a % 2 == 1)
                              Console.ForegroundColor = ConsoleColor.Blue;
                          else Console.ForegroundColor = ConsoleColor.Black;
                      }


                     // Console.Write(GameDisplay.displayboard[a, b]);
                  }
                  Console.WriteLine();
                  Console.ForegroundColor = ConsoleColor.Blue;
              }
              Console.WriteLine(" 0   1   2   3   4   5   6   7   8 ");


          }


          public static void ErrorMessage()
          {
              switch (GameBoard.ErrorNumber)
              {
                  case 1:
                      Console.WriteLine("You select an empty place,please select again");
                      return;


                  case 2:
                      Console.WriteLine("Your input is invalid!!");
                      Console.WriteLine("Please enter only 2 numebrs!");
                      return;

                  case 3:
                      Console.ForegroundColor = ConsoleColor.Red;
                      Console.WriteLine("Your destination is the same as your starting point!!!!");
                      Console.WriteLine("Please choose again!");
                      return;

                  case 4:
                      Console.ForegroundColor = ConsoleColor.Red;
                      Console.WriteLine("Your move is invalid!");
                      Console.WriteLine("Please select your destination again!");
                      Console.Write("\n");
                      return;

                  case 5:
                      Console.ForegroundColor = ConsoleColor.Red;
                      Console.WriteLine("You select the wrong side!");
                      Console.WriteLine("Please select your side and enter again!");
                      Console.Write("\n");
                      return;
              }
          }

          public static void SelectPieceDisplay()
          {
              if (GameBoard.turn % 2 == 0)
              {
                  Console.ForegroundColor = ConsoleColor.Black;
                  Console.WriteLine("\n");
                  Console.WriteLine("-------It's BLACK turn!!!-------\nWhich piece do you want to move?(PLEASE INPUT TWO NUMBERS. Like: 11)");
              }
              if (GameBoard.turn % 2 == 1)
              {
                  Console.ForegroundColor = ConsoleColor.DarkMagenta;
                  Console.WriteLine("\n");
                  Console.WriteLine("-------It's RED turn!!!-------\nWhich piece do you want to move?(PLEASE INPUT TWO NUMBERS. Like: 98)");
              }
              Console.WriteLine("First number is for Y-axis (0-9)\nSecond number is for X-axis (0-8)");
          }

          public static void SelectPositionDisplay()
          {
              if (GameBoard.turn % 2 == 0)
              {
                  Console.ForegroundColor = ConsoleColor.DarkMagenta;
              }
              if (GameBoard.turn % 2 == 1)
              {
                  Console.ForegroundColor = ConsoleColor.Black;
              }

              Console.WriteLine("Please enter the position you want to move:");
          }

      }*/
    }
}