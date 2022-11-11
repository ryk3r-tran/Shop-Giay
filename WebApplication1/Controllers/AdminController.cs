using KarmaModels.KarmaModels;
using KarmaModels.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        KarmaDBContext _context = new KarmaDBContext();
        // GET: Admin
        
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult TatCaTaiKhoan()
        {
            var data = _context.TAIKHOANs.Include("KHACHHANG");
            return View(data.ToList());        
        }

        

        public ActionResult ThemTaiKhoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemTK(TAIKHOAN tk1, KHACHHANG kh1, string check_DK)
        {
            if(kh1.GioiTinh == "option1")
            {
                kh1.GioiTinh = "Nam";
            }
            if (kh1.GioiTinh == "option2")
            {
                kh1.GioiTinh = "Nữ";
            }
            if (tk1.Quyen == "option1")
            {
                tk1.Quyen = "Quản lý";
            }
            if (tk1.Quyen == "option2")
            {
                tk1.Quyen = "Nhân viên";
            }
            if (tk1.Quyen == "option3")
            {
                tk1.Quyen = "Khách hàng";
            }


            _context.KHACHHANGs.Add(kh1);
            _context.TAIKHOANs.Add(tk1);
            

            _context.SaveChanges();

            return RedirectToAction("TatCaTaiKhoan");
        }

        public ActionResult getTKbyID(string id)
        {
            string[] s_id = id.Split(' ');
            int i1 = Int32.Parse(s_id[0]);
            int i2 = Int32.Parse(s_id[1]);
            IRepository<TAIKHOAN> tk = new Repository<TAIKHOAN>();
            IRepository<KHACHHANG> kh = new Repository<KHACHHANG>();

            var result_tk = tk.GetById(i1);
            var result_kh = kh.GetById(i2);
            return Json(new {
                userName = result_tk.username,
                pass = result_tk.pass,
                quyen = result_tk.Quyen,
                TenKH = result_kh.TenKH,
                GioiTinh = result_kh.GioiTinh,
                Email = result_kh.Email,
                diaChi = result_kh.DiaChi,
                sdt = result_kh.Sdt
            }); ;
        }
        
        [HttpPost]
        public ActionResult SuaThongTinTK(TAIKHOAN tk, KHACHHANG kh, string id_kh)
        {
            string[] s_id = id_kh.Split(' ');
            int i1 = Int32.Parse(s_id[0]);
            int i2 = Int32.Parse(s_id[1]);
            var tk1 = _context.TAIKHOANs.Find(i1);
            tk1.id = i1;
            tk1.username = tk.username;
            tk1.pass = tk.pass;
            tk1.Quyen = tk.Quyen;
            var kh1 = _context.KHACHHANGs.Find(i2);
            kh1.TenKH = kh.TenKH;
            kh1.GioiTinh = kh.GioiTinh;
            kh1.DiaChi = kh.DiaChi;
            kh1.Email = kh.Email;
            kh1.Sdt = kh.Sdt;

            _context.SaveChanges();
            
            return RedirectToAction("TatCaTaiKhoan");

        }

        public ActionResult DeleteTK(string id)
        {
            string[] s_id = id.Split(' ');
            int i1 = Int32.Parse(s_id[0]);
            int i2 = Int32.Parse(s_id[1]);

            var tk1 = _context.TAIKHOANs.Find(i1);
            _context.TAIKHOANs.Remove(tk1);

            var kh1 = _context.KHACHHANGs.Find(i2);
            _context.KHACHHANGs.Remove(kh1);

            _context.SaveChanges();

            

            return RedirectToAction("Admin/TatCaTaiKhoan");
        }

        public ActionResult ThongKe()
        {
            return View();
        }

        public ActionResult TatCaSanPham()
        {
            IRepository<SANPHAM> sanpham = new Repository<SANPHAM>();
            var data = sanpham.GetAll();
            return View(data);
        }

        public ActionResult ThemSanPham()
        {
            var d = _context.DANHMUCSPs.ToList();
            return View(d);
        }

        [HttpPost]
        public ActionResult ThemSP(SANPHAM sp  , MAUSAC m, SIZE s, CHATLIEU c, NSX n, HttpPostedFileBase AnhChinh, HttpPostedFileBase AnhPhu1, HttpPostedFileBase AnhPhu2, HttpPostedFileBase AnhPhu3)
        {
            var a = new ANH();
            string _FileName = Path.GetFileName(AnhChinh.FileName);
            string _path = Path.Combine(Server.MapPath("~/Content/img/product"), _FileName);
            string _dbPath = "Content/img/product" + _FileName;
            AnhChinh.SaveAs(_path);
            a.AnhChinh = _dbPath;
            var maAnh = _context.ANHs.SqlQuery("Select top 1 MaAnh from Anh where AnhChinh = @path",
                new SqlParameter("@path", _dbPath)).FirstOrDefault();
            sp.MaAnh = sp.MaAnh;



            _FileName = Path.GetFileName(AnhPhu2.FileName);
            _path = Path.Combine(Server.MapPath("~/Content/img/product"), _FileName);
            _dbPath = "Content/img/product" + _FileName;
            AnhPhu2.SaveAs(_path);
            a.AnhPhu2 = _dbPath;

            _FileName = Path.GetFileName(AnhPhu3.FileName);
            _path = Path.Combine(Server.MapPath("~/Content/img/product"), _FileName);
            _dbPath = "Content/img/product" + _FileName;
            AnhPhu3.SaveAs(_path);
            a.AnhPhu3 = _dbPath;

            _FileName = Path.GetFileName(AnhPhu1.FileName);
            _path = Path.Combine(Server.MapPath("~/Content/img/product"), _FileName);
            _dbPath = "Content/img/product" + _FileName;
            AnhPhu1.SaveAs(_path);
            a.AnhPhu1 = _dbPath;


            var maNSX = _context.NSXes.SqlQuery("Select top 1 MaAnh from Anh where TenNSX = @t",
                new SqlParameter("@t", n.TenNSX)).FirstOrDefault();
            _context.NSXes.Add(n);
            
            _context.SANPHAMs.Add(sp);
            _context.ANHs.Add(a);
            _context.MAUSACs.Add(m);
            _context.SIZEs.Add(s);
            _context.CHATLIEUx.Add(c);
            
            _context.SaveChanges();

            return RedirectToAction("TatCaSanPham");

        }

        public void ThemNSX(NSX nsx)
        {
            _context.NSXes.Add(nsx);
            _context.SaveChanges();
            
        }

        public void ThemTTChitiet(MAUSAC m, SIZE s, CHATLIEU c)
        {
            _context.MAUSACs.Add(m);
            _context.CHATLIEUx.Add(c);
            _context.SIZEs.Add(s);
            _context.SaveChanges();
        }

    
        

    }
}