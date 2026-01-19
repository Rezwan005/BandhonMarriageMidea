using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marriage.Core.Entity
{
    public class PersonalInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DressOutside { get; set; }
        public string DiseaseInfo { get; set; }
        public string SpecialWork { get; set; }
        public string AboutYourself { get; set; }
        public string MobileNo { get; set; }
        public string SelfiePath { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
    }
}
