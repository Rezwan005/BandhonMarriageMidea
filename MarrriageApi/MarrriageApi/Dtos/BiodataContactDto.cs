namespace MarrriageApi.Dtos
{
    public class BiodataContactDto
    {
        public int UserId { get; set; }
        public string GroomName { get; set; } = null!;
        public string GuardianMobile { get; set; } = null!;
        public string GuardianRelation { get; set; } = null!;
        public string BiodataEmail { get; set; } = null!;
    }
}
