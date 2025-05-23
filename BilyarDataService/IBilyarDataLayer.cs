using BilyarCommon;
using System.Collections.Generic;


namespace BilyarDataLayer
{
    public interface IBilyarDataLayer
    {
        IReadOnlyList<TableCommon> GetTables();
        public void CreateTable(TableCommon table);
        public void UpdateTable(string tableName, TableCommon updatedTable);
        public void RemoveTable(TableCommon table);
    }
}
