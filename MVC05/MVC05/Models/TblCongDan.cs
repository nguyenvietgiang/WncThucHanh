using System;
using System.Collections.Generic;

namespace MVC05.Models
{
    public partial class TblCongDan
    {
        public int PkICongDanId { get; set; }
        public string SHoTen { get; set; } = null!;
        public DateTime TNgaySinh { get; set; }
        public string SCmnd { get; set; } = null!;
        public string SHoKhau { get; set; } = null!;
    }
}
