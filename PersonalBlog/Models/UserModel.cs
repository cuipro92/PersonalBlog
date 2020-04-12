using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalBlog.Models
{
    public class UserModel
    {
        [Key]
        [Required]
        [MaxLength(20)]
        public string UserID { get; set; }
        [Required]
        [MaxLength(500)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(500)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(500)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserCreate { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserUpdate { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        [Required]
        public DateTime DateUpdate { get; set; }
        [Required]
        [MaxLength(20)]
        public string RoleID { get; set; }

        public List<UserModel> ListUserModel { get; set; }
    }
}