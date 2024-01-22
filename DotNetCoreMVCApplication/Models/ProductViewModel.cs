using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DotNetCoreMVCApplication.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is required.")]
        public string productName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "The Description cannot exceed 100 characters.")]
        public string productDescription { get; set; }
    }
}
