namespace NameGame.Models.Domain
{
    public sealed class SocialLink
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? Type { get; set; }
        public string? CallToAction { get; set; }

        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
