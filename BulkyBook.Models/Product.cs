using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 10000)]
        public int ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        public int Price50 { get; set; }
        [Required]
        [Range(1, 10000)]
        public int Price100 { get; set; }
        [ValidateNever]
        public string ImageURL { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [ValidateNever]
        public Category Category { get; set; }
        [Required]
        public int CoverTypeId { get; set; }
        [Required]
        [ValidateNever]
        public CoverType CoverType { get; set; }
    }
}
