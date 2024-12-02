using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Shop.Models.Models;

namespace WebShop.Models
{
    public class Product
    {
        [Key] 
        public int Id { get; set; }
        [Required]

        [Display(Name = "Tên Bánh - Sản phẩm")]
        public string ?Title { get; set; }

        [Required]
        [Display(Name = "Size Bánh - Trọng lượng")]
        public string ?Size { get; set; }

       
        [Display(Name = "Thông tin chi tiết")]
        [Required] public string? Description { get; set; }
       

        [Required]
        [Display(Name = " Giá bán ")]
        public double Price { get; set; }

       
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        [Display(Name = "Thể loại")]
        public Category ?Category { get; set; }


        [ValidateNever]
        public List<ProductImage> ProductImages { get; set; }


    }
}
