using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DB.Lab2
{
    public class Query
    {
        //TODO: Fixa edit player query
        #region Player Query

        public static void ShowPlayerQuery(EntityContext context)
        {
            var showPlayerQuery = from show in context.Players
                                  select show.Name;

            foreach (var player in showPlayerQuery)
            {
                Console.WriteLine(player);
            }
        }

        public static bool DoesMapExist(EntityContext context, int Id)
        {
            var maps = from map in context.Maps
                          select map;

            foreach (var map in maps)
            {
                if (map.Id == Id)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public static bool DoesPlayerExist(EntityContext context, string Name)
        {
            var players = from player in context.Players
                         select player;

            foreach (var player in players)
            {
                if (player.Name == Name)
                    return true;
                else
                    return false;
            }
            return false;
        }

        //public static void ChoosePlayerQuery(EntityContext context)
        //{
        //    var chooseQuery = from choose in context.Players
        //                      where choose.Id == playerId
        //                      select choose;

        //    foreach (var player in chooseQuery)
        //    {
        //        Console.WriteLine(player);
        //    }
        //}
        public static void EditPlayerNameQuery(EntityContext context)
        {
           
            Console.WriteLine("Type your new name");
            var nameQuery = from p in context.Players
                            where p.Name == Console.ReadLine()
                            select p.Name;

            Console.WriteLine($"You updated player name to: {nameQuery}");
        }
        public static void EditPlayerScoreQuery(EntityContext context)
        {
            Console.WriteLine("Type your new score");
            var scoreQuery = from score in context.Scores
                             where score.PlayerScore == Int32.Parse(Console.ReadLine())
                             select score;
            foreach (var score in scoreQuery)
            {
                Console.WriteLine("You updates player score to:");
                Console.WriteLine(score);
            }
        }

        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..
        //Allt under är snott från Emil..

        public static void UpdateScore(EntityContext context)
        {
            /*Hoppas du inte får huvudvärk av denna funktionen :) */

            Console.Clear();
            var players = from player in context.Players
                          select player;

            foreach (var player in players)
            {
                Console.WriteLine($"Players available:\n{player.Name}\n");
            }
            Console.WriteLine("Which player do you want to update Score for? (Case sensitive)");
            string name = Console.ReadLine();
            Console.Clear();

            Player thisPlayer = null;

            if (DoesPlayerExist(context, name))
            {
                thisPlayer = PlayerContext.GetPlayerByName(context, name);
            }
            else
            {
                Console.WriteLine("User is not in database");
                Thread.Sleep(1500);
                UpdateScore(context);
            }

            string IdString;
            int Id = int.MinValue;
            Map thisMap = null;

            while (thisMap == null)
            {
                Console.Clear();
                var maps = from map in context.Maps
                           select map;

                foreach (var map in maps)
                {
                    Console.WriteLine($"Map ID: {map.Id}, Map Name: { map.MapName}\n");
                }

                Console.WriteLine("\nEnter id for map to update score on!");
                IdString = Console.ReadLine();
                if (!PlayerContext.IsInputValid(IdString))
                {
                    Console.Clear();
                    Console.WriteLine("Only Digits is allowed! Try again: ");
                    Thread.Sleep(2000);
                    continue;
                }

                Id = Convert.ToInt32(IdString);

                var mapsId = (from map in context.Maps
                              select map.Id).ToList();

                foreach (var mapId in mapsId)
                {
                    if (Id == mapId)
                    {
                        thisMap = context.Maps.Where(m => m.Id == mapId).Select(m => m).Single();
                        Console.WriteLine("Moves changed on Map.");
                        Console.Clear();
                        break;
                    }
                }
                if (thisMap == null)
                {
                    Console.Clear();
                    Console.WriteLine("Id number not valid!");
                    Thread.Sleep(2000);
                }
            }
            var GetScore = from score in context.Scores
                           where score.Player.Id == thisPlayer.Id && score.Map.Id == thisMap.Id
                           select score;

            int newScore = int.MinValue;
            string stringNewScore;
            while (newScore > thisMap.MaxMoves || newScore < 0)
            {
                //Kollar om spelaren har ett score på banan annars kraschar det när den försöker skriva ut {GetScore.Single().PlayerTurns}.
                if (GetScore.Count() > 0)
                {
                    Console.WriteLine($"Please enter a new score for {thisPlayer.Name} on {thisMap.MapName} (Current Score is {GetScore.Single().PlayerScore} and Max Turns for this map is {thisMap.MaxMoves})");
                }
                else
                {
                    Console.WriteLine($"Please enter a new score for {thisPlayer.Name} on {thisMap.MapName} (This user has not played this map and Max Turns for this map is {thisMap.MaxMoves})");
                }

                stringNewScore = Console.ReadLine();
                if (!PlayerContext.IsInputValid(stringNewScore))
                {
                    Console.Clear();
                    Console.WriteLine("Only Digits is allowed! Try again: ");
                    Thread.Sleep(1500);
                    continue;
                }

                newScore = Convert.ToInt32(stringNewScore);

                if (newScore <= thisMap.MaxMoves && newScore >= 0)
                    break;

                Console.WriteLine("Score is either too small or too high!");
                Thread.Sleep(2000);
            }


            if (GetScore.Count() > 0)
            {
                GetScore.SingleOrDefault().PlayerScore = newScore;
            }
            else
            {
                context.Players.AddOrUpdate(new Player(newScore));
                //context.Scores.AddOrUpdate(new Score(thisMap, thisPlayer, newScore));
            }
            Console.Clear();
            Console.WriteLine("Update successfull!");
            context.SaveChanges();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        #endregion

        #region Map Query

        public static void ShowMapQuery(EntityContext context)
        {
            var showMapQuery = from show in context.Maps
                               select new
                               {
                                   id = show.Id,
                                   name = show.MapName
                               };

            foreach (var map in showMapQuery)
            {
                Console.WriteLine($"Map Id: {map.id}, Map Name: {map.name}");
            }
        }

        #endregion
    }
}
