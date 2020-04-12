using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalBlog.Models
{
    public class ContentModel
    {
        [Key]
        [Required]
        [MaxLength(20)]
        public string ContentID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
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
        public string CategoryID { get; set; }
        public List<ContentModel> ListContent { get; set; }
    }
}