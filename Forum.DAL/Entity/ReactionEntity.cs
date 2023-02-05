using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL.Entity
{
    public class ReactionEntity
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }

        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        
        //Navigators
        public ReactionTypeEntity ReactionType { get; set; }

        //Constraints
        [ForeignKey("FK_ReactionTypeId")]
        public Guid ReactionTypeId { get; set; }
        [ForeignKey("FK_PostId")]
        public Guid PostId { get; set; }
        [ForeignKey("FK_CommentId")]
        public Guid? CommentId { get; set; }

    }
}
