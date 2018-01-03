using System.Collections.Generic;
using System;

namespace CastleGrimtol.Project
{
    public class Item : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean Available { get; set; }

    }
}