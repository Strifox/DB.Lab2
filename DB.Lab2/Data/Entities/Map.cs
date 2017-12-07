using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Lab2
{
    class Map
    {
        [Key]
        public int Id { get; set; }

        [Column("Moves", TypeName = "int")]
        public int Moves { get; set; }

    }
}
