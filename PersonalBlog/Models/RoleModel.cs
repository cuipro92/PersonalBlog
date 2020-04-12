using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalBlog.Models
{
    public class RoleModel
    {
        [Key]
        [Required]
        [MaxLength(20)]
        public string RoleID { get; set; }
        [Required]
        [MaxLength(500)]
        public string RoleName { get; set; }
        public List<RoleModel> ListRole { get; set; }
    }
}