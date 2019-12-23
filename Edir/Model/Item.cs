using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edir.Model
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime PurchasedDate { get; set; }
        public double DailyPayment { get; set; }
        public double SmallDamageFee { get; set; }
        public double DamageFee { get; set; }
        public double ReplacementFee { get; set; }
        public int Quantity { get; set; }
        public double SinglePrice { get; set; }
        public int RentedQuantity { get; set; }


        public ICollection<Rental> Rents { get; set; }
    }
}
