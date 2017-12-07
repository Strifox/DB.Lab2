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

        #region Properties To Columns

        [Key]
        public int Id { get; set; } // Player ID (Primary key)

        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(32)]
        public string Name { get; set; } // Player name

        [Column("MaxMoves", TypeName = "int")]
        public int Moves { get; set; } // Player moves (how many moves player used, NOT how many player think he will do)

        #endregion


        public Player(string name, int moves)
        {
            Name = name;
            Moves = moves;
        }

       
        public void AddPlayerToDatabase(EntityContext context)
        {
          
            Console.WriteLine("Type your Name");
            string name = Console.ReadLine();
            Console.WriteLine("Type how many moves you made");
            int moves = int.Parse(Console.ReadLine());
            Player p = new Player(name, moves);

            context.Players.Add(p); //Adds player to Database
            context.SaveChanges();
        }
    }
}
