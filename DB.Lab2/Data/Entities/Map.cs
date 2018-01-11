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

        [Column("MapName", TypeName = "nvarchar")]
        [MaxLength(50)]
        public string MapName { get; set; }

        public Map(int moves, string mapName)
        {
            MapName = mapName;
            Moves = moves;
        }

        public Map()
        {

        }

        public void AddMapToDatabase(EntityContext context)
        {
            Console.WriteLine("Enter a map name");
            MapName = Console.ReadLine();
            Console.WriteLine("Enter Max amount of moves");
            Moves = int.Parse(Console.ReadLine());
            context.Maps.Add(new Map(Moves, MapName));
            context.SaveChanges();
            Console.WriteLine($"{MapName} added to database");
        }

        public void IsMapAdded(EntityContext context)
        {
            if (!context.Maps.Any())
                Console.WriteLine("You need to add an map");

            AddMapToDatabase(context);

            var mapQuery = from map in context.Maps
                           select map.MapName;

            foreach (var mapName in mapQuery)
            {
                if (mapName == MapName)
                    Console.WriteLine("The map name already exists");
                else
                   AddMapToDatabase(context);
            }
        }
    }
}
