using System;
using System.Collections.Generic;

namespace BilyarDataLayer
{
    public class BilyarDL
    {
        private static List<string> _tableNames = new List<string>
        {
            "Table 1", "Table 2", "Table 3", "Table 4"
        };
        //tables classifications/categories
        private static List<string> _tableCategories = new List<string>
        {
            "Regular Table (MAXIMA 7)", "Regular Table (MAXIMA 7)", "VIP ROOM (MAXIMA 7)", "VIP ROOM (MAXIMA 8)"
        };

        // prices base on what table
        private static List<double> _tablePrices = new List<double>
        { 
            100.0, 100.0, 250.0, 350.0
        };

        private static List<List<string>> _tableInclusions = new List<List<string>>
        {
            new List<string> { "Ventilated Area", "Free Wifi\n" },
            new List<string> { "Ventilated Area", "Free Wifi\n" },
            new List<string> { "Air-conditioned Room", "Free Wifi", "Free use of Water Dispenser", "Free Use of Videoke\n" },
            new List<string> { "Air-conditioned Room", "Free Wifi", "Free use of Water Dispenser", "Free Use of Videoke", "Free Games: Darts, Chess, Uno Cards\n" }
        };
        //for internal table data as read-only for preventing modifying from
        //external 
        //allow other class or part of the system/program to access the table data 
        public static IReadOnlyList<string> TableNames => _tableNames.AsReadOnly();
        public static IReadOnlyList<string> TableCategories => _tableCategories.AsReadOnly();
        public static IReadOnlyList<double> TablePrices => _tablePrices.AsReadOnly();
        public static IReadOnlyList<IReadOnlyList<string>> TableInclusions => _tableInclusions.ConvertAll
            (inclusion => (IReadOnlyList<string>)inclusion.AsReadOnly()); 
        public static string GetTableInfo(int index)
        {
            if (index >= 0 && index < _tableNames.Count)
            {
              return _tableNames[index] + " - " + _tableCategories[index] + "\n" +
                     "Price: " + _tablePrices[index] + "\n" +
                     "Inclusions: " + string.Join(", ", _tableInclusions[index]);
            }
            return "Invalid Table Index.";
        }
    }
}
