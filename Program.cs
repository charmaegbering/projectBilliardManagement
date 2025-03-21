// This system is about Billiard Table Management. This is the basic program I came up with base on the previous lesson tackled.
// This system will further improve as we are taught more and as I learn more about the langauge
//The First 3 functions of my program are View, Add and remove 
// 2nd push: method added 
// Improvements to do: replace the if else with switch case for better readability and more maintable, Add exit Option, Add more tables,
// Add more functions like update, search, and history.
using System;
namespace billiardTableManagement1
{
    internal class Program
    {
        static string player = "Chame";
        static string opponentTable1 = " ";
        static string opponentTable2 = " ";
        static string opponentTable3 = " ";
        static void Main(string[] args)
        {
            while (true)
            {
                DisplayOptions();
                Console.Write("\nPlease Enter Selected NUMBER HERE: ");
                int chosenNum = Convert.ToInt16(Console.ReadLine());

                if (chosenNum == 1)
                {
                    Console.WriteLine("\n***The Billiard Tables are Listed Below: ***");
                    ViewTables();
                }
                else if (chosenNum == 2)
                {
                    AddOpponent();
                }
                else if (chosenNum == 3)
                {
                    RemovefromTable();

                }
                else
                {
                    Console.WriteLine("The Number Entered is INVALID. Please Try Again ...... ");
                }
            }
        }
            
        static void DisplayOptions()
        {
            Console.WriteLine("\n----------------- WELCOME TO BILLIARD TABLE MANAGEMENT -----------------");
            Console.WriteLine("1. View Billiard Table Availability");
            Console.WriteLine("2. Add Opponent to a Table: ");
            Console.WriteLine("3. Remove Opponent from a Table: ");
        }
        static void ViewTables()
        {
            DisplayTable(1, opponentTable1);
            DisplayTable(2, opponentTable2);
            DisplayTable(3, opponentTable3);
        }
        static void DisplayTable(int tableNumber, string opponentName)
        {
            if (opponentName == " ")
            {
                Console.WriteLine("Table " + tableNumber + " is AVAILABLE");
            }
            else
            {
                Console.WriteLine("Table " + tableNumber + ": " + opponentName + " [CURRENTLY OCCUPIED]");
            }
            }
            static void AddOpponent()
            {
                Console.Write("Kindly Enter a Table NUMBER to ADD an Opponent [1-3]: ");
                int tableNumber = Convert.ToInt16(Console.ReadLine());

                Console.Write("Enter Opponent's NAME HERE: ");
                string opponentName = Console.ReadLine();
                string playerName = player + " VERSUS " + opponentName;

                if (tableNumber == 1)
                {
                    if (opponentTable1 == " ")
                    {
                        opponentTable1 = playerName;
                        Console.WriteLine("Table 1: " + playerName);
                    }
                    else
                    {
                        Console.WriteLine("Table 1 is NOT AVAILABLE as of the moment");
                    }
                }
                else if (tableNumber == 2)
                {
                    if (opponentTable2 == " ")
                    {
                        opponentTable2 = playerName;
                        Console.WriteLine("Table 2: " + playerName);
                    }
                    else
                    {
                        Console.WriteLine("Table 2 is NOT AVAILABLE as of the moment");
                    }
                }
                else if (tableNumber == 3)
                {
                    if (opponentTable3 == " ")
                    {
                        opponentTable3 = playerName;
                        Console.WriteLine("Table 3: " + playerName);
                    }
                    else
                    {
                        Console.WriteLine("Table 3 is NOT AVAILABLE as of the moment");
                    }
                }
                else
                {
                    Console.WriteLine("The Number Entered is INVALID");
                }
            }
            static void RemovefromTable()
            {
                Console.Write("Kindly Enter a Table NUMBER to REMOVE an Opponent [1-3]: ");
                int removeOpponent = Convert.ToInt16(Console.ReadLine());

                if (removeOpponent == 1)
                {
                    if (opponentTable1 != " ")
                        opponentTable1 = " ";
                    else
                    {
                        Console.WriteLine("Table 1 is AVAILABLE");
                    }
                }
                else if (removeOpponent == 2)
                {
                    if (opponentTable2 != " ")
                        opponentTable2 = " ";
                    else
                    {
                        Console.WriteLine("Table 2 is AVAILABLE");
                    }
                }
                else if (removeOpponent == 3)
                {
                    if (opponentTable3 != " ")
                        opponentTable3 = " ";
                    else
                    {
                        Console.WriteLine("Table 3 is AVAILABLE");
                    }
                }
                else
                {
                    Console.WriteLine("The Number Entered is INVALID");
                }
            }
        }
    }






