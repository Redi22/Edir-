using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdirDataAccess.Model
{
    public class Spouse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }

        public long ParentId { get; set; }
        [ForeignKey("ParentId")]
        public Member Parent { get; set; }

    }
}
