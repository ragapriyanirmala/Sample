namespace Sample.Services.DTOs
{
    public class BranchDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? BranchImageUrl { get; set; }
    }
}
