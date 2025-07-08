using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBC.Classes
{
    public class Refill
    {
        public int? Id { get; set; }
        public DateOnly Date { get; set; }

        public int? StaffId { get; set; }
        public int? LibraryId { get; set; }
        public int? LiteratureId { get; set; }


        public int Count { get; set; }
    }
}
