using Shop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Models;

namespace Shop.DataAccess.Repository
{

    public interface IProductImageRepository : IRepository<ProductImage>
    {
        void Update(ProductImage obj);
        void Save();
    }
}
