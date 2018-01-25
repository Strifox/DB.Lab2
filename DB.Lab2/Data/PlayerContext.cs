using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Lab2
{
    class PlayerContext
    {
        static Map map;
        static Player player;

        public static void AddPlayerToDatabase(EntityContext context)
        {

            bool correctlyEntered;
            Console.WriteLine("Type your Name (Case sensitive)");
            player.Name = Console.ReadLine(); // Sets player name in database to this

            if (!Query.DoesPlayerExist(context, player.Name))
            {
                do
                {
                    Console.WriteLine($"Max moves: {map.MaxMoves}");
                    Console.WriteLine("Type how many moves you made");
                    player.Moves = int.Parse(Console.ReadLine()); // Sets player moves in database to this
                    if (player.Moves <= map.MaxMoves)
                    {
                        context.Players.Add(new Player(player.Name)); //Adds player to Database
                        context.SaveChanges();
                        Console.WriteLine("Database added");
                        correctlyEntered = true;
                    }
                    else
                    {
                        Console.WriteLine($"You can't do more steps than max.\n(max moves: {map.MaxMoves} )");
                        Console.WriteLine("\nPress enter to continue..");
                        Console.ReadKey();
                        correctlyEntered = false;
                    }

                } while (!correctlyEntered);
            }
            else
            {
                Console.WriteLine("Player already exists..");
                Console.WriteLine("\nPress enter to continue..");
                Console.ReadKey();
            }

        }
        public int ChoosePlayer(EntityContext context)
        {
            Console.Clear();
            //Query.ChoosePlayerQuery(context, Id); // Method to choose a player
            return player.Id;
        }

        public void EditPlayer(EntityContext context)
        {
            Console.Clear();
            Console.WriteLine("Press '1' to edit Player Name");
            Console.WriteLine("Press '2' to edit Player Score");
            string menuChoice = Console.ReadLine();
            switch (menuChoice) // A Switch to choose wether to edit player name or score
            {
                case "1":
                    ChoosePlayer(context);
                    Query.EditPlayerNameQuery(context);
                    break;
                case "2":
                    Query.EditPlayerScoreQuery(context);
                    break;
            }
            context.SaveChanges();
        }
    }
}
