using Forum.DAL.Entity;
using Forum.Model.Common.Reaction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Model.Reaction
{
    public class ReactionModel : IReactionModel
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Guid ReactionTypeId { get; set; }
        public Guid PostId { get; set; }
        public Guid? CommentId { get; set; }
    }
}
