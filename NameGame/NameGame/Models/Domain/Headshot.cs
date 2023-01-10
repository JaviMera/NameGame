namespace NameGame.Models.Domain
{
    public sealed class Headshot
    {
        public int Id { get; set; }
        public string HeadshotId { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string? Alt { get; set; }
        public string? Url { get; set; }
        public string? Type { get; set; }
        public string? MimeType { get; set; }

        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
