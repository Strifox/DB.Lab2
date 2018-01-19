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
                Console.WriteLine("Press '1' to Add a player");
                Console.WriteLine("Press '2' to Add a Map");
                Console.WriteLine("Press '3' to Edit a player");
                Console.WriteLine("Press '4' to Search player");
                Console.WriteLine("Press '5' to Exit game");

                menuChoice = Console.ReadLine();
                switch (menuChoice)
                {
                    case "1":
                        p.AddPlayerToDatabase(e);
                        break;
                    case "2":
                        m.AddMapToDatabase(e);
                        break;
                    case "3":
                        p.EditPlayer(e);
                        break;
                    case "5":
                        Console.WriteLine("Thanks for playing..");
                        Thread.Sleep(2000);
                        break;
                }

            } while (menuChoice != "5");

        }
    }
}
