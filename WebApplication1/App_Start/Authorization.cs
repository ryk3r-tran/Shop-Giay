using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using KarmaModels.KarmaModels;

namespace WebApplication1.App_Start
{
    public class Authorization : AuthorizeAttribute
    {
        public string Quyen { set; get; }
        KarmaDBContext _context = new KarmaDBContext();
        public string[] getQuyen()
        {
            string[] quyen = Quyen.Split(',');
            return quyen;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //check login
            KHACHHANG customer = (KHACHHANG)HttpContext.Current.Session["UserLogin"];
            if (customer != null)
            {
                TAIKHOAN acc = _context.TAIKHOANs.SingleOrDefault(p => p.MaKH == customer.MaKH);
                string[] quyen = getQuyen();
                
                if (quyen.Contains(acc.Quyen))
                {
                    return;
                }
                else
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new
                            {
                                controller = "GioHang",
                                action = "ThanhToan",
                            })
                        );
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new
                            {
                                controller = "GioHang",
                                action = "ThanhToan",
                            })
                        );
                    }
                    
                }
            }
            else{
                var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        controller = "TaiKhoan",
                        action = "DangNhap",
                        returnUrl = returnUrl
                    })
                 );
            }
        }
    }
}