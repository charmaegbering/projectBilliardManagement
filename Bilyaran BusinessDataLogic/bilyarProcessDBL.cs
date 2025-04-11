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
        //private string PlayerOne;
        //private string PlayerTwo;
        private List<string> Table;
      

        public bilyarProcessDBL(int TableList)
        {
            //PlayerOne = FirstPlayer;
            //PlayerTwo = SecondPlayer;
            Table = new List<string>(new string[TableList]);
            //PlayersToAssign(1, FirstPlayer, SecondPlayer);
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
        public List<string> GetTables()
        {
            return Table;
        }
        private void PlayersToAssign(int tableNumber, string PlayerOne, string PlayerTwo)
        {
            if (tableNumber >=1 && tableNumber <= Table.Count)
            {
                Table[tableNumber - 1] = PlayerOne + " VERSUS " + PlayerTwo;
            }
            else
            {
                Console.WriteLine("Table Number is INVALID. Please Try Again ...... ");
            }
        }
    }
}
