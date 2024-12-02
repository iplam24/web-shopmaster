using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Shop.Models.Models
{
    public class News
    {
        public int Id { get; set; }

        [Display(Name = "Họ tên")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required]
        public int Nummber { get; set; }

        [Display(Name = "Yêu cầu của bạn")]
        [Required]
        public string  Description { get; set; }

    }
}
