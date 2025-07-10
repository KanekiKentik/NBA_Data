using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA_DataBase
{
    internal class Team
    {
        public int id { get; set; }
        public string conference { get; set; }
        public string division { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public string abbreviation { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
