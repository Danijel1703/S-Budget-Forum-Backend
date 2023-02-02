using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL.Entity
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateUpdated { get; set; }

        //Navigators
        public RoleEntity Role { get; set; }
        public List<PostEntity> Post { get; set; }
        public List<CommentEntity> Comment { get; set; }

        //Constraints
        [ForeignKey("FK_RoleId")]
        public Guid RoleId { get; set; }
    }
}
