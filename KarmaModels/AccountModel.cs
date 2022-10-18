using KarmaModels.KarmaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarmaModels
{
    public class AccountModel
    {
        private KarmaDBContext context = null;
        public AccountModel()
        {
            context = new KarmaDBContext();
        }
        public Account Login(string username, string password)
        {
            Account check_account = context.Accounts.SingleOrDefault(u => u.username == username && u.pass == password);
            if (check_account != null)
            {
                return check_account;
            }
            else
            {
                return null;
            }
        }
    }
}
