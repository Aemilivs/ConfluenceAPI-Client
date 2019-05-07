namespace Confluence.Client.DTO
{
    public class ContentPage
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public History history { get; set; }
        public Version version { get; set; }
        public Body body { get; set; }
        public Extensions extensions { get; set; }
        public Links _links { get; set; }
        public Expandable _expandable { get; set; }
    }
}
