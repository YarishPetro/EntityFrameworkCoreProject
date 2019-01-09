using System;
using System.Collections.Generic;

namespace DALModel
{
    public partial class Players
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public int TeamId { get; set; }
        public virtual Teams Team { get; set; }
    }
}
