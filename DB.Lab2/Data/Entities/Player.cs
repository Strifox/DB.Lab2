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

        public Player(string name)
        {
            Name = name;
        }


        public Player(int moves)
        {
            Moves = moves;
        }
    }
}
