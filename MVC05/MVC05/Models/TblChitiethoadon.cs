using System;
using System.Collections.Generic;

namespace MVC05.Models
{
    public partial class TblChitiethoadon
    {
        public int FkIHoadonId { get; set; }
        public int FkIHanghoaId { get; set; }
        public int? ISoluong { get; set; }
        public double? FGiaban { get; set; }
    }
}
