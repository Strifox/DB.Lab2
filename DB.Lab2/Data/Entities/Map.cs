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

        [Column("Moves", TypeName = "int")]
        private int MaxMoves { get; set; }

        public void AddMapToDatabase(EntityContext context)
        {
            Console.WriteLine("Enter Max amount of moves");
            Map m = new Map();
            MaxMoves = int.Parse(Console.ReadLine()); // Sätter Max antal drag på kartan
            context.Maps.Add(m);
            context.SaveChanges();
        }

    }
}
