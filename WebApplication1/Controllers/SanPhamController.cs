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
            return View();
        }


        public int ThongKeSoSao( int SoSao)
        {
            var db = new KarmaDBContext();
            int MaSP = Convert.ToInt32(TempData["ID"]);
            return db.BINHLUANSPs.Count(s => s.Sao == SoSao && s.MaSP == 2);

        }
        public ActionResult SanPhamChiTiet(int id, int page = 1)
        {
            IRepository<SANPHAM> sanpham = new Repository<SANPHAM>();
            var SanPhamChon = sanpham.GetById(id);

            var db = new KarmaDBContext();

            int pageSize = 2;
            TempData["ID"] = id;

            ViewBag.NDBinhLuan = (from sp in db.SANPHAMs
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
                                      
                                  }).OrderBy(s => s.MaBL).ToPagedList(page, pageSize);

            ViewBag.MotSao = ThongKeSoSao(1);
            ViewBag.HaiSao = ThongKeSoSao(2);
            ViewBag.BaSao = ThongKeSoSao(3);
            ViewBag.BonSao = ThongKeSoSao(4);
            ViewBag.NamSao = ThongKeSoSao(5);

            return View(SanPhamChon);

        }
        public ActionResult BinhLuanPatialView()
        {
            int MaSP = Convert.ToInt32(TempData["ID"]);
            return PartialView();
        }

        public ActionResult TestCauLenh()
        {
            ViewBag.NamSao = ThongKeSoSao(5);
            return View();
        }
    }
}