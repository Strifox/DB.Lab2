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

        public  IList<Score> Scores { get; set; }

        #region Properties To Columns

        [Key]
        public int Id { get; set; } // Player ID (Primary key)
        
        public string Name { get; set; } // Player name

        public IList<Map> PlayedMaps { get; set; }


        #endregion
        #region Constructors
        public Player() // Default(empty) constructor
        {

        } 
        public Player(string name) // Constructor to set name property
        {
            Name = name;
        }
        #endregion
    }
}
