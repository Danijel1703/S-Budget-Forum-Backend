using Forum.Model.Common.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Post
{
    public class PostFilterModel : IPostFilterModel
    {
        public Guid? UserId { get; set; }
        public int RecordsPerPage { get; set; }
        public int Page { get; set; }
    }
}
