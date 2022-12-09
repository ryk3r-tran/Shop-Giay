﻿using KarmaModels.KarmaModels;
using KarmaModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Configuration;
using KarmaModels.Payment;
using System.Threading;
using System.IO;
using WebApplication1.App_Start;
namespace WebApplication1.Controllers
{
    //[Authorization(Quyen = "admin,customer")]
    public class GioHangController : Controller
    {
        // GET: GioHang

        
        public ActionResult GioHang()
        {
            Cart cart = Session["UserCart"] as Cart;
            return View(cart);
        }
        
        public ActionResult ThemVaoGioHang(string id, int? size, int? mau)
        {

            var idsp = Int32.Parse(id);
            if(size == null)
            {
                size = 1;
            }

             var db = new KarmaDBContext();
            if(mau == null)  // chưa chọn màu
            {
                return Json(new { status = "chua chon mau" });
            }
            else  // đã chọn size và màu
            {
                var dem = db.CHITIETSPs.Count(s => s.MaSP == idsp && s.MaSize == size && s.MaMau == mau);
                if (dem == 1)  // có sản phẩm ứng với size và màu đó
                {
                    IRepository<SANPHAM> sp = new Repository<SANPHAM>();
                    IRepository<CHITIETSP> ctsp = new Repository<CHITIETSP>();
                    IRepository<SIZE> table_size = new Repository<SIZE>();
                    IRepository<MAUSAC> table_mau = new Repository<MAUSAC>();
                    if (Session["UserCart"] == null) // cart null
                    {
                        Session["UserCart"] = new Cart(); // create session user cart as list 
                    }
                    Cart cart = Session["UserCart"] as Cart;
                    //lấy id chi tiết sản phần dựa vào id, size, màu

                    var idctsp = db.CHITIETSPs.SingleOrDefault(s => s.MaSP == idsp && s.MaMau == mau && s.MaSize == size).MaChiTietSP;

                    // check product was in cart
                    if (cart.ListCartItem.SingleOrDefault(p => p.ctsp.MaChiTietSP == idctsp) == null)
                    {
                        CHITIETSP chitietsp = ctsp.GetById(idctsp);
                        // create 1 new cartItem
                        int? size_giay = table_size.GetById(chitietsp.MaSize).Size1;
                        var mau_giay = table_mau.GetById(chitietsp.MaMau).Color;
                        var tensp = sp.GetById(chitietsp.MaSP).TenSP;
                        decimal? dongia = sp.GetById(idctsp).DonGia;
                        CartItem newItem = new CartItem()
                        {
                            ctsp = chitietsp,
                            size = size_giay,
                            mau = mau_giay,
                            tensp = tensp,
                            dongia = dongia,
                            quantity = 1,
                        };
                        // add prod to cart
                        cart.ListCartItem.Add(newItem);
                    }
                    else
                    {
                        CartItem cartItem1 = cart.ListCartItem.FirstOrDefault(p => p.ctsp.MaChiTietSP == idctsp);

                        cartItem1.quantity++;
                    }
                    Session["UserCart"] = cart;
                    return Json(new { status = "successful" });
                }
                else   // không có sản phẩm thỏa mãn
                {
                    return Json(new { status = "het hang" });
                }
            }


            
        }

        

        public ActionResult CapNhatGioHang(int id, int soluong)
        {
            Cart session_cart = Session["UserCart"] as Cart;
            var item = session_cart.ListCartItem.FirstOrDefault(p => p.ctsp.MaChiTietSP == id);
            item.quantity = soluong;
            Session["UserCart"] = session_cart;
            var quanity = session_cart.ListCartItem.FirstOrDefault(i => i.ctsp.MaChiTietSP == id).quantity;
            var thanhtien = session_cart.ListCartItem.FirstOrDefault(i => i.ctsp.MaChiTietSP == id).thanhtien;
            var tongtien = session_cart.TongTien;
            return Json(new
            {
                id_sp = id,
                quanity = quanity,
                thanhtien = thanhtien,
                tongtien = tongtien,
            }) ;
        }
        public ActionResult XoaSanPham(int id)
        {
            Cart cart = Session["UserCart"] as Cart;
            var item = cart.ListCartItem.SingleOrDefault(i => i.ctsp.MaChiTietSP == id);
            cart.ListCartItem.Remove(item);
            Session["UserCart"] = cart;
            if (cart.ListCartItem.Count == 0)
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
            IRepository<Tinh> tinh = new Repository<Tinh>();
            List<Tinh> dsTinh = tinh.GetAll() as List<Tinh>;
            ViewBag.Tinh = dsTinh;
            Cart cart = Session["UserCart"] as Cart;
            return View(cart);
        }

