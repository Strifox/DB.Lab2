using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Lab2
{
    public class Player
    {

        public virtual IList<Score> Scores { get; set; }

        #region Properties To Columns

        [Key]
        public int Id { get; set; } // Player ID (Primary key)
        
        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(32)]
        public string Name { get; set; } // Player name

        public IList<Map> PlayedMaps { get; set; }

        [Column("Moves", TypeName = "int")]
        public int Moves { get; set; } // Player moves (how many moves player used, NOT how many player think he will do)

        #endregion
        public Player()
        {

        }

        public Player(string name, int moves)
        {
            Name = name;
            Moves = moves;
        }

            
        public void AddPlayerToDatabase(EntityContext context)
        {
            Map m = new Map();
            m.IsMapAdded(context);

            Console.WriteLine("Type your Name (Case sensitive)");
            Name = Console.ReadLine(); // Sets player name in database to this
            if (!Query.DoesPlayerExist(context, Name))
            {
                Console.WriteLine("Type how many moves you made");
                Moves = int.Parse(Console.ReadLine()); // Sets player moves in database to this

                context.Players.Add(this); //Adds player to Database
                context.SaveChanges();
            }
            else
                Console.WriteLine("Player already exists..");
            
        }
        public void ChoosePlayer(EntityContext context)
        {
            Console.Clear();
            Query.ChoosePlayerQuery(context); // Method to choose a player
            context.SaveChanges();
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
