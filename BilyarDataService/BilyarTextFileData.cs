using BilyarCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BilyarDataLayer
{
    public class BilyarTextFileData : IBilyarDataLayer
    {
        private readonly string TextFilePath = "BilyarList.txt";
        private List<TableCommon> tables = new();

        public BilyarTextFileData()
        {
            LoadFromFile();
        }
        private void LoadFromFile()
        {
            if (!File.Exists(TextFilePath))
            {
                tables = new List<TableCommon>();
                return;
            }
            var lines = File.ReadAllLines(TextFilePath);
            tables = lines.Select(line =>
            {
                var parts = line.Split('|');
                return new TableCommon
                {
                    Name = parts[0],
                    Category = parts[1],
                    Price = double.Parse(parts[2]),
                    Inclusions = parts[3].Split(',').ToList()
                };
            }).ToList();
        }
        private void SaveToFile()
        {
            var lines = tables.Select(table =>
            table.Name + "|" + table.Category + "|" + table.Price + "|" + string.Join(",", table.Inclusions));
            File.WriteAllLines(TextFilePath, lines);
        }
        public IReadOnlyList<TableCommon> GetTables()
        {
            return tables.AsReadOnly();
        }
        public void CreateTable(TableCommon table)
        {
            tables.Add(table);
            SaveToFile();
        }
        public void UpdateTable(string tableName, TableCommon updatedTable)
        {
            var index = tables.FindIndex(t => t.Name == tableName);
            if (index != 1)
            {

                tables[index] = updatedTable;
                SaveToFile();
            }

        }
        public void RemoveTable(TableCommon table)
        {
            var index = tables.FindIndex(t => t.Name == table.Name);
            if (index != -1)
            {
                tables.RemoveAt(index);
                SaveToFile();
            }
        }
    }
}

