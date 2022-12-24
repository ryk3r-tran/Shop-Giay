using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DonHang_ChiTietDH
    {
        public int MaDH { get; set; }

       
        public DateTime? NgayDat { get; set; }

        
        public DateTime? NgayGiao { get; set; }

       
        public string DCGiao { get; set; }

        public decimal? TongTien { get; set; }

     
        public string TinhTrang { get; set; }

      
        public string ThanhToan { get; set; }

        
        public string HoTen { get; set; }

      
        public string Email { get; set; }

       
        public string Sdt { get; set; }

        public int MaKH { get; set; }

        public int? SoLuong { get; set; }

        public int MaChiTietSP { get; set; }


    }
}