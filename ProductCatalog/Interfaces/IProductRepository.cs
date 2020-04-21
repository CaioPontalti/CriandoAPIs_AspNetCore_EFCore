using ProductCatalog.Models;
using ProductCatalog.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ListProductViewModel> Get();
        Product Get(int id);
        void Post(Product model);
        void Put(Product model);
    }
}
