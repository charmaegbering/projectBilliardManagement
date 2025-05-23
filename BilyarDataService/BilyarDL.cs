using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using BilyarCommon;

namespace BilyarDataLayer
{
    public class BilyarDL
    {
        IBilyarDataLayer bilyarDataLayer;
        public BilyarDL()
        {
            //bilyarDataLayer = new BilyarInMemoryData();
            //bilyarDataLayer = new BilyarJsonData();
            bilyarDataLayer = new BilyarTextFileData();
        }

        public IReadOnlyList<TableCommon> GetTables() => bilyarDataLayer.GetTables();
        public void CreateTable(TableCommon table) => bilyarDataLayer.CreateTable(table);
        public void UpdateTable(string tableName, TableCommon updatedTable) =>
           bilyarDataLayer.UpdateTable(tableName, updatedTable);

        public void RemoveTable(TableCommon table)
        {
            bilyarDataLayer.RemoveTable(table);
        }

    }

}