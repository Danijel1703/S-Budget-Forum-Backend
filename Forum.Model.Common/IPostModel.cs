using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Common
{
    public interface IPostModel
    {
        Guid Id { get; set; }
        string Content { get; set; }
        string Title { get; set; }
        int Upvotes { get; set; }
        int Downvotes { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
        Guid UserId { get; set; }
    }
}
