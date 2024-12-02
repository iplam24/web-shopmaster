using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName(" Tên danh mục")]
        public string ?Name { get; set; }
        [Required]
        [DisplayName(" Thứ tự hiển thị danh mục")]

        public int DisplayOrder { get; set; }
    }
}
