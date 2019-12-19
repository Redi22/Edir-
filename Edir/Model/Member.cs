using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edir.Model
{
    public class Member
    {
        [Key]
        public long Id { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string MotherName { get; set; }
        public string Gender { get; set; }
        public bool MariageStatus { get; set; }
        public string SubCity  { get; set; }
        public long Woreda { get; set; }
        public long Kebele { get; set; }
        public long PhoneNumber { get; set; }
        public string HouseNummber { get; set; }
        public double Debit { get; set; }
        public DateTime RegisteredDate { get; set; }
        public bool PayStatus { get; set; }
        public bool AttendStatus { get; set; }

        public ICollection<Child> Children { get; set; }
        public ICollection<Sibling> Siblings { get; set; }
        public ICollection<SpouseSibling> SpouseSiblings { get; set; }

    }
}
