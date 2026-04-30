using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marriage.Core.Entity
{
    public class District
    {
        public int Id { get; set; }
        public int DivisionId { get; set; }
        public string Name { get; set; }

        public Division Division { get; set; }
        public ICollection<Upazila> Upazilas { get; set; }
    }
}
