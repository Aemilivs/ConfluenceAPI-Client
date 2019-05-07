namespace Confluence.Client.DTO
{
    public class Version
    {
        public By by { get; set; }
        public string when { get; set; }
        public string message { get; set; }
        public int number { get; set; }
        public bool minorEdit { get; set; }
        public bool hidden { get; set; }
        public Links _links { get; set; }
        public Expandable _expandable { get; set; }
    }
}