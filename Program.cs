// This system is about Billiard Table Management. This is the basic program I came up with base on the previous lesson tackled.
// This system will further improve as we are taught more and as I learn more about the langauge
// The First 3 functions of my program are View, Add and remove 
// 2nd push: method added 
// Improvements to do: replace the if else with switch case for better readability and more maintable, Add exit Option, Add more tables,
// Add more functions like update, search, and history.
// 3rd push: UI and BusinessData Logic Separated, Changed the if-else to swtich 
// Improvements to do: using of arrays or list
// 4th Push: Done (CRUD Function with Data Layer)
// To DO: use enums instead of number literals as per ma'am suggestion

using Bilyaran_BusinessDataLogic;
using BilyarDataLayer;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using BilyarCommon;
using System.Numerics;

namespace BilliardTableManagement
{

    internal class Program
    {
        static bilyarProcessDBL Process = new bilyarProcessDBL(4); 
        static BilyarDL bilyarDataLayer = new BilyarDL();


        static void Main(string[] args)
        {


           // Process = new bilyarProcessDBL(4); //initialize the table size
            while (true)
            {
                DisplayOptions(); //Displays yung option sa loop
                Console.Write("\nPlease Enter Selected NUMBER HERE: ");
                int chosenNumber = Convert.ToInt16(Console.ReadLine());
                switch ((Menu)chosenNumber)
                {
                    case Menu.TablesCategories:
                        DisplayTableCategories();
                        break;
                    case Menu.TablesAvailability:
                        ViewTables();
                        break;
                    case Menu.AddPlayers:
                        AddPlayers();
                        break;
                    case Menu.UpdatePlayers:
                        UpdatePlayers();
                        break;
                    case Menu.RemovePlayers:
                        RemovePlayers();
                        break;
                    case Menu.Exit:
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
            List<TableCommon> tables = new List<TableCommon>
    {
        new TableCommon("Table 1", "Regular Table (MAXIMA 7)", 100.0, new List<string>{"4 TAKO",
                    "Ventilation",
                    "Free WIFI"}),
        new TableCommon("Table 2", "Regular Table (MAXIMA 7)", 100.0, new List<string>{"Complete Set",
                    "4 TAKO",
                    "Ventilation",
                    "Free WIFI" }),
                    new TableCommon("Table 3", "VIP ROOM (MAXIMA 7)", 250.0, new List<string>{"Complete Set",
                    "8 TAKO",
                    "Air-conditioned Room",
                    "Free WIFI",
                    "Water Dispenser",
                        "Videoke" }),
                    new TableCommon("Table 4", "VIP ROOM (MAXIMA 8)", 400.0, new List<string>{" Complete Set",
                    "8 TAKO",
                    "Air-conditioned Room",
                    "Free WIFI",
                    "Water Dispenser",
                    "Videoke",
                    "Darts",
                    "Chess",
                    "Card Games" }),
    };

            foreach (var table in tables)
            {
                Console.WriteLine(table.Name + " : " + table.Category + " PHP " + table.Price +
                    "\nInclusions:\n" + string.Join("\n", table.Inclusions));
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
            Console.Write("Enter a Table Number to Add Players [1-4]: ");

            if (int.TryParse(Console.ReadLine(), out int tableNumber))
            {
                if (tableNumber >= 1 && tableNumber <= Process.GetTables().Count)
                {
                    if (string.IsNullOrWhiteSpace(Process.GetTableStatus(tableNumber)))
                    {
                        Console.Write("Enter Player One Name: ");
                       string PlayerOne = Console.ReadLine();
                        Console.Write("Enter Player Two Name: ");
                       string PlayerTwo = Console.ReadLine();

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
            Console.Write("Enter the Table Number to Update Players [1-4]: ");
            if (int.TryParse(Console.ReadLine(), out int tableNumber))
            {
                if (tableNumber >= 1 && tableNumber <= Process.GetTables().Count)
                {
                    if (!string.IsNullOrWhiteSpace(Process.GetTableStatus(tableNumber)))
                    {
                        Console.Write("Enter Player One Name: ");
                       string PlayerOne = Console.ReadLine();
                        Console.Write("Enter Player Two Name: ");
                       string PlayerTwo = Console.ReadLine();
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
            Console.Write("Enter a Table Number to Remove Players [1-4]: ");

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
    enum Menu
    {
        TablesCategories = 1,
        TablesAvailability,
        AddPlayers,
        UpdatePlayers,
        RemovePlayers,
        Exit
    }

}