using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace DB.Lab2
{
    public class PlayerContext
    {
        static Map map = new Map();
        static Player player = new Player();
        static Score score = new Score();

        public static void AddPlayerToDatabase(EntityContext context)
        {
            Console.WriteLine("Type your Name (Case sensitive)");
            string playerName = Console.ReadLine(); // Sets player name in database to this

            if (!Query.DoesPlayerExistWithName(context, playerName))
            {
                context.Players.Add(new Player(playerName)); //Adds player to Database
                context.SaveChanges();
                Console.WriteLine("Database added");
            }
            else
            {
                Console.WriteLine("Player already exists..");
                Console.WriteLine();
                DoesPlayerExistIncludedWithScore(context, playerName);
                Console.WriteLine("\nPress enter to continue..");
                Console.ReadKey();
            }
        }

        public static void AddMovesToPlayer(EntityContext context)
        {
            Map currentMap = MapContext.IsMapAdded(context);
            Console.WriteLine($"Choose a player with Id to add moves to that player: \n {player.Id}. {player.Name}");
            Query.ShowPlayerQuery(context);
            int id = Int32.Parse(Console.ReadLine()); // Sets player name in database to this
            if (!Query.DoesPlayerExistWithId(context, id))
            {
                bool correctlyEntered;
                do
                {
                    Console.WriteLine("Type how many moves you made");
                    score.PlayerScore = int.Parse(Console.ReadLine()); // Sets player moves in database to this
                    if (score.PlayerScore <= Query.ReturnMaxMapMoves(context))
                    {
                        //TODO: Lägga in MapID som parameter
                        context.Scores.Add(new Score(currentMap, Query.GetPlayerById(context, id), score.PlayerScore)); //Adds player moves to Table
                        context.SaveChanges();
                        Console.WriteLine("Database added");
                        Console.WriteLine("\nPress enter to continue..");
                        Console.ReadKey();
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
        public static void ShowPlayer(EntityContext context)  // Shows all existing players
        {
            Console.Clear();
            Query.ShowPlayerQuery(context);
        }
        public static void EditPlayer(EntityContext context) // A Switch menu to choose wether to edit player name or score
        {
            Console.Clear();
            Console.WriteLine("Press '1' to edit Player Name");
            Console.WriteLine("Press '2' to edit Player Score");
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1":
                    ShowPlayer(context);
                    EditPlayerName(context, player.Name);
                    break;
                case "2":
                    Query.UpdateScore(context);
                    break;
            }
            context.SaveChanges();
        }
        public static Player ChoosePlayer(EntityContext context, ref int playerId)
        {
            player = Query.GetPlayerById(context, playerId);
            return player;
        }
        public static void EditPlayerName(EntityContext context, string playerName)
        {
            Console.WriteLine("\nChoose Player by id");
            int playerId = int.Parse(Console.ReadLine());
            var player = ChoosePlayer(context, ref playerId);
            Console.WriteLine($"You chose {player.Name}");
            Console.WriteLine("\nType your new name");
            playerName = Console.ReadLine();
            player.Name = playerName;
            Console.WriteLine($"You updated player name to: {playerName}");
            context.SaveChanges();
            Thread.Sleep(1500);
        }
        public static bool IsInputValid(string input)
        {
            string pattern = @"^[0-9]{1,}$";
            var match = Regex.Match(input, pattern);

            if (match.Success)
                return true;
            else
                return false;
        }
        public static void DoesPlayerExistIncludedWithScore(EntityContext context, string playerName)
        {
            var playerIdByName = Query.GetPlayerByName(context, playerName);

            var Rounds = Query.GetAllScoresForPlayer(context, playerIdByName);

            foreach (var round in Rounds)
            {
                if (round.Player.Id == playerIdByName.Id)
                {
                    var highest = Rounds.Where(r => r.Map.Id == round.Map.Id).OrderBy(r => r.PlayerScore).Take(1);
                    Console.WriteLine($"Bana: {round.Map.MapName},  Använda Drag: {round.PlayerScore}, Drag Kvar: {round.Map.MaxMoves - round.PlayerScore}, HighScore {highest.First().Player.Name}: {highest.First().PlayerScore}");
                }
            }
            var totalscore = Rounds.Where(r => r.Player.Id == playerIdByName.Id).Sum(r => r.PlayerScore);
            Console.WriteLine($"Total antal moves: {totalscore}");

        }
    }
}
