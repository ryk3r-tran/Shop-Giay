using KarmaModels.KarmaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CartItem
    {
        public SANPHAM sanpham { set; get; }
        public int quantity { set; get; }
        public decimal? thanhtien
        {
            get
            {
                return sanpham.DonGia*quantity;
            }
        }
        
    }
}