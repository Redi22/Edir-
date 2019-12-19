using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edir.Model
{
    public class About
    {
        public long Id { get; set; }
        public string EdirName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PayDate { get; set; }
        public double Capital { get; set; }
        public string Description { get; set; }
        public double PayMemberDeseced { get; set; }
        public double MonthlyPayment { get; set; }
        public double PayChildDeseced { get; set; }
        public double PaySiblingDeseced { get; set; }
        public double PayParentDeseced { get; set; }
        public double DefaultFirstFin { get; set; }
        public double DefaultSecondFin { get; set; }
        public double DefaultFinalFin { get; set; }
        public double DefaultEventFin { get; set; }
        public bool CustomSubcity { get; set; }
    }
}
