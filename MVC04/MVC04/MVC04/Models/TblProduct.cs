using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC04.Models
{
    public partial class TblProduct
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string ProductName { get; set; } = null!;
        [Required(ErrorMessage = "Trường này không được để trống")]
        [RegularExpression(@".*\.png$", ErrorMessage = "Ảnh phải là ảnh PNG")]
        public string? ImageUrl { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? Description { get; set; }
    }
}
