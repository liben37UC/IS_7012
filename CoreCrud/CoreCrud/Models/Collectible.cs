using System;
using System.Collections.Generic;

namespace CoreCrud.Models
{
    public class Collectible
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public decimal Weight { get; set; }

        public bool Electronic { get; set; }

        public string Material { get; set; }

        public virtual ICollection<Manufacturer> Manufacturers { get; set; }
    }
}