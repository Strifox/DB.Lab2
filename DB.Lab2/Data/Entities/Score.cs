using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Lab2
{
    public class Score
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        public virtual Map Map { get; set; }
        public virtual Player Player { get; set; }

      
        public int PlayerScore { get; set; }
        #endregion

        public Score(Map map, Player player, int playerScore)
        {
            Map = map;
            Player = player;
            PlayerScore = playerScore;
        }
        public Score() { }
    }
}
