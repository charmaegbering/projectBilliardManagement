using BilyarCommon;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace BilyarDataLayer
{
    public class BilyarJsonData : IBilyarDataLayer
    {
        private readonly string JsonFilePath = "BilyarList.json";
        private static List<TableCommon> tables = new();


        public BilyarJsonData()
        {
            LoadJsonData();
        }
        private void LoadJsonData()
        {
            if (File.Exists(JsonFilePath))
            {
                string JsonData = File.ReadAllText(JsonFilePath);
                tables = JsonSerializer.Deserialize<List<TableCommon>>(JsonData,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    })
                    ?? new List<TableCommon>();

            }
            else
            {
                tables = new List<TableCommon>();
                JsonDataToFile();
            }
        }
        private void JsonDataToFile()
        {
            string JsonData = JsonSerializer.Serialize(tables, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(JsonFilePath, JsonData);
        }

        public IReadOnlyList<TableCommon> GetTables()
        {
            return tables.AsReadOnly();
        }
        public void CreateTable(TableCommon table)
        {
            tables.Add(table);
            JsonDataToFile();
        }
        public void UpdateTable(string tableName, TableCommon updatedTable)
        {
            var index = tables.FindIndex(t => t.Name == tableName);
            if (index != -1)
            {
                tables[index] = updatedTable;
                JsonDataToFile();
            }
        }
        public void RemoveTable(TableCommon table)
        {
            var index = tables.FindIndex(t => t.Name == table.Name);
            if (index != -1)
            {
                tables.RemoveAt(index);
                JsonDataToFile();
            }

        }
    }
}

