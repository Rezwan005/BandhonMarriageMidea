using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marriage.Core.Entity
{
    public class UserAddress
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        // ---------- Permanent Address ----------
        public string PermanentCountry { get; set; } = "Bangladesh";

        // IDs for dropdown selections
        public int? PermanentDivisionId { get; set; }
        public int? PermanentDistrictId { get; set; }
        public int? PermanentUpazilaId { get; set; }

        // Names for display / saving to DB
        public string PermanentDivision { get; set; } = string.Empty;
        public string PermanentDistrict { get; set; } = string.Empty;
        public string PermanentUpazila { get; set; } = string.Empty;

        public string PermanentVillage { get; set; } = string.Empty;
        public string PermanentRoad { get; set; } = string.Empty;
        public string PermanentHouse { get; set; } = string.Empty;

        // ---------- Current Address ----------
        public string CurrentCountry { get; set; } = "Bangladesh";

        // IDs for dropdown selections
        public int? CurrentDivisionId { get; set; }
        public int? CurrentDistrictId { get; set; }
        public int? CurrentUpazilaId { get; set; }

        // Names for display / saving to DB
        public string CurrentDivision { get; set; } = string.Empty;
        public string CurrentDistrict { get; set; } = string.Empty;
        public string CurrentUpazila { get; set; } = string.Empty;

        public string CurrentVillage { get; set; } = string.Empty;
        public string CurrentRoad { get; set; } = string.Empty;
        public string CurrentHouse { get; set; } = string.Empty;

        // ---------- Other Info ----------
        public string Hometown { get; set; } = string.Empty;
        public bool IsSameAddress { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
    }


}
