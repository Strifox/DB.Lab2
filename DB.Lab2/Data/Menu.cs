using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Lab2
{
    class Menu
    {
        //Instances
        private EntityContext context = new EntityContext();
        public void MenuDbIntro()
        {
            Console.WriteLine("Welcome to Angry Birds Console");
            Thread.Sleep(1000);
            Console.Clear();
            MenuSwitch();
        }
        public void MenuSwitch() // Menu
        {
            string menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("Press '1' to add a player");
                Console.WriteLine("Press '2' to add a Map");
                Console.WriteLine("Press '3' to edit a player");
                Console.WriteLine("Press '4' to add moves to a player");
                Console.WriteLine("Press '5' to show all players");
                Console.WriteLine("Press '6' to show all maps");
                Console.WriteLine("Press '7' to Exit game");

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        PlayerContext.AddPlayerToDatabase(context);
                        break;
                    case "2":
                        MapContext.AddMapToDatabase(context);
                        break;
                    case "3":
                        PlayerContext.EditPlayer(context);
                        break;
                    case "4":
                        PlayerContext.AddMovesToPlayer(context);
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Players in database:");
                        Query.ShowPlayerQuery(context);
                        Console.WriteLine("\nPress enter to continue..");
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Maps in database:");
                        Query.ShowMapQuery(context);
                        Console.WriteLine("\nPress enter to continue..");
                        Console.ReadKey();
                        MenuSwitch();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Thanks for playing!");
                        Console.WriteLine("\nPress enter to exit");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input, please choose a valid option..");
                        Console.WriteLine("\nPress enter to continue..");
                        Console.ReadKey();
                        break;
                }

            } while (menuChoice != "6");

        } 
    }
}
