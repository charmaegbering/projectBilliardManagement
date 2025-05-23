using BilyarCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BilyarDataLayer;
namespace BilyarDataLayer
{
    public class BilyarInMemoryData : IBilyarDataLayer
    {
        private readonly List<TableCommon> tables = new();
        public BilyarInMemoryData()
        {
            CreateDummyTables();
        }
        private void CreateDummyTables()
        {

            tables.Add(new TableCommon
            {
                Name = "Table 1",
                Category = "Regular Table (MAXIMA 7)",
                Price = 100.0,
                Inclusions = new List<string>
                {
                    "Complete Set",
                    "4 TAKO",
                    "Ventilation",
                    "Free WIFI"
                }
            });
            tables.Add(new TableCommon
            {
                Name = "Table 2",
                Category = "Regular Table (MAXIMA 7)",
                Price = 100.0,
                Inclusions = new List<string>
                {
                    "Complete Set",
                    "4 TAKO",
                    "Ventilation",
                    "Free WIFI"
                }
            });
            tables.Add(new TableCommon
            {
                Name = "Table 3",
                Category = "VIP ROOM (MAXIMA 7)",
                Price = 250.0,
                Inclusions = new List<string>
                {
                    "Complete Set",
                    "8 TAKO",
                    "Air-conditioned Room",
                    "Free WIFI",
                    "Water Dispenser",
                    "Videoke"
                }
            });
            tables.Add(new TableCommon
            {
                Name = "Table 4",
                Category = "VIP Room (MAXIMA 8)",
                Price = 400.0,
                Inclusions =
                {
                    "Complete Set",
                    "8 TAKO",
                    "Air-conditioned Room",
                    "Free WIFI",
                    "Water Dispenser",
                    "Videoke",
                    "Darts",
                    "Chess",
                    "Card Games"
                }
            });
        }
        public IReadOnlyList<TableCommon> GetTables()
        {
            return tables.AsReadOnly();
        }

        public void CreateTable(TableCommon table)
        {
            tables.Add(table);
        }

        public void UpdateTable(string tableName, TableCommon updatedTable)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].Name == tableName)
                {
                    tables[i] = updatedTable;
                    break;
                }
            }
        }

        public void RemoveTable(TableCommon table)
        {
            tables.RemoveAll(t => t.Name == table.Name);
        }
    }
}