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
         string player = "Chame";
         string opponentTable1 = " ";
         string opponentTable2 = " ";
         string opponentTable3 = " ";

        public string GetPlayer()
        {
            return player;           
        }
        public string GetOpponentTable1() 
        { 
            return opponentTable1;
        }
        public string GetOpponentTable2() 
        { 
            return opponentTable2;
        }
        public string GetOpponentTable3() 
        { 
            return opponentTable3;
        }


        public void SetOpponentTable1(string opponentName)
        {
            opponentTable1 = opponentName;
        }
        public void SetOpponentTable2(string opponentName)
        {
            opponentTable2 = opponentName;
        }
        public void SetOpponentTable3(string opponentName)
        {
            opponentTable3 = opponentName;
        }
        }
    }
