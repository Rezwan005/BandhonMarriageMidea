using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marriage.Core.Entity
{
    public class Upazila
    {
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }

        public District District { get; set; }
        public ICollection<Union> Unions { get; set; }
    }
}
