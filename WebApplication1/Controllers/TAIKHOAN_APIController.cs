using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using KarmaModels.KarmaModels;

namespace WebApplication1.Controllers
{
    
    public class TAIKHOAN_APIController : ApiController
    {
        KarmaDBContext _context = new KarmaDBContext();
        // GET: api/TAIKHOAN_API
        public IEnumerable<TK_View_Model> Get()
        {
            var model = _context.TAIKHOANs.
                Select(t => new TK_View_Model() {
                    id = t.id,
                    MaKH = t.MaKH,
                    username = t.username,
                    pass= t.pass,
                    Quyen = t.Quyen
                
            }).ToList();
            return model;
        }

        // GET: api/TAIKHOAN_API
        
        // POST: api/TAIKHOAN_API
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TAIKHOAN_API/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TAIKHOAN_API/5
        public void Delete(int id)
        {
        }
    }
}
