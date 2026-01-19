using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marriage.Core.Entity
{
    public class BiodataContact
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string GroomName { get; set; } = null!;
        public string GuardianMobile { get; set; } = null!;
        public string GuardianRelation { get; set; } = null!;
        public string BiodataEmail { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

}
