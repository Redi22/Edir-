using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edir.Model
{
    public class DamagedGood
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public int Quantity { get; set; }
        public string RepairType { get; set; }
        public bool IsRepaired { get; set; }
        public string Description { get; set; }
    }
}
