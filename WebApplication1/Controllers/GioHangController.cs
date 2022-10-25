using KarmaModels.KarmaModels;
using KarmaModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GioHangController : Controller
    {
          // GET: GioHang
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult GioHang()
        {
            List<CartItem> cart = Session["UserCart"] as List<CartItem>;
            return View(cart);
        }
        
        public ActionResult ThemVaoGioHang(string id)
        {
            var idsp = Int32.Parse(id);
            IRepository<SANPHAM> sp = new Repository<SANPHAM>();
            if (Session["UserCart"] == null) // cart null
            {
                Session["UserCart"] = new List<CartItem>(); // create session user cart as list 
            }
            List<CartItem> cart = Session["UserCart"] as List<CartItem>;
            // check product was in cart
            if (cart.FirstOrDefault(p => p.sanpham.MaSP == idsp) == null)
            {
                SANPHAM sanpham = sp.GetById(idsp);
                // create 1 new cartItem
                CartItem newItem = new CartItem() { 
                    sanpham =  sanpham,
                    quantity = 1,
                };
                // add prod to cart
                cart.Add(newItem);
            }
            else
            {
                CartItem cartItem1 = cart.FirstOrDefault(p => p.sanpham.MaSP == idsp);
                cartItem1.quantity++;
            }
            Session["UserCart"] = cart;
            return Json(new { status = "successful"});
        }


        public ActionResult CapNhatGioHang(int id, int soluong)
        {
            List<CartItem> session_cart = Session["UserCart"] as List<CartItem>;
            var item = session_cart.FirstOrDefault(i => i.sanpham.MaSP == id);
            item.quantity = soluong;
            Session["UserCart"] = session_cart;
            var quanity = session_cart.FirstOrDefault(i => i.sanpham.MaSP == id).quantity;
            var thanhtien = session_cart.FirstOrDefault(i => i.sanpham.MaSP == id).thanhtien;
            return Json(new
            {
                id_sp = id,
                quanity = quanity,
                thanhtien = thanhtien,
            }) ;
        }
        public ActionResult XoaSanPham(int id)
        {
            List<CartItem> cart = Session["UserCart"] as List<CartItem>;
            var item = cart.SingleOrDefault(i => i.sanpham.MaSP == id);
            cart.Remove(item);
            Session["UserCart"] = cart;
            if (cart.Count == 0)
            {
                return Json(new
                {
                    status = 1,
                    empty = 1,
                });
            }
            else
            {
                return Json(new
                {
                    status = 1,
                    empty=0,
                });
            }
            
        }
        public ActionResult ThanhToan()
        {
            return View();
        }

        public ActionResult XacNhanDonHang()
        {
            return View();
        }
    }
}