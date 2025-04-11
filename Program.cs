// This system is about Billiard Table Management. This is the basic program I came up with base on the previous lesson tackled.
// This system will further improve as we are taught more and as I learn more about the langauge
// The First 3 functions of my program are View, Add and remove 
// 2nd push: method added 
// Improvements to do: replace the if else with switch case for better readability and more maintable, Add exit Option, Add more tables,
// Add more functions like update, search, and history.
// 3rd push: UI and BusinessData Logic Separated, Changed the if-else to swtich 
// Improvements to do: using of arrays or list

using Bilyaran_BusinessDataLogic;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace BilliardTableManagement
{

    internal class Program
    {
        static bilyarProcessDBL Process;
        static string PlayerOne;
        static string PlayerTwo;

        static List<string> TableList = new List<string> { "Table 1", "Table 2", "Table 3", "Table 4" };
        static List<string> TableCategories = new List<string> { "Regular Table (MAXIMA 7)", "Regular Table (MAXIMA 7)", "VIP ROOM (MAXIMA 7)", "VIP ROOM (MAXIMA 8)" };
        static List<double> TablePrices = new List<double> { 100.0, 100.0, 250.0, 350.0 };
        static List<List<string>> Inclusion = new List<List<string>>
            {
            new List<string> { "Ventilated Area", "Free Wifi\n" },
            new List<string> { "Ventilated Area", "Free Wifi\n" },
            new List<string> { "Air-conditioned Room", "Free Wifi", "Free use of Water Dispenser", "Free Use of Videoke\n" },
            new List<string> { "Air-conditioned Room", "Free Wifi", "Free use of Water Dispenser", "Free Use of Videoke", "Free Games: Darts, Chess, Uno Cards\n" }

        };


        static void Main(string[] args)
        {


            Process = new bilyarProcessDBL(4); //Initialize the process with the player names and number of tables
            while (true)
            {
                DisplayOptions(); //Displays yung option sa loop
                Console.Write("\nPlease Enter Selected NUMBER HERE: ");
                int chosenNumber = Convert.ToInt16(Console.ReadLine());
                switch (chosenNumber)
                {
                    case 1:
                        DisplayTableCategories();
                        break;
                    case 2:
                        ViewTables();
                        break;
                    case 3:
                        AddPlayers();
                        break;
                    case 4:
                        UpdatePlayers();
                        break;
                    case 5:
                        RemovePlayers();
                        break;
                    case 6:
                        Console.WriteLine("Thank you and Goodbye sa Bilyaran ni Kuya ......");
                        return;
                    default:
                        Console.WriteLine("The Number Entered is INVALID. Please Try Again ...... ");
                        break;
                }
            }
        }

        static void DisplayOptions()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("1. Tables Categories and Prices "); //READ od DISPLAY categories of each tables
            Console.WriteLine("2. View Billiard Table Availability"); //READ  
            Console.WriteLine("3. Select and Add Players to a Table"); //CREATE or ADD new matches to selected tables
            Console.WriteLine("4. Update Players From a Table"); //UPDATE the playing players into new players
            Console.WriteLine("5. Remove Players From a Table"); //DELETE or remove players to a selected Table 
            Console.WriteLine("6. Exit"); 
            Console.WriteLine("-----------------------------------------------------");
        }
        static void DisplayTableCategories()
        {
            Console.WriteLine("\nThe Billiard Tables are Listed Below: ");
            for (int i = 0; i < TableList.Count; i++)
            {
                Console.WriteLine(TableList[i] + " : " + TableCategories[i] + "|" + "PHP "+ TablePrices[i] + "| " + "\nInclusions: \n" + string.Join("\n", Inclusion[i]));
            }
            Console.WriteLine("-----------------------------------------------------");
            
        }
        static void ViewTables()
        {
            Console.WriteLine("\n***The Billiard Tables are Listed Below: ***");
            for (int i = 0; i < Process.GetTables().Count; i++)
            {
                string PlayerMatch = Process.GetTableStatus(i + 1);
                if (string.IsNullOrWhiteSpace(PlayerMatch))
                {
                    Console.WriteLine("Table " + (i + 1) + " : [AVAILABLE]");
                }
                else
                {
                    Console.WriteLine("Table " + (i + 1) + " : " + PlayerMatch + " [CURRENTLY OCCUPIED]");
                }
            }
        }
        
        static void AddPlayers()
        {
            Console.Write("Enter a Table NUMBER to ADD an Opponent [1-4]: ");

            if (int.TryParse(Console.ReadLine(), out int tableNumber))
            {
                if (tableNumber >= 1 && tableNumber <= Process.GetTables().Count)
                {
                    if (string.IsNullOrWhiteSpace(Process.GetTableStatus(tableNumber)))
                    {
                        Console.Write("Enter Player One Name: ");
                        PlayerOne = Console.ReadLine();
                        Console.Write("Enter Player Two Name: ");
                        PlayerTwo = Console.ReadLine();

                        Process.SetAssignPlayers(tableNumber, PlayerOne, PlayerTwo);
                        Console.WriteLine("Table " + tableNumber + " : " + PlayerOne + " VERSUS " + PlayerTwo);

                    }
                    else
                    {
                        Console.WriteLine("Table " + tableNumber + " : " + " [CURRENTLY OCCUPIED] ");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
        static void UpdatePlayers()
        {
            Console.Write("Enter the Table Number [1-4]: ");
            if(int.TryParse(Console.ReadLine(), out int tableNumber))
            {
                if (tableNumber >= 1 && tableNumber <= Process.GetTables().Count)
                {
                    if (!string.IsNullOrWhiteSpace(Process.GetTableStatus(tableNumber)))
                    {
                        Console.Write("Enter Player One Name: ");
                        PlayerOne = Console.ReadLine();
                        Console.Write("Enter Player Two Name: ");
                        PlayerTwo = Console.ReadLine();
                        Process.SetAssignPlayers(tableNumber, PlayerOne, PlayerTwo);
                        Console.WriteLine("Table " + tableNumber + " : " + PlayerOne + " VERSUS " + PlayerTwo + "[UPDATED]");
                    }
                    else
                    {
                        Console.WriteLine("Table " + tableNumber + " : " + "is [AVAILABLE]. Unable to Update Players");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input. Please Try Again .......");
                }
            }
        }
        static void RemovePlayers()
        {
            Console.Write("Enter a Table NUMBER to REMOVE an Opponent [1-3]: ");

            if (int.TryParse(Console.ReadLine(), out int tableNumber))
            {
                if (tableNumber >= 1 && tableNumber <= Process.GetTables().Count)
                {
                    Process.RemovePlayers(tableNumber);
                    Console.WriteLine("Opponent sucessfully removed from: " + tableNumber);
                }
                else
                {
                    Console.WriteLine("Invalid Input. Please Try Again .......");
                }
            }
        }
    }
}



