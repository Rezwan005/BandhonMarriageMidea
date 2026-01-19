using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marriage.Core.Entity
{
    public class BiodataGeneralInfo
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string BiodataType { get; set; }   // বায়োডাটার ধরণ

        [Required]
        [MaxLength(30)]
        public string MaritalStatus { get; set; } // বৈবাহিক অবস্থা

        [Required]
        [MaxLength(200)]
        public DateTime BirthDate { get; set; }    // জন্মনিবন্ধন / জন্মস্থান
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(20)]
        public string Height { get; set; }

        [Required]
        [MaxLength(20)]
        public string SkinTone { get; set; }

        [Required]
       
        public int Weight { get; set; }

        [Required]
        [MaxLength(10)]
        public string BloodGroup { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nationality { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
