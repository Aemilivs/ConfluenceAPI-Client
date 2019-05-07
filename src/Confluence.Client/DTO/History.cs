using System;

namespace Confluence.Client.DTO
{
    public class History
    {
        public bool latest { get; set; }
        public CreatedBy createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public Links _links { get; set; }
        public Expandable _expandable { get; set; }
    }
}