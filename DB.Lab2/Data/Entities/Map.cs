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
        private int Id { get; set; }

        [Column("MaxMoves", TypeName = "int")]
        private int MaxMoves { get; set; }

        public Map()
        {
        }

        public void AddMapToDatabase(EntityContext context)
        {
            Console.WriteLine("Skriv in max antal drag på banan");
            MaxMoves = int.Parse(Console.ReadLine()); // Sätter Max antal drag på kartan
            Map m = new Map();
            context.Maps.Add(m);
            context.SaveChanges();
        }

    }
}
