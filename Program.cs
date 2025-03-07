// This system is about Billiard Table Management. This is the basic program I came up with base on the previous lesson tackled.
// This system will further improve as we are taught more and as I learn more about the langauge
//The First 3 functions of my program are View, Add and remove 
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
                Console.WriteLine("\n ************** WELCOME TO BILLIARD TABLE MANAGEMENT **************");
                Console.WriteLine("1. View Billiard Tables");
                Console.WriteLine("2. Add Opponent to a Table");
                Console.WriteLine("3. Remove Player from a Table");

                Console.Write("\n Please Enter Selected Number HERE: ");
                int chosenNum = Convert.ToInt16(Console.ReadLine());

                if (chosenNum == 1)
                {
                    Console.WriteLine("The Billiard Tables are Listed Below: ");

                    if (opponentTable1 == " ")
                    {
                        Console.WriteLine("Table 1 is AVAILABLE");
                    }
                    else
                    {
                        Console.WriteLine("Table 1: " + opponentTable1 + "[NOT AVAILABLE]");
                    }
                    if (opponentTable2 == " ")
                    {
                        Console.WriteLine("Table 2 is AVAILABLE");
                    }
                    else
                    {
                        Console.WriteLine("Table 2: " + opponentTable2 + "[NOT AVAILABLE]");
                    }
                    if (opponentTable3 == " ")
                    {
                        Console.WriteLine("Table 3 is AVAILABLE");
                    }
                    else
                    {
                        Console.WriteLine("Table 3: " + opponentTable3 + "[NOT AVAILABLE]");
                    }
                }
                else if (chosenNum == 2)
                {
                    Console.Write("Kindly Enter a Table Number from [1-3] HERE: ");
                    int tableNum = Convert.ToInt16(Console.ReadLine());

                    Console.Write("Enter Opponent's Name HERE: ");
                    string opponentName = Console.ReadLine();
                    string playerName = player + " Versus " + opponentName;

                    if (tableNum == 1)
                    {
                        if (opponentTable1 == " ")
                        {
                            opponentTable1 = playerName;
                            Console.WriteLine("Table 1:  " + playerName);
                        }
                        else
                        {
                            Console.WriteLine("Table 1 is NOT AVAILABLE as of the moment");
                        }
                    }
                    else if (tableNum == 2)
                    {
                        if (opponentTable2 == " ")
                        {
                            opponentTable2 = playerName;
                            Console.WriteLine("Table 2:  " + playerName);
                        }
                        else
                        {
                            Console.WriteLine("Table 2 is NOT AVAILABLE as of the moment");
                        }
                    }
                    else if (tableNum == 3)
                    {
                        if (opponentTable3 == " ")
                        {
                            opponentTable3 = playerName;
                            Console.WriteLine("Table 3:  " + playerName);
                        }
                        else
                            Console.WriteLine("Table 3 is NOT AVAILABLE as of the moment");
                    }
                }
                else if (chosenNum == 3)
                {
                    Console.Write("Kindly Enter a Table Number to REMOVE an Opponent [1-3]: ");
                    int opponentRemove = Convert.ToInt16(Console.ReadLine());

                    if (opponentRemove == 1)
                    {
                        if (opponentTable1 != " ")
                            opponentTable1 = " ";
                        else
                        {
                            Console.WriteLine("Table 1 is AVAILABLE");
                        }
                    }
                    else if (opponentRemove == 2)
                    {
                        if (opponentTable2 != " ")
                            opponentTable2 = " ";
                        else
                        {
                            Console.WriteLine("Table 2 is AVAILABLE");
                        }
                    }
                    else if (opponentRemove == 3)
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
                else
                {
                    Console.WriteLine("You Entered an INVALID Input. Please Try Again");
                }
            }

        }
    }
}



