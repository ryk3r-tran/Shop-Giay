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
    }
}
