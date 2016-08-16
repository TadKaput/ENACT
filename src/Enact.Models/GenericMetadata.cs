using System;

namespace Enact.Models
{
    public abstract class GenericMetadata
    {
        public string Id { get; set; }
        public string LastEditedByUserId { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public long DataVersion { get; set; }

    }
}
