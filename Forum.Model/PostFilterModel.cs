using Forum.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model
{
    public class PostFilterModel : IPostFilterModel
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
    }
}
