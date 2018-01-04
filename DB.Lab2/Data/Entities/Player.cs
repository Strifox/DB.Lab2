using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Lab2
{
    class Player
    {
        //Connection string to Database
        private const string DbConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB Lab2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static Queries query = new Queries();

        private Player(string name)
        {
            Name = name;
        }


        #region Properties To Columns

        [Key]
        public int Id { get; set; } // Player ID (Primary key)

        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(32)]
        public static string Name { get; set; } // Player name

        [Column("MaxMoves", TypeName = "int")]
        public static int Moves { get; set; } // Player moves (how many moves player used, NOT how many player think he will do)

        #endregion


        public static void AddPlayerToDatabase(EntityContext context)
        {
            Console.WriteLine("Add a map");
            Map.AddMapToDatabase(context);

            Console.WriteLine("Type your Name");
            Name = Console.ReadLine(); // Sets player name in database to this

            Console.WriteLine("Type how many moves you made");
            Moves = int.Parse(Console.ReadLine()); // Sets player moves in database to this

            context.Players.Add(new Player(Name)); //Adds player to Database
            context.SaveChanges();
        }
        public void ChoosePlayer(EntityContext context)
        {
            Console.Clear();
            query.ChoosePlayerQuery(context); // Method to choose a player
            context.SaveChanges();
        }

        public static void EditPlayer(EntityContext context)
        {
            Console.Clear();
            Console.WriteLine("Press '1' to edit Player Name");
            Console.WriteLine("Press '2' to edit Player Score");
            string menuChoice = Console.ReadLine();
            switch (menuChoice)
            {
                case "1":
                    query.EditPlayerNameQuery(context);
                    break;
                case "2":
                    query.EditPlayerScoreQuery(context);
                    break;
            }
            context.SaveChanges();
        }
    }
}
