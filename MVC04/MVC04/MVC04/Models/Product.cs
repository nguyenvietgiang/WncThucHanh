using System.ComponentModel.DataAnnotations;

namespace MVC04.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Trường này không được để trống")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        [RegularExpression(@".*\.png$", ErrorMessage = "Ảnh phải là ảnh PNG")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn 0")]
        public decimal ProductPrice { get; set; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Description { get; set; }
    }

}
