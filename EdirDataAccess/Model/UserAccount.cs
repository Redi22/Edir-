using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdirDataAccess.Model
{
    public class UserAccount
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        
        public long MemberId { get; set; }

        [ForeignKey("MemberId")]
        public Member Member { get; set; }

    }
}
