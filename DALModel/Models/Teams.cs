using System;
using System.Collections.Generic;

namespace DALModel
{
    public partial class Teams
    {
        public Teams()
        {
            Players = new List<Players>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual List<Players> Players { get; set; }
    }
}
