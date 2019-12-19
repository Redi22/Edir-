using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdirDataAccess.Model
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime RentedDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Damaged { get; set; }

        public long ItemId { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }

    }
}
