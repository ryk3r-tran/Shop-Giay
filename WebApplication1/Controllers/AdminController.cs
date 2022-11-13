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

        public ActionResult DeleteSP (string id)
        {
            int int_id = Int32.Parse(id);
            var sp1 = _context.SANPHAMs.Find(int_id);
            _context.SANPHAMs.Remove(sp1);
            _context.SaveChanges();

            return RedirectToAction("TatCaSanPham");

        }

        [HttpPost]
        public ActionResult ThemSP(SANPHAM sp  , MAUSAC m, SIZE s, CHATLIEU c, NSX n, List<HttpPostedFileBase> Anhs, DANHMUCSP d)
        {
            var a = new ANH();
            int i = 0;
            foreach(var AnhF in Anhs)
            {
                string _FileName = Path.GetFileName(AnhF.FileName);
                string _path = Path.Combine(Server.MapPath("~/Content/img/product"), _FileName);
                string _dbPath = "~/Content/img/product" + _FileName;
                AnhF.SaveAs(_path);
                if(i == 0)
                {
                    a.AnhChinh = _dbPath;
                    i++;
                }
                else if( i == 1)
                {
                    a.AnhPhu1 = _dbPath;
                    i++;
                }
                else if(i == 2)
                {
                    a.AnhPhu2 = _dbPath;
                    i++;
                }
                else
                {
                    a.AnhPhu3 = _dbPath;
                }
                
            }
            sp.NgayCapNhat = DateTime.Today;
            
            _context.ANHs.Add(a);
            _context.MAUSACs.Add(m);            
            _context.SIZEs.Add(s);         
            _context.CHATLIEUx.Add(c);
            _context.NSXes.Add(n);
            _context.SaveChanges();


            var anhid = _context.ANHs
                .OrderByDescending(id => id.MaAnh)
                .FirstOrDefault();

            var NSXid = _context.NSXes
                .OrderByDescending(id => id.MaNSX)
                .FirstOrDefault();

            var Mauid = _context.MAUSACs
                .OrderByDescending(id => id.MaMau)
                .FirstOrDefault();

            var Sizeid = _context.SIZEs
                .OrderByDescending(id => id.MaSize)
                .FirstOrDefault();

            var CLid = _context.CHATLIEUx
                .OrderByDescending(id => id.MaCL)
                .FirstOrDefault();

            Console.WriteLine(anhid.MaAnh);

            var d1 = _context.DANHMUCSPs
                .Where(t => t.TenDM == d.TenDM)
                .FirstOrDefault<DANHMUCSP>();

            sp.MaNSX = NSXid.MaNSX;
            sp.MaAnh = anhid.MaAnh;
            _context.SANPHAMs.Add(sp);
            _context.SaveChanges();

            var SPid = _context.SANPHAMs
                .OrderByDescending(id => id.MaSP)
                .FirstOrDefault();

            var ctSP = new CHITIETSP();
            ctSP.MaSP = SPid.MaSP;
            ctSP.MaDM = d1.MaDM;
            ctSP.MaCL = CLid.MaCL;
            ctSP.MaMau = Mauid.MaMau;
            ctSP.MaSize = Sizeid.MaSize;

            _context.CHITIETSPs.Add(ctSP);
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