        public ActionResult Payment(string id)
        {
            if (id == "1")
            {
                ViewBag.OrderSuccessful = "Đặt hàng thành công";

                return RedirectToAction("DonMua", "GioHang");
            }
            else if(id == "2")
            {
                string url = ConfigurationManager.AppSettings["Url"];
                string returnUrl = ConfigurationManager.AppSettings["ReturnUrl"];
                string tmnCode = ConfigurationManager.AppSettings["TmnCode"];
                string hashSecret = ConfigurationManager.AppSettings["HashSecret"];

                PayLib pay = new PayLib();

                pay.AddRequestData("vnp_Amount", "1000000"); //số tiền cần thanh toán, công thức: số tiền * 100 - ví dụ 10.000 (mười nghìn đồng) --> 1000000
                pay.AddRequestData("vnp_BankCode", ""); //Mã Ngân hàng thanh toán (tham khảo: https://sandbox.vnpayment.vn/apis/danh-sach-ngan-hang/), có thể để trống, người dùng có thể chọn trên cổng thanh toán VNPAY
                pay.AddRequestData("vnp_Command", "pay"); //Mã API sử dụng, mã cho giao dịch thanh toán là 'pay'
                pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss")); //ngày thanh toán theo định dạng yyyyMMddHHmmss
                pay.AddRequestData("vnp_CurrCode", "VND"); //Đơn vị tiền tệ sử dụng thanh toán. Hiện tại chỉ hỗ trợ VN
                pay.AddRequestData("vnp_IpAddr", Util.GeIpAddress()); //Địa chỉ IP của khách hàng thực hiện giao dịch
                pay.AddRequestData("vnp_Locale", "vn"); //Ngôn ngữ giao diện hiển thị - Tiếng Việt (vn), Tiếng Anh (en)
                pay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang"); //Thông tin mô tả nội dung thanh toán
                pay.AddRequestData("vnp_OrderType", "other"); //topup: Nạp tiền điện thoại - billpayment: Thanh toán hóa đơn - fashion: Thời trang - other: Thanh toán trực tuyến
                pay.AddRequestData("vnp_ReturnUrl", returnUrl); //URL thông báo kết quả giao dịch khi Khách hàng kết thúc thanh toán
                pay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString()); //mã hóa đơn
                pay.AddRequestData("vnp_TmnCode", tmnCode); //Mã website của merchant trên hệ thống của VNPAY (khi đăng ký tài khoản sẽ có trong mail VNPAY gửi về)
                pay.AddRequestData("vnp_Version", "2.1.0"); //Phiên bản api mà merchant kết nối. Phiên bản hiện tại là 2.1.0
                string paymentUrl = pay.CreateRequestUrl(url, hashSecret);
                return Redirect(paymentUrl);
            }
            else
            {
                ViewBag.Message = "Bạn chưa chọn phương thức thanh toán";
                return RedirectToAction("ThanhToan", "GioHang");
            }
            
        }




        public ActionResult XacNhanThanhToan()
        {
            if (Request.QueryString.Count > 0)
            {
                string hashSecret = ConfigurationManager.AppSettings["HashSecret"];
                var vnpayData = Request.QueryString;
                PayLib pay = new PayLib();

                foreach (string s in vnpayData)
                {
                    if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                    {
                        pay.AddResponseData(s, vnpayData[s]);
                    }
                }
                long orderId = Convert.ToInt64(pay.GetResponseData("vnp_TxnRef")); //mã hóa đơn
                long vnpayTranId = Convert.ToInt64(pay.GetResponseData("vnp_TransactionNo")); //mã giao dịch tại hệ thống VNPAY
                string vnp_ResponseCode = pay.GetResponseData("vnp_ResponseCode"); //response code: 00 - thành công
                string vnp_SecureHash = Request.QueryString["vnp_SecureHash"]; // hash của dữ liệu trả về
                bool checkSignature = pay.ValidateSignature(vnp_SecureHash, hashSecret); // check chữ ký 
                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00")
                    {
                        //Thanh toán thành công
                        ViewBag.Message = "Thanh toán thành công hóa đơn " + orderId + " | Mã giao dịch: " + vnpayTranId;
                        Session.Remove("UserCart");
                        return View();
                    }
                    else if(vnp_ResponseCode == "24")
                    {
                        //Thanh toán không thành công. Mã lỗi: vnp_ResponseCode
                        //ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý hóa đơn " + orderId + " | Mã giao dịch: " + vnpayTranId + " | Mã lỗi: " + vnp_ResponseCode;
                        return View("ThanhToan", "GioHang");
                    }
                }
                else
                {
                    ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý";
                    return View("ThanhToan", "GioHang");
                }
            }
            return View("ThanhToan", "GioHang");
        }
        
        public ActionResult XacNhanDonHang()
        {
            return View();
        }

        public ActionResult DonMua()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ThemDonHang(DONHANG dh)
        {
            return RedirectToAction("DanhSachSanPham");
        }
        public ActionResult LichSuMuaHang()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetHuyen(string idtinh)
        {
            int matinh = Int32.Parse(idtinh);
            KarmaDBContext _context = new KarmaDBContext();
            var dsHuyen = _context.Huyens.Where(h => h.MaTinh == matinh).ToList();
            List<object> huyen = new List<object> { };
            foreach (var element in dsHuyen)
            {
                object a = new
                {
                    mahuyen = element.MaHuyen,
                    tenhuyen = element.TenHuyen,
                };
                huyen.Add(a);
            }               
            return Json(huyen);
        }

        [HttpPost]
        public ActionResult GetXa(string idhuyen)
        {
            int mahuyen = Int32.Parse(idhuyen);
            KarmaDBContext _context = new KarmaDBContext();
            var dsXa = _context.Xas.Where(h => h.MaHuyen == mahuyen).ToList();
            List<object> xa = new List<object> { };
            foreach (var element in dsXa)
            {
                object a = new
                {
                    maxa = element.MaXa,
                    tenxa = element.TenXa,
                };
                xa.Add(a);
            }
            return Json(xa);
        }
    }
}