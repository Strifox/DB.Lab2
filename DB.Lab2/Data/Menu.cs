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
        private EntityContext e = new EntityContext();
        private Map m = new Map();
        private Player p = new Player();

        public void MenuDatabase()
        {
            Console.WriteLine("Welcome to Angry Birds Console");
            Thread.Sleep(1000);
            Console.Clear();

            MenuSwitch();
        }


        public void MenuSwitch()
        {
            string menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("Press '1' to Add a player");
                Console.WriteLine("Press '2' to Add a Map");
                Console.WriteLine("Press '3' to Edit a player");
                Console.WriteLine("Press '4' to show all players");
                Console.WriteLine("Press '5' to show all maps");
                Console.WriteLine("Press '6' to Exit game");

                menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        PlayerContext.AddPlayerToDatabase(e);
                        break;
                    case "2":
                        MapContext.AddMapToDatabase(e);
                        break;
                    case "3":
                        //p.EditPlayer(e);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Players in database:");
                        Query.ShowPlayerQuery(e);
                        Console.WriteLine("\nPress enter to continue..");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Maps in database:");
                        Query.ShowMapQuery(e);
                        Console.WriteLine("\nPress enter to continue..");
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Thanks for playing!");
                        Console.WriteLine("\nPress enter to continue..");
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
