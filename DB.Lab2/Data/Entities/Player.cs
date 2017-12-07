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

        [Column("Moves", TypeName = "int")]
        public int Moves { get; set; } // Player moves (how many moves player used, NOT how many player think he will do)

        #endregion


        public Player(int id, string name, int moves)
        {
            Id = id;
            Name = name;
            Moves = moves;
        }

        //Adding to listbox
        public void UpdateAddToListbox()
        {
            SqlConnection con = new SqlConnection();
            SqlDataReader reader;
            SqlCommand cmd;
            string query = @"SELECT Id, Name, Moves FROM Player"; //Updates the listbox with selected columns from TABLE Player
            cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AddPlayer(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)); //Setting parameters to AddPlayer method.
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e); //TODO: Change to label or something
            }
            finally
            {
                con.Close();
            }
        }

    }
}
