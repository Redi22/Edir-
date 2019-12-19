using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdirDataAccess.Model
{
    public class Attendace
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public long MemberId { get; set; }


        [ForeignKey("MemberId")]
        public Member Memember { get; set; }

        [ForeignKey("EventId")]
        public EdirEvent Event { get; set; }

    }
}
