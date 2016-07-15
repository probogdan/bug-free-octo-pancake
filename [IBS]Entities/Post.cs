using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _IBS_Entities
{
    public class Post
    {
        public Guid PostId { get; set; }

        public Guid AuthorId { get; set; }

        public string AuthorName { get; set; }

        public DateTime PublishDate { get; set; }

        public byte [] PostPhoto { get; set; }

        public string MimeType { get; set; }

        public string Text { get; set; }
    }
}
