using Shop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Models;

namespace Shop.DataAccess.Repository
{

    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
