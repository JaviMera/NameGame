namespace NameGame.Models.Domain
{
    public sealed class Employee
    {
        public string EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? JobTitle { get; set; }
        public string? Slug { get; set; }
        public string? Type { get; set; }

        public Headshot? Headshot { get; set; }
        public IEnumerable<SocialLink>? SocialLinks { get; set; }
    }
}
