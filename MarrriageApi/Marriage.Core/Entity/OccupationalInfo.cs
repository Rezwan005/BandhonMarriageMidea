using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marriage.Core.Entity
{
    public class OccupationalInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Profession { get; set; }
        public string ProfessionDetails { get; set; }
        public string MonthlyIncome { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
    }

}
