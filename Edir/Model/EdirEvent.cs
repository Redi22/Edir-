using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edir.Model
{
    public class EdirEvent
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime date { get; set; }
        public string Description { get; set; }
        public double Fin { get; set; }

        public ICollection<Attendace> Attendees { get; set; }

    }
}
