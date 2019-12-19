using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdirDataAccess.Model
{
    public class MemberRole
    {
        public long Id { get; set; }

        public long MemberId { get; set; }

        public long RoleId { get; set; }

        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

    }
}
