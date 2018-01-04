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
        public static int MaxMoves { get; set; }

        Map(int maxmoves)
        {
            MaxMoves = maxmoves;
        }

        public static void AddMapToDatabase(EntityContext context)
        {
            Console.WriteLine("Enter Max amount of moves");
            MaxMoves = int.Parse(Console.ReadLine());
            context.Maps.Add(new Map(MaxMoves));
            context.SaveChanges();
        }

    }
}
