using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdirDataAccess.Model
{
    public class Loss
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public double PaidMoney { get; set; }
        public DateTime Date { get; set; }


        public long ParentId { get; set; }
        [ForeignKey("ParentId")]
        public Member Parent { get; set; }
    }
}
