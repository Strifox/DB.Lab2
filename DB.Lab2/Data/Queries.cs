using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Lab2
{
    class Queries
    {

        #region Player Queries
        public void ChoosePlayerQuery(EntityContext context)
        {
            var chooseQuery = from choose in context.Players
                              where choose.Id == Int32.Parse(Console.ReadLine())
                              select choose;

            foreach (var player in chooseQuery)
            {
                Console.WriteLine(player);
            }
        }
        public void EditPlayerNameQuery(EntityContext context)
        {
            Console.WriteLine("Type your new name");
            var nameQuery = from name in context.Players
                            where name.Name == Console.ReadLine()
                            select name;

            foreach (var player in nameQuery)
            {
                Console.WriteLine(player);
            }
        }
        #endregion  
    }
}
