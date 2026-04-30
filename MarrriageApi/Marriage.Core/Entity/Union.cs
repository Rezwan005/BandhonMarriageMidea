using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marriage.Core.Entity
{
    public class Union
    {
        public int Id { get; set; }
        public int UpazilaId { get; set; }
        public string Name { get; set; }

        public Upazila Upazila { get; set; }
    }
}
