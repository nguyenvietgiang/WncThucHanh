using System;
using System.Collections.Generic;

namespace MVC05.Models
{
    public partial class TblHoadon
    {
        public int PkIHoadonId { get; set; }
        public DateTime? TNgaylap { get; set; }
        public int? FkIKhachhangId { get; set; }
        public DateTime? TNgayGiaoHang { get; set; }
        public string? STennguoinhan { get; set; }
        public string? SDiachigiaohang { get; set; }
        public string? SDienthoaiNguoinhan { get; set; }
        public bool? BDathanhtoan { get; set; }
        public string? SNguoilapHoadon { get; set; }
        public double? FTileGiamgia { get; set; }
    }
}
