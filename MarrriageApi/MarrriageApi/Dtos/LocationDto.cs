namespace MarrriageApi.Dtos
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
    }

    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
