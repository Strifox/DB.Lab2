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

        public void AddMapToDatabase(EntityContext context)
        {
            Console.WriteLine("Enter Max amount of moves");
            Moves = int.Parse(Console.ReadLine());
            context.Maps.Add(new Map());
            context.SaveChanges();
        }

    }
}
