using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC05.Models
{
    public partial class TblHanghoa
    {
        public int PkIHanghoaId { get; set; }
        [Required(ErrorMessage = "Hãy điền đủ thông tin vào đây")]
        public string STenhang { get; set; } = null!;
        [Required(ErrorMessage = "Hãy điền đủ thông tin vào đây")]
        public double FGianiemyet { get; set; }
        [Required(ErrorMessage = "Hãy điền đủ thông tin vào đây")]
        public string? SDacdiem { get; set; }
        public string? SXuatxu { get; set; }
        public string? SAnhminhhoa { get; set; }
    }
}
