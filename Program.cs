// This system is about Billiard Table Management. This is the basic program I came up with base on the previous lesson tackled.
// This system will further improve as we are taught more and as I learn more about the langauge
//The First 3 functions of my program are View, Add and remove 
// 2nd push: method added 
// Improvements to do: replace the if else with switch case for better readability and more maintable, Add exit Option, Add more tables,
// Add more functions like update, search, and history.
// 3rd push: UI and BusinessData Logic Separated, Changed the if-else to swtich 
// Improvements to do: using of arrays or list

using Bilyaran_BusinessDataLogic;
using System;
using System.Reflection;

namespace BilliardTableManagement
{
    internal class Program
    {
        static bilyarProcessBDL process = new bilyarProcessBDL();

        static void Main(string[] args)
        {
            while (true)
            {
                DisplayOptions(); //Displays the option which runs through a loop
                Console.Write("\nPlease Enter Selected NUMBER HERE: ");
                int chosenNumber = Convert.ToInt16(Console.ReadLine());
                switch (chosenNumber) //switch case for more maintainable and readable structure
                {
                    case 1:
                        ViewTables(); //views the all the table and shows if its available or occupied
                        break;
                    case 2:
                        AddOpponent(); //puts opponent to their desired table along side the initialized other player 
                        break;
                    case 3:
                        RemoveOpponent(); //manually removes an opponent to a table 
                        break;
                    case 4:
                        Console.WriteLine("Thank you and Goodbye sa Bilyaran ni Kuya ......");
                        return; //exits the system
                    default:
                        Console.WriteLine("The Number Entered is INVALID. Please Try Again ...... ");
                        break;
                }
            }
        }

        static void DisplayOptions()
        {
            Console.WriteLine("\n----------------- WELCOME TO BILYARAN NI KUYA -----------------");
            Console.WriteLine("1. View Billiard Table Availability");
            Console.WriteLine("2. Add Opponent to a Table");
            Console.WriteLine("3. Remove Opponent from a Table");
            Console.WriteLine("4. Exit");
        }

        static void ViewTables()
        {
            Console.WriteLine("\n***The Billiard Tables are Listed Below: ***");
            DisplayTable(1, process.GetPlayer(), process.GetOpponentTable1());
            DisplayTable(2, process.GetPlayer(), process.GetOpponentTable2());
            DisplayTable(3, process.GetPlayer(), process.GetOpponentTable3());
        }
        static void DisplayTable(int tableNum, string player, string opponentName)
        {
            if (opponentName == " ")
            {
                Console.WriteLine("Table " + tableNum + " : " + " [AVAILABLE] ");
            }
            else
            {
                Console.WriteLine("Table " + tableNum + " : " + player + " [VERSUS] " + opponentName + " [CURRENTLY OCCUPIED] ");
            }
        }

        static void AddOpponent()
        {
            Console.Write(" Enter a Table NUMBER to ADD an Opponent [1-3]: ");
            int tableNumber = Convert.ToInt16(Console.ReadLine());


            if (tableNumber == 1)
                if (process.GetOpponentTable1() == " ")
                {
                    Console.Write("Enter the Opponent's NAME: ");
                    string opponentName = Console.ReadLine();
                    process.SetOpponentTable1(opponentName);
                    Console.WriteLine("Table " + tableNumber + " : " + process.GetPlayer() + " [VERSUS] " + opponentName);
                }
                else
                {
                    Console.WriteLine("Table " + tableNumber + " : " + " [CURRENTLY OCCUPIED] ");
                }

            else if (tableNumber == 2)
                if (process.GetOpponentTable2() == " ")
                {
                    Console.Write("Enter the Opponent's NAME: ");
                    string opponentName = Console.ReadLine();
                    process.SetOpponentTable2(opponentName);
                    Console.WriteLine("Table " + tableNumber + " : " + process.GetPlayer() + " [VERSUS] " + opponentName);
                }
                else
                {
                    Console.WriteLine("Table " + tableNumber + " : " + " [CURRENTLY OCCUPIED] ");
                }
            else if (tableNumber == 3)
                if (process.GetOpponentTable3() == " ")
                {
                    Console.Write("Enter the Opponent's NAME: ");
                    string opponentName = Console.ReadLine();
                    process.SetOpponentTable3(opponentName);
                    Console.WriteLine("Table " + tableNumber + " : " + process.GetPlayer() + " [VERSUS] " + opponentName);
                }
                else
                {
                    Console.WriteLine("Table " + tableNumber + " : " + " [CURRENTLY OCCUPIED] ");
                }
        else {
        Console.WriteLine("Invalid Number Entered. Please Try Again .........");
            }
}
        static void RemoveOpponent()
        {
            Console.Write("Enter a Table NUMBER to REMOVE an Opponent [1-3]: ");
            int tableNumber = Convert.ToInt16(Console.ReadLine());

            if (tableNumber == 1)
                process.SetOpponentTable1(" ");
            else if (tableNumber == 2)
                process.SetOpponentTable2(" ");
            else if (tableNumber == 3)
                process.SetOpponentTable3(" ");
            else 
                Console.WriteLine("Invalid Table Number. Please Try Again ...... ");
        }
    }
}

