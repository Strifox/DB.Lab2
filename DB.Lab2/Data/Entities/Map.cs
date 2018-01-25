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

        public void AddMapToDatabase(EntityContext context) // Adds map to database
        {
            Console.WriteLine("Enter a map name");
            MapName = Console.ReadLine();
            Console.WriteLine("Enter Max amount of moves");
            MaxMoves = int.Parse(Console.ReadLine());
            context.Maps.Add(new Map(MaxMoves, MapName));
            // context.SaveChanges();
            Console.WriteLine($"{MapName} added to database");
        }


        public void IsMapAdded(EntityContext context)  //Checks if map is added before adding a player
        {
            if (context.Maps.Any())
            {
                Console.WriteLine("You must choose a map before adding a player. Enter Map name:");
                Query.ShowMapQuery(context);
                string mapName = Console.ReadLine();
                ChooseMap(context, mapName);
            }
            else if (!context.Maps.Any())
            {
                Console.WriteLine("There is no map added, you must first add a map");
                AddMapToDatabase(context);
            }
            //var mapQuery = from map in context.Maps
            //               select map.MapName;
            //foreach (var map in mapQuery)
            //{
            //if (mapName == MapName)
            //    Console.WriteLine("The map name already exists");
            //else
            //    AddMapToDatabase(context);
            //}
            //
            //
            //
            //
            Console.WriteLine($"Map name: {MapName}\nMap MaxMoves: {MaxMoves}\nMap Id: {Id}");
            Console.ReadKey();
            context.SaveChanges();
        }


        public int ChooseMap(EntityContext context, string mapName)
        {
            //1. Skriva ut kartor
            //2. Hämta input från consol
            //3. Returnera id för vald karta
            if (!Query.DoesMapExist(context, mapName))
                Console.WriteLine("Invalid map");
            else
                Query.ChooseMapQuery(context, mapName);

            Console.WriteLine($"Map name: {MapName}\nMap MaxMoves: {MaxMoves}\nMap Id: {Id}");
            return Id;
        }
    }
}
