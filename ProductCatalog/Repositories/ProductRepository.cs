using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Interfaces;
using ProductCatalog.Models;
using ProductCatalog.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<ListProductViewModel> Get()
        {
            return _context.Products
                .Include(c => c.Category)
                .Select(p => new ListProductViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Price = p.Price,
                    Category = p.Category.Title,
                    CategoryId = p.Category.Id
                })
                .AsNoTracking()
                .ToList();
        }

        public Product Get(int id)
        {
            return _context.Products.AsNoTracking().Where(p => p.Id == id).FirstOrDefault();
        }

        public void Post(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Put(Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
