using KarmaModels.KarmaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarmaModels
{
    public class CustomerModel
    {
        private KarmaDBContext context = null;
        public CustomerModel()
        {
            context = new KarmaDBContext();
        }
        public customer getById(string Id)
        {
            customer cus = context.customers.SingleOrDefault(u => u.CustomerId == Id);
            return cus;
        }
    }
}
