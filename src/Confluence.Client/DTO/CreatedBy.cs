namespace Confluence.Client.DTO
{
    public class CreatedBy
    {
        public string type { get; set; }
        public string username { get; set; }
        public string userKey { get; set; }
        public ProfilePicture profilePicture { get; set; }
        public string displayName { get; set; }
        public Links _links { get; set; }
        public Expandable _expandable { get; set; }
    }
}