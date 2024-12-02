

using Shop.DataAccess.Repository;
using Shop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Models;

namespace Shop.DataAccess
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        private ApplicationDbContext _db;
        public NewsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(News obj)
        {
            _db.newss.Update(obj);
        }
    }
}
