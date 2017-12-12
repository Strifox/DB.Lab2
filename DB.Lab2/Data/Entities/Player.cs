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

        #region Properties To Columns

        [Key]
        public int Id { get; set; } // Player ID (Primary key)

        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(32)]
        public string Name { get; set; } // Player name

        [Column("MaxMoves", TypeName = "int")]
        public int Moves { get; set; } // Player moves (how many moves player used, NOT how many player think he will do)

        #endregion


        public void AddPlayerToDatabase(EntityContext context)
        {
            Console.WriteLine("Type your Name");
            Name = Console.ReadLine(); // Sets player name in database to this

            Console.WriteLine("Type how many moves you made");
            Moves = int.Parse(Console.ReadLine()); // Sets player moves in database to this

            Player p = new Player(); // Instanstiates player class

            context.Players.Add(p); //Adds player to Database
            context.SaveChanges();
        }

        public void ChoosePlayer(EntityContext context)
        {
            Console.Clear();
            Console.WriteLine("Choose a player you edit");
            query.ChoosePlayerQuery(context);
            context.SaveChanges();
        }

        public static void EditPlayer(EntityContext context)
        {
            Console.WriteLine("Type your new name");
            query.ChoosePlayerQuery(context);
            context.SaveChanges();
        }
    }
}
