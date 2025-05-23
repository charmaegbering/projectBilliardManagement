using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilyarCommon
{
    public class TableCommon
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public List<string> Inclusions { get; set; } = new List<string>();

        public TableCommon() { }
        public TableCommon(string name, string category, double price, List<string> inclusions)
        {
            Name = name;
            Category = category;
            Price = price;
            Inclusions = inclusions;
        }

    }
}
