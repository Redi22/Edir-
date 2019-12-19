﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdirDataAccess.Model
{
    public class SpouseSibling
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public long Phone { get; set; }

        public long ParentId { get; set; }
        [ForeignKey("ParentId")]
        public Member Parent { get; set; }

    }
}
