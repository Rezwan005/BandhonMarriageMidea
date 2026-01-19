using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marriage.Core.Entity
{
    public class BioSteps
    {
        public int Id { get; set; }
        public int StepId { get; set; }
        public string StepName { get; set; }
        public int StepOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
