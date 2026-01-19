namespace MarrriageApi.Dtos
{
    public class BiodataSearchRequest
    {
        public string? BiodataNo { get; set; }
        public string? BiodataType { get; set; }
        public string? MaritalStatus { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
    }
}
