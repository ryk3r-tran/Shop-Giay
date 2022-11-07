using System;
using KarmaModels.KarmaModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Cart
    {
        public List<CartItem> ListCartItem = null;
        public Cart()
        {
            this.ListCartItem = new List<CartItem>();
        }
        public decimal? TongTien
        {
            get
            {
                decimal? tongtien = 0;
                foreach(var item in ListCartItem)
                {
                    tongtien += item.thanhtien;
                }
                return tongtien;
            }
        }
    }
}