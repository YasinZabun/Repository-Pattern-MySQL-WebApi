using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
   public class Product
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public int UnitPrice { get; set; }

    }
}
