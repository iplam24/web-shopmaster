using Shop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Models;

namespace Shop.DataAccess.Repository
{

    public interface INewsRepository : IRepository<News>
    {
        void Update(News obj);
        void Save();
    }
}
