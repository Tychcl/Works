using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr45.Models
{
    public class Literature
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public int Price { get; set; }
    }
}
