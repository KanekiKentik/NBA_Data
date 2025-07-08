using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA_DataBase
{
    internal class Player
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string position { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public string jersey_number { get; set; }
        public string college { get; set; }
        public string country { get; set; }
        public string draft_year { get; set; }
        public string draft_round { get; set; }
        public string draft_number { get; set; }
        public Team team { get; set; }

        public override string ToString()
        {
            return $"{first_name} {last_name}";
        }
    }
}
