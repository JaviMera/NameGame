namespace NameGame.Models.Network
{
    public sealed class EmployeeNetwork
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Slug { get; set; }
        public string Type { get; set; }
        public HeadshotNetwork Headshot { get; set; }
        public IEnumerable<SocialLinkNetwork> SocialLinks { get; set; }
    }
}
