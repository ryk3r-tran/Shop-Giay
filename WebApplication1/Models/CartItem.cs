using KarmaModels.KarmaModels;
using KarmaModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    
    public class CartItem
    {
        
        public CHITIETSP ctsp { set; get; }
        
        public int? size { set; get; }
        public string mau { set; get; }
        public int quantity { set; get; }
        public string tensp { set; get; }
        public decimal? dongia { set; get; }
        public decimal? thanhtien
        {
            get
            {
                
                return dongia * quantity;
            }
        }

    }
}