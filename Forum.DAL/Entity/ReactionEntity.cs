﻿using System;
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
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateUpdated { get; set; }
        
        //Navigators
        public ReactionTypeEntity ReactionType { get; set; }

        //Constraints
        [ForeignKey("FK_ReactionTypeId")]
        public Guid ReactionTypeId { get; set; }
    }
}