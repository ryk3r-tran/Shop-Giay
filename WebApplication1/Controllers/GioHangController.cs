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