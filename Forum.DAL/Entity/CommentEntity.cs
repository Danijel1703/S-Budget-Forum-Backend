using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL.Entity
{
    public class CommentEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        //Navigators
        public PostEntity Post { get; set; }
        public UserEntity User { get; set; }

        //Constraints
        [ForeignKey("FK_UserId")]
        public Guid UserId { get; set; }
        [ForeignKey("FK_PostId")]
        public Guid PostId { get; set; }
    }
}
