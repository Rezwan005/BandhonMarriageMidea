namespace MarrriageApi.Dtos
{
    public class PersonalInfoDto
    {
        public int UserId { get; set; }
        public string DressOutside { get; set; }
        public string DiseaseInfo { get; set; }
        public string SpecialWork { get; set; }
        public string AboutYourself { get; set; }
        public string MobileNo { get; set; }
        public IFormFile Selfie { get; set; }
    }
}
