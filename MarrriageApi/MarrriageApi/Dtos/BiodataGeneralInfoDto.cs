namespace MarrriageApi.Dtos
{
    public class BiodataGeneralInfoDto
    {
        public int UserId { get; set; }
        public string BiodataType { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
        public string SkinTone { get; set; }
        public int Weight { get; set; }
        public string BloodGroup { get; set; }
        public string Nationality { get; set; }
    }
}
