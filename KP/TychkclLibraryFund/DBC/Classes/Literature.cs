using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DBC.Classes
{
    public class Literature
    {
        public int? Id { get; set; }
        public byte[]? Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public int TypeId { get; set; }
        public int Price { get; set; }
    }
}
