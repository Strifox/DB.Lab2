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
        public void MenuDatabase()
        {
            Console.WriteLine("Welcome to Angry Birds Console");
            Thread.Sleep(5000);
            Console.Clear();

            Console.WriteLine("Press '1' to Add a player");
            Console.WriteLine("Press '2' to Add a Map");
            Console.WriteLine("Press '3' to Edit a player steps");
            Console.WriteLine("Press '4' to Search player");
        }
    }
}
