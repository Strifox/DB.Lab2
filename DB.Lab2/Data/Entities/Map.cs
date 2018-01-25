using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DB.Lab2
{
    public class Map
    {
        public virtual IList<Score> Scores { get; set; }

        [Key]
        public int Id { get; set; }

        [Column("MaxMoves", TypeName = "int")]
        public int MaxMoves { get; set; }

        [Column("MapName", TypeName = "nvarchar")]
        [MaxLength(50)]
        public string MapName { get; set; }

        public Map(int maxMoves, string mapName)
        {
            MapName = mapName;
            MaxMoves = maxMoves;
        }

        public Map()
        {

        }
        
    }
}
