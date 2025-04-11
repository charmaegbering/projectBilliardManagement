
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Bilyaran_BusinessDataLogic
{
    public class bilyarProcessDBL
    {
        private List<string> Table;
        public bilyarProcessDBL(int TableList)
        {
       
            Table = new List<string>(new string[TableList]);
           
        }


        public string GetTableStatus(int TableNumber)
        {
            if (TableNumber >= 1 && TableNumber <= Table.Count)
            {
                return Table[TableNumber - 1];

            }
            return null;
        }
        public bool SetAssignPlayers(int TableNumber, string PlayerOne, string PlayerTwo)
        {
            if (TableNumber >= 1 && TableNumber <= Table.Count)
            {
                Table[TableNumber - 1] = PlayerOne + " VERSUS " + PlayerTwo;
                return true;
            }
            return false;
        }
        public bool RemovePlayers(int tableNumber)
        {
            if (tableNumber >= 1 && tableNumber <= Table.Count)
            {
                Table[tableNumber - 1] = "";
                return true;
            }
            return false;
        }
        public IReadOnlyCollection<string> GetTables()
        {
            return Table.AsReadOnly();
        }
        
    }
}
