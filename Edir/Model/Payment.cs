using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edir.Model
{
    public class Pay
    {
        public long Id { get; set; }
        public long MemberId { get; set; }
        public double Amount { get; set; }
        public DateTime PaidDate { get; set; }
        public String Type { get; set; }

        [ForeignKey("MemberId")]
        public Member Member { get; set; }
    }       
}
