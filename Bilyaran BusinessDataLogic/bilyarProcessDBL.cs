using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilyaran_BusinessDataLogic
{
    public class bilyarProcessBDL
    {
        private string player = "Chame";
        private List<string> opponentTable;

        public bilyarProcessBDL() : this("Chame", 3)
        {
        }

        public bilyarProcessBDL(string playerName, int tableList)
        {
            player = playerName;
            opponentTable = new List<string>(new string[tableList]);
        }
        public string GetPlayer()
        {
            return player;           
        }
        public string GetOpponent(int tableNumber) 
        { 
            if(tableNumber >= 1 && tableNumber <= opponentTable.Count)
            {
                return opponentTable[tableNumber -1 ];

            }
            return null;
        }
        public void SetOpponentTable(int tableNumber, string opponentName)
        {
            if (tableNumber >= 1 && tableNumber <= opponentTable.Count)
            {
                opponentTable[tableNumber - 1] = opponentName;
            }
        }
        public void RemoveOpponent(int tableNumber)
        {
            if (tableNumber >= 1 && tableNumber <= opponentTable.Count)
            {
                opponentTable[tableNumber - 1] = "";
            }
        }
        public List<string> GetTables() 
        {
            return opponentTable;
        }
        }
    }
