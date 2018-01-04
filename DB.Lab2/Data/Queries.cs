using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Lab2
{
    class Queries
    {

        #region Player Queries

        public void ShowPlayerQuery(EntityContext context)
        {
            var showPlayerQuery = from show in context.Players
                                  select show;
            foreach (var player in showPlayerQuery)
            {
                Console.WriteLine(player);
            }
        }
        public void ChoosePlayerQuery(EntityContext context)
        {
            var chooseQuery = from choose in context.Players
                              where choose.Id == Int32.Parse(Console.ReadLine())
                              select choose;

            foreach (var player in chooseQuery)
            {
                Console.WriteLine(player);
            }
        }
        public void EditPlayerNameQuery(EntityContext context)
        {
            Console.WriteLine("Type your new name");
            var nameQuery = from name in context.Players
                            where name.Name == Console.ReadLine()
                            select name;

            foreach (var player in nameQuery)
            {
                Console.WriteLine("You updated player name to:");
                Console.WriteLine(player);
            }
        }
        public void EditPlayerScoreQuery(EntityContext context)
        {
            Console.WriteLine("Type your new score");
            var scoreQuery = from score in context.Scores
                             where score.Points == Int32.Parse(Console.ReadLine())
                             select score;
            foreach (var score in scoreQuery)
            {
                Console.WriteLine("You updates player score to:");
                Console.WriteLine(score);
            }
        }

        public void SearchPlayerQuery(EntityContext context)
        {

        }
        #endregion  
    }
}
