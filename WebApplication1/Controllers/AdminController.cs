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
using WebApplication1.App_Start;
using PagedList;

namespace WebApplication1.Controllers
{
    //[Authorization(Quyen = "admin")]
    public class AdminController : Controller
    {
        KarmaDBContext _context = new KarmaDBContext();
        // GET: Admin

        public bool CheckQuyen()
        {
            if (Session["Quyen"] == null)
            {
                return false;
            }
               
            else if(Session["Quyen"].ToString() == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public ActionResult Admin()
        {
            var result = _context.DONHANGs.Count();

            ViewBag.SoDH = result;
            if (true)
            {
                
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


            //var donHang = _context.DONHANGs;
            //var donHangL = donHang.ToList();

            //int[] tk = new int[14];
            //for(int i = 1; i<= 12; i++)
            //{
                
            //    tk[i] = 0;
            //}

            //foreach (var d in donHangL)
            //{
            //    var ng = d.NgayGiao.Value.Month.ToString();
            //    int ngI = Int32.Parse(ng);
            //    tk[ngI] += Int32.Parse(d.TongTien.ToString());
            //}
            //ViewBag.tkL = tk.ToList();
            //return View();

        }
        public ActionResult TatCaTaiKhoan()
        {
            if (CheckQuyen())
            {
                var data = _context.TAIKHOANs.Include("KHACHHANG");
                return View(data.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
               
        }

        

        public ActionResult ThemTaiKhoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemTK(TAIKHOAN tk1, KHACHHANG kh1, string check_DK)
        {
            if (CheckQuyen())
            {
                if (kh1.GioiTinh == "option1")
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
            else
            {
                return RedirectToAction("Index", "Home");
            }

            
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

        

        public ActionResult TatCaSanPham()
        {
            if (true)
            {
                IRepository<SANPHAM> sanpham = new Repository<SANPHAM>();
                var data = sanpham.GetAll();
                var d = _context.DANHMUCSPs.ToList();
                ViewBag.DanhMuc = d;
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }

        public ActionResult ThemSanPham()
        {

            var d = _context.DANHMUCSPs.ToList();
            var s = _context.SIZEs.ToList();
            var cl1 = _context.MAUSACs.ToList();
            
            ViewBag.Size = s;
            ViewBag.Mau = cl1;
            return View(d);
        }

        public ActionResult CapNhatSP(int id)
        {
           
            var product = from p in _context.SANPHAMs
                          join a in _context.ANHs on p.MaAnh equals a.MaAnh
                          join cl in _context.CHATLIEUx on p.MaCL equals cl.MaCL
                          join dm in _context.DANHMUCSPs on p.MaDM equals dm.MaDM
                          join nsx in _context.NSXes on p.MaNSX equals nsx.MaNSX
                          join ctsp in _context.CHITIETSPs on p.MaSP equals ctsp.MaSP
                          join ms in _context.MAUSACs on ctsp.MaMau equals ms.MaMau
                          join sz in _context.SIZEs on ctsp.MaSize equals sz.MaSize
                          where p.MaSP == id
                          select new
                          {
                              MaSP = p.MaSP,
                              Tensp = p.TenSP,
                              DanhMuc = dm.TenDM,
                              SoLuong = p.SoLuongTong,
                              DonGia = p.DonGia,
                              MoTa = p.MoTa,
                              AnhChinh = a.AnhChinh,
                              Anh1 = a.AnhPhu1,
                              Anh2 = a.AnhPhu2,
                              Anh3 = a.AnhPhu3,
                              Mau = ms.MaHeXan,
                              Size = sz.Size1,
                              ChatLieu = cl.ChatLieu1,
                              TenNSX = nsx.TenNSX,
                              DiaChi = nsx.DiaChi,
                              Email = nsx.Email,
                              sdt = nsx.Sdt,
                              MaCTSP = ctsp.MaChiTietSP
                          };
            var d = _context.DANHMUCSPs.ToList();
            var s = _context.SIZEs.ToList();
            var cl1 = _context.MAUSACs.ToList();
            ViewBag.DanhMuc = d;
            ViewBag.Size = s;
            ViewBag.Mau = cl1;
            TT_SP sp_up = new TT_SP();
            foreach (var data in product.ToList())
            {
                sp_up.MaChiTietSP = data.MaCTSP;
                sp_up.MaSP = data.MaSP;
                sp_up.TenSP = data.Tensp;
                sp_up.TenDM = data.DanhMuc;
                sp_up.SoLuongTong = data.SoLuong;
                sp_up.DonGia = data.DonGia;
                sp_up.MoTa = data.MoTa;
                sp_up.AnhChinh = data.AnhChinh;
                sp_up.AnhPhu1 = data.Anh1;
                sp_up.AnhPhu2 = data.Anh2;
                sp_up.AnhPhu3 = data.Anh3;
                sp_up.MaHeXan = data.Mau;
                sp_up.Size1 = data.Size;
                sp_up.ChatLieu1 = data.ChatLieu;
                sp_up.TenNSX = data.TenNSX;
                sp_up.DiaChi = data.DiaChi;
                sp_up.Email = data.Email;
                sp_up.Sdt = data.sdt;
            }
            
            return View(sp_up);
        }

        [HttpPost]
        public ActionResult CapNhatSP(SANPHAM sp, MAUSAC m, SIZE s, CHATLIEU c, NSX n, DANHMUCSP d, CHITIETSP CT1)
        {
            
            m.MaHeXan = m.Color;
            var SanPhamU = _context.SANPHAMs.Find(sp.MaSP);
            SanPhamU.TenSP = sp.TenSP;
            SanPhamU.SoLuongTong = sp.SoLuongTong;
            SanPhamU.DonGia = sp.DonGia;
            SanPhamU.MoTa = sp.MoTa;

            
            var ChatLieuU = _context.CHATLIEUx.Find(SanPhamU.MaCL);
            ChatLieuU.ChatLieu1 = c.ChatLieu1;

            var DanhMucU = _context.DANHMUCSPs.Find(SanPhamU.MaDM);
            SanPhamU.MaDM = DanhMucU.MaDM;

            var NsxU = _context.NSXes.Find(SanPhamU.MaNSX);
            NsxU.TenNSX = n.TenNSX;
            NsxU.DiaChi = n.DiaChi;
            NsxU.Email = n.Email;
            NsxU.Sdt = n.Sdt;
            
            var CtspU = _context.CHITIETSPs.Find(CT1.MaChiTietSP);
            CtspU.MaMau = m.MaMau;
            CtspU.MaSize = s.MaSize;



            _context.SaveChanges();

            return RedirectToAction("TatCaSanPham");

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
            foreach (var AnhF in Anhs)
            {
                string _FileName = Path.GetFileName(AnhF.FileName);
                string _path = Path.Combine(Server.MapPath("/Content/img/product/"), _FileName);
                string _dbPath = "/Content/img/product/" + _FileName;
                AnhF.SaveAs(_path);
                if (i == 0)
                {
                    a.AnhChinh = _dbPath;
                    i++;
                }
                else if (i == 1)
                {
                    a.AnhPhu1 = _dbPath;
                    i++;
                }
                else if (i == 2)
                {
                    a.AnhPhu2 = _dbPath;
                    i++;
                }
                else
                {
                    a.AnhPhu3 = _dbPath;
                }

            }
            m.MaHeXan = m.Color;
            _context.ANHs.Add(a);
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
                .Where(cl => cl.MaHeXan == m.MaHeXan)
                .FirstOrDefault();
            var Sizeid = _context.SIZEs
                .Where(sz => sz.Size1 == s.Size1)
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
            sp.MaDM = d1.MaDM;
            sp.MaCL = CLid.MaCL;
            _context.SANPHAMs.Add(sp);
            _context.SaveChanges();

            var SPid = _context.SANPHAMs
                .OrderByDescending(id => id.MaSP)
                .FirstOrDefault();

            var ctSP = new CHITIETSP();
            ctSP.MaSP = SPid.MaSP;

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

        public ActionResult ThongKe()
        {
            var donHang = _context.DONHANGs;
            var donHangL = donHang.ToList();

            int[] tk = new int[14];
            int[] tkSLDH = new int[14];
            for (int i = 0; i <= 12; i++)
            {
                tk[i] = 0;
                tkSLDH[i] = 0;
            }
            var tkTT = new Dictionary<string, int>()
            { {"Tiếp nhận", 0},
                {"Đang vận chuyển", 0 },
                {"Hủy", 0 }
            }
            ;
            foreach (var d in donHangL)
            {
                var ng = d.NgayGiao.Value.Month.ToString();
                int ngI = Int32.Parse(ng);
                tk[ngI] += Int32.Parse(d.TongTien.ToString());
                tkSLDH[ngI] += 1;
                tkTT[d.TinhTrang.ToString()] += 1;
            }

            var tkDT = new Dictionary<string, int> { };
            var tk_SLDH = new Dictionary<string, int> { };
            

            for (int i = 0; i<12; i++)
            {
                int x = i + 1;
                string m = (x).ToString();
                tkDT[m] = tk[x];
                tk_SLDH[m] = tkSLDH[x];
            }

            
            ViewBag.tkDT = tkDT;
            ViewBag.tkSLDH = tk_SLDH;
            ViewBag.tkTT = tkTT;
            return View();
        }

        public PartialViewResult DsDonHang(int? pageIndex)
        {

            int _pageIndex = pageIndex ?? 1;

            //var NDBinhLuan = (from sp in db.SANPHAMs
            //                  join BinhLuan in db.BINHLUANSPs on sp.MaSP equals BinhLuan.MaSP
            //                  join Kh in db.KHACHHANGs on BinhLuan.MaKH equals Kh.MaKH
            //                  where sp.MaSP == id
            //                  select new BinhLuan
            //                  {
            //                      TenKH = Kh.TenKH,
            //                      ND = BinhLuan.ND,
            //                      MaBL = BinhLuan.MaBL,
            //                      Sao = BinhLuan.Sao,
            //                      NgayBinhLuan = BinhLuan.NgayBinhLuan

            //                  }).OrderBy(s => s.MaBL).ToPagedList(_pageIndex, 2);

            var DonHang = (from dh in _context.DONHANGs
                           join ctDH in _context.CHITIETDHs on dh.MaDH equals ctDH.MaDH
                           join KH in _context.KHACHHANGs on dh.MaKH equals KH.MaKH
                           join ctSP in _context.CHITIETSPs on ctDH.MaChiTietSP equals ctSP.MaChiTietSP
                           join sp in _context.SANPHAMs on ctSP.MaSP equals sp.MaSP
                           select new DonHangAD
                           {
                               MaDH = dh.MaDH,
                               TenKH = KH.TenKH,
                               TenSP = sp.TenSP,
                               TongTien = dh.TongTien,
                               TinhTrang = dh.TinhTrang
                           }).OrderBy(s => s.MaDH).ToPagedList(_pageIndex, 2);
            return PartialView(DonHang);
        }


        public ActionResult QLDonHang()
        {
            var DonHang = (from dh in _context.DONHANGs
                           join ctDH in _context.CHITIETDHs on dh.MaDH equals ctDH.MaDH
                           join KH in _context.KHACHHANGs on dh.MaKH equals KH.MaKH
                           join ctSP in _context.CHITIETSPs on ctDH.MaChiTietSP equals ctSP.MaChiTietSP
                           join sp in _context.SANPHAMs on ctSP.MaSP equals sp.MaSP
                           join cl in _context.MAUSACs on ctSP.MaMau equals cl.MaMau
                           join sz in _context.SIZEs on ctSP.MaSize equals sz.MaSize
                           select new DonHangAD
                           {
                               MaDH = dh.MaDH,
                               TenKH = KH.TenKH,
                               TenSP = sp.TenSP,
                               TongTien = dh.TongTien,
                               TinhTrang = dh.TinhTrang,
                               Mau = cl.MaHeXan,
                               Size = sz.Size1,
                               SoLuong = ctDH.SoLuong
                           }).OrderBy(s => s.MaDH).ToList();

            List<string> TinhTrang1 = new List<string>() { };
            int i = 0;
            foreach(var data in DonHang)
            {
                TinhTrang1.Add(data.TinhTrang);
                i++;
            }
            TinhTrang1= TinhTrang1.Distinct().ToArray();
            var d = _context.DANHMUCSPs.ToList();

            ViewBag.TT = TinhTrang1;
            return View(DonHang);
        }
    }
}