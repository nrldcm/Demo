using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DEMO.Models.DB
{
    public partial class Book
    {
        public long Id { get; set; }
        public long? CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? PublishDateUtc { get; set; }

        public virtual Category Category { get; set; }
    }
}
