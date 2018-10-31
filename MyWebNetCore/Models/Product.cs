using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebNetCore.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public uint CategoryId { get; set; }
        public string Images { get; set; }
        public DateTime Created_At { get; set; } 
        public DateTime Updated_At { get; set; } 
        public int Status { get; set; }
    }
}
