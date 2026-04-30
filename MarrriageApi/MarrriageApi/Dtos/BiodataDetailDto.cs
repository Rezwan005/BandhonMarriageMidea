using Marriage.Core.Entity;

namespace MarrriageApi.Dtos
{
    public class BiodataDetailDto
    {
        public string BiodataNo { get; set; }
        public string Status { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public GeneralInfoDto GeneralInfo { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public OccupationalInfoDto OccupationalInfo { get; set; }
        public EducationDto Education { get; set; }
        public AddressDto Address { get; set; }
        public BiodataContactDto Contact { get; set; }
    }
}
