using KarmaModels.KarmaModels;
using KarmaModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarmaModels
{
    public class AccountModel
    {
        KarmaDBContext _context = new KarmaDBContext();
        public TAIKHOAN IdenAccount(string usrname, string password)
        {
            var taikhoan = _context.TAIKHOANs.SingleOrDefault(u => u.username == usrname && u.pass == password);
            if (taikhoan != null)
            {
                return taikhoan;
            }
            else
            {
                return null;
            }
        }
    }
}
