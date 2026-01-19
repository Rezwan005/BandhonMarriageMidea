namespace MarrriageApi.Dtos
{
    public class BioStepDto
    {
        public int StepId { get; set; }
        public string StepName { get; set; }
        public int StepOrder { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsAccessible { get; set; }
    }
}
