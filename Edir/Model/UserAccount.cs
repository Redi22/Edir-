using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edir.Model
{
    public class UserAccount
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime AdminUpgradeDate { get; set; }


        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
