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

        [Column("MaxMoves", TypeName = "int")]
        public int MaxMoves { get; set; }

        public Map(int id, int maxMoves)
        {
            Id = id;
            MaxMoves = maxMoves;
        }

        public void AddMapToDatabase(EntityContext context)
        {
            Console.WriteLine("Skriv in numret på Banan");
            Id = int.Parse(Console.ReadLine()); // Sätter ID:t på banan
            Console.WriteLine("Skriv in max antal drag på banan");
            MaxMoves = int.Parse(Console.ReadLine()); // Sätter Max antal drag på kartan
            Map m = new Map(Id, MaxMoves);
            context.Maps.Add(m);
            context.SaveChanges();
        }

    }
}
