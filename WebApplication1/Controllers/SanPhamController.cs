using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KarmaModels.KarmaModels;
using KarmaModels.Repository;
using WebApplication1.Models;
using PagedList;
namespace WebApplication1.Controllers

{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachSanPham()
        {
           
            
            var db = new KarmaDBContext();          
            var DanhMuc = db.DANHMUCSPs.ToList();

            ViewBag.NhaSanXuat = db.NSXes.ToList();

            return View(DanhMuc);
        }

       [HttpGet]
        public PartialViewResult DsSanPhamTheoTieuChi(int? pageIndex, int MaDanhMuc, int SapXep, int? MaNSX, int Sao)
        {
            var db = new KarmaDBContext();
            int _pageIndex = pageIndex ?? 1;
            int SoSanPham = 6;
            var DsSanPham = new List<SanPham>();
            if (MaNSX == null)
            {
                DsSanPham = (from sp in db.SANPHAMs
                             join nsx in db.NSXes on sp.MaNSX equals nsx.MaNSX
                             join anh in db.ANHs on sp.MaAnh equals anh.MaAnh
                             join dm in db.DANHMUCSPs on sp.MaDM equals dm.MaDM
                             join bl in db.BINHLUANSPs on sp.MaSP equals bl.MaSP

                            // orderby sp.DonGia descending
                             where dm.MaDM == MaDanhMuc
                             group new { sp, nsx, anh, bl } by new { bl.MaSP } into gr
                             let CaNhom = gr.FirstOrDefault()
                             let sanPham = CaNhom.sp
                             let NhaSanXuat = CaNhom.nsx
                             let a_nh = CaNhom.anh
                             let binhluan = CaNhom.bl
                             let TbSao = gr.Average(m => m.bl.Sao)

                             where Sao <= TbSao && TbSao < Sao + 1
                             //  where Sao <= gr.Average(s => s.Sao) && gr.Average(s => s.Sao) < (Sao + 1) 

                             select new SanPham
                             {
                                 TbSoSao = TbSao,
                                 Tensp = sanPham.TenSP,
                                Masp = sanPham.MaSP,
                                 Anh = a_nh.AnhChinh,
                                 TenNSX = NhaSanXuat.TenNSX,
                                 Gia = sanPham.DonGia.Value
                                
                                 
                             }).ToList();

                if (SapXep == 1)  // tăng dần
                {
                    return PartialView(DsSanPham.OrderByDescending(s=>s.Gia).ToPagedList(_pageIndex, SoSanPham));
                }

                else    // sắp xếp  = 2 giảm dân
                {
                    return PartialView(DsSanPham.OrderBy(s => s.Gia).ToPagedList(_pageIndex, SoSanPham));
                }
            }

            else 
            {
                DsSanPham = (from sp in db.SANPHAMs
                             join nsx in db.NSXes on sp.MaNSX equals nsx.MaNSX
                             join anh in db.ANHs on sp.MaAnh equals anh.MaAnh
                             join dm in db.DANHMUCSPs on sp.MaDM equals dm.MaDM
                             join bl in db.BINHLUANSPs on sp.MaSP equals bl.MaSP

                             // orderby sp.DonGia descending
                             where dm.MaDM == MaDanhMuc && nsx.MaNSX == MaNSX
                             group new { sp, nsx, anh, bl } by new { bl.MaSP } into gr
                             let CaNhom = gr.FirstOrDefault()
                             let sanPham = CaNhom.sp
                             let NhaSanXuat = CaNhom.nsx
                             let a_nh = CaNhom.anh
                             let binhluan = CaNhom.bl
                             let TbSao = gr.Average(m => m.bl.Sao)

                             where Sao <= TbSao && TbSao < Sao + 1
                             //  where Sao <= gr.Average(s => s.Sao) && gr.Average(s => s.Sao) < (Sao + 1) 

                             select new SanPham
                             {
                                 TbSoSao = TbSao,
                                 Tensp = sanPham.TenSP,
                                 Anh = a_nh.AnhChinh,
                                 TenNSX = NhaSanXuat.TenNSX,
                                 Gia = sanPham.DonGia.Value,
                                 Masp = sanPham.MaSP,
                             }).ToList();


                if (SapXep == 1)
                {
                    return PartialView(DsSanPham.OrderByDescending(s => s.Gia).ToPagedList(_pageIndex, SoSanPham));
                }
                else    // sắp xếp  = 2
                {
                    return PartialView(DsSanPham.OrderBy(s => s.Gia).ToPagedList(_pageIndex, SoSanPham));
                }
            }
           
             return PartialView(DsSanPham.OrderBy(s => s.TbSoSao).ToPagedList(_pageIndex, SoSanPham));
            
        }


        public PartialViewResult TimKiem(int? pageIndex, String TimKiem)
        {

            var db = new KarmaDBContext();
            int _pageIndex = pageIndex ?? 1;
            int SoSanPham = 6;
           
            SanPham sp = new SanPham();

            List<SanPham> DsSanPham = sp.GetDsSanPham(TimKiem);

            return PartialView(DsSanPham.ToPagedList(_pageIndex, SoSanPham));
        }


   

        public ActionResult SanPhamChiTiet(int id)
        {
            IRepository<SANPHAM> sanpham = new Repository<SANPHAM>();
            var SanPhamChon = sanpham.GetById(id);
            return View(SanPhamChon);

           
        }
        public PartialViewResult DsBinhLuan(int? pageIndex, int id)
        {
            var db = new KarmaDBContext();
            int _pageIndex = pageIndex ?? 1;

            var NDBinhLuan = (from sp in db.SANPHAMs
                              join BinhLuan in db.BINHLUANSPs on sp.MaSP equals BinhLuan.MaSP
                              join Kh in db.KHACHHANGs on BinhLuan.MaKH equals Kh.MaKH
                              where sp.MaSP == id
                              select new BinhLuan
                              {
                                  TenKH = Kh.TenKH,
                                  ND = BinhLuan.ND,
                                  MaBL = BinhLuan.MaBL,
                                  Sao = BinhLuan.Sao,
                                  NgayBinhLuan = BinhLuan.NgayBinhLuan

                              }).OrderBy(s => s.MaBL).ToPagedList(_pageIndex,2);

            return PartialView(NDBinhLuan);

        }

        public ActionResult TestSao()
        {
            return View();
        }
    }
}

