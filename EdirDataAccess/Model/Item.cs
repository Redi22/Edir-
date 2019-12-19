using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdirDataAccess.Model
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime PurchasedDate { get; set; }
        public DateTime DailyPayment { get; set; }
        public double DamageFee { get; set; }
        public int Quantity { get; set; }


        public ICollection<Rental> Rents { get; set; }
    }
}
