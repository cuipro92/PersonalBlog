using PersonalBlog.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalBlog.Models
{
    public class CategoryModel
    {
        [Key]
        [Required]
        [MaxLength(20)]
        public string CategoryID { get; set; }
        [Required]
        [MaxLength(500)]
        public string CategoryName { get; set; }
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

        public List<CategoryModel> ListCategoryModel { get; set; }
    }
}