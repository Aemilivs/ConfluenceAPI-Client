namespace Confluence.Client.DTO
{
    public class Expandable
    {
        public string status { get; set; }
        public string lastUpdated { get; set; }
        public string previousVersion { get; set; }
        public string contributors { get; set; }
        public string nextVersion { get; set; }
        public string content { get; set; }
        public string editor { get; set; }
        public string view { get; set; }
        public string export_view { get; set; }
        public string styled_view { get; set; }
        public string anonymous_export_view { get; set; }
        public string container { get; set; }
        public string metadata { get; set; }
        public string operations { get; set; }
        public string children { get; set; }
        public string restrictions { get; set; }
        public string ancestors { get; set; }
        public string descendants { get; set; }
        public string space { get; set; }
    }
}