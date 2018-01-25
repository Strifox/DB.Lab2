using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Lab2
{
    class MapContext
    {

        static Map map = new Map();
        public void AddMapToDatabase(EntityContext context) // Adds map to database
        {
            Console.WriteLine("Enter a map name");
            map.MapName = Console.ReadLine();
            Console.WriteLine("Enter Max amount of moves");
            map.MaxMoves = int.Parse(Console.ReadLine());
            context.Maps.Add(new Map(map.MaxMoves, map.MapName));
            // context.SaveChanges();
            Console.WriteLine($"{map.MapName} added to database");
        }


        public void IsMapAdded(EntityContext context)  //Checks if map is added before adding a player
        {
            if (context.Maps.Any())
            {
                Console.WriteLine("You must choose a map before adding a player. Enter Map name:");
                Query.ShowMapQuery(context);
                int mapName = int.Parse(Console.ReadLine());
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
            Console.WriteLine($"Map name: {map.MapName}\nMap MaxMoves: {map.MaxMoves}\nMap Id: {map.Id}");
            Console.ReadKey();
            context.SaveChanges();
        }


        public int ChooseMap(EntityContext context, int mapId)
        {
            //1. Skriva ut kartor
            //2. Hämta input från consol
            //3. Returnera id för vald karta
            if (!Query.DoesMapExist(context, mapId))
                Console.WriteLine("Invalid map");
            else
                GetMapById(context, mapId);

            Console.WriteLine($"Map name: {map.MapName}\nMap MaxMoves: {map.MaxMoves}\nMap Id: {map.Id}");
            return map.Id;
        }

        public static Map GetMapById(EntityContext context, int mapId)
        {
            // Search for map in context
            var chooseQuery = from map in context.Maps
                              where map.Id == mapId
                              select new
                              {
                                  id = map.Id,
                                  name = map.MapName
                              };
            foreach (var map in chooseQuery)
            {
                Console.WriteLine($"You chose: {map.id}, Map name: {map.name}\n");
                Console.ReadKey();
                // If map exists, return map.
                if (map.id == mapId)
                    return new Map(map.id, map.name);
                // Else return null.
                else
                    return null;
            }
            return null;

        }
    }
}
