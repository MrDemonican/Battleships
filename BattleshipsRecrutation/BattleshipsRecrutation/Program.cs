using BattleshipsRecrutation.AppCore;
using BattleshipsRecrutation.AppCore.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Main file of project - deciding how program will work
 * Simple menu included (arrow navigation)
 * linking to Game.cs and GameVs.cs(GameVs - Human vs Ai - not working yet)
 */


namespace BattleshipsRecrutation
{
    class Program
    {
        private static int menuResult = 0;

        static void Main(string[] args)
        {

            // Creating a list that contains strings of menu options
            List<string> menuItems = new List<string>()
            {
                "Computer vs computer",
                "Me vs computer",
                "Exit"
            };
            //Meaningless
            Console.CursorVisible = false;
            //Deciding about program start mode 
            while (true)
            {
                string selectedMenuOption = drawMenu(menuItems);
                if (selectedMenuOption == "Computer vs computer")
                {
                    Console.Clear();
                    int firsPlayerWins = 0;
                    int secondPlayerWins = 0;

                    Console.WriteLine("How many games do you want to play?");
                    var roundsOfGame = int.Parse(Console.ReadLine());

                    for (int i = 0; i < roundsOfGame; i++)
                    {
                        //If option computer vs computer is selected then program will run Game.cs
                        Game game1 = new Game();
                        game1.PlayToEnd();
                        if (game1.Player1.Looser)
                        {
                            secondPlayerWins++;
                        }
                        else
                        {
                            firsPlayerWins++;
                        }
                    }

                    Console.WriteLine("Player 1 Wins: " + firsPlayerWins.ToString());
                    Console.WriteLine("Player 2 Wins: " + secondPlayerWins.ToString());
                    Console.ReadLine();
                }

                /* 
                 * If anyone reads this before starting app:
                 * Human vs computer module is not working yet
                 * 
                 */

                else if (selectedMenuOption == "Me vs computer")
                {
                    Console.WriteLine("Emm... Sorry, work is in progress. You need to wait for next update!");

                    int secondPlayerWins = 0;
                    int firstPlayerWins = 0;

                    GameVs gameVs1 = new GameVs();
                    gameVs1.PlayToEnd();
                    if (gameVs1.Player1.Looser)
                    {
                        secondPlayerWins++;
                    }
                    else
                    {
                        firstPlayerWins++;
                    }

                    if (secondPlayerWins > firstPlayerWins)
                    {
                        Console.WriteLine("Player 2 Wins ");
                    }
                    else if (firstPlayerWins > secondPlayerWins)
                    {
                        Console.WriteLine("Player 1 Wins ");
                    }

                    Console.ReadLine();

                }
                
                // Exit option 

                else if (selectedMenuOption == "Exit")
                {
                    Console.WriteLine("Thank you for using this app! Goodbye");
                    Environment.Exit(15);
                }
            }

            //drawMenu method is responsible for creating menu after program initialization
             static string drawMenu(List<string> items)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (i == menuResult)
                    {
                        // Some console "gui options"^^

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine(items[i]);
                    }
                    else
                    {
                        Console.WriteLine(items[i]);
                    }
                    Console.ResetColor();
                }

                //Reading key - navigation in menu
                ConsoleKeyInfo ckey = Console.ReadKey();
                // Down arrow = navigate one position below
                if (ckey.Key == ConsoleKey.DownArrow)
                {
                    if (menuResult == items.Count - 1)
                    {
                    }
                    else { menuResult++; }
                }
                // Up arrow = navigate one position above
                else if (ckey.Key == ConsoleKey.UpArrow)
                {
                    if (menuResult <= 0)
                    {
                    }
                    else { menuResult--; }
                }
                //Enter = selected option
                else if (ckey.Key == ConsoleKey.Enter)
                {
                    return items[menuResult];
                }
                else
                {
                    return "";
                }
                //After menu work clear console.
                Console.Clear();
                return "";
            }
        }
    }
}