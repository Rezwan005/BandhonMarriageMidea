








namespace MarrriageApi.Dtos
{
    public class EducationDto
    {
        public string Method { get; set; }
        public string HighestDegree { get; set; }

        public string SscPY { get; set; }
        public string SscGroup { get; set; }
        public string SscResult { get; set; }
        public string SscInsName { get; set; }

        public string HscPY { get; set; }
        public string HscGroup { get; set; }
        public string HscResult { get; set; }
        public string HscInsName { get; set; }

        public string UgPY { get; set; }
        public string GSubject { get; set; }
        public string UgInsName { get; set; }

        public string OtherDetails { get; set; }

        public int UserId { get; set; }
    }

}
