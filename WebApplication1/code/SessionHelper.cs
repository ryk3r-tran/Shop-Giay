using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.code
{
    public class SessionHelper
    {
        public static void SetSession(CustomerSession session)
        {
            HttpContext.Current.Session["LoginSession"] = session;
        }
        public static CustomerSession GetSession()
        {
            var session = HttpContext.Current.Session["LoginSession"];
            if (session == null)
            {
                return null;
            }
            else
            {
                return session as CustomerSession;
            }
        }
    }
}