using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Lab2
{
    public class MapContext
    {
        static Map map = new Map();

        public static void AddMapToDatabase(EntityContext context) // Adds map to database
        {
            Console.WriteLine("Enter a map name");
            map.MapName = Console.ReadLine();
            Console.WriteLine("Enter max amount of moves");
            map.MaxMoves = int.Parse(Console.ReadLine());
            context.Maps.Add(new Map(map.MaxMoves, map.MapName));
            Console.WriteLine($"{map.MapName} added to database");
            context.SaveChanges();
        }
        public static Map IsMapAdded(EntityContext context)  //Checks if map is added before adding a player
        {
            if (context.Maps.Any())
            {
                Console.WriteLine("You must choose a map before adding moves to a player. Enter the map name by typing the ID:");
                Query.ShowMapQuery(context);
                int mapId = int.Parse(Console.ReadLine());
                ChooseMap(context, ref mapId);
            }
            else if (!context.Maps.Any())
            {
                Console.WriteLine("There is no map added, you must first add a map");
                AddMapToDatabase(context);
                context.SaveChanges();
            }
            return map;
        }
        public static Map ChooseMap(EntityContext context, ref int mapId)
        {
            map = Query.GetMapById(context, mapId);
            return map;
        }

    }
}
