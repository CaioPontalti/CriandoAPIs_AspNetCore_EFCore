using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Context _context;

        public CategoryController(Context context)
        {
            _context = context;
        }

        [Route("v1/categories")]
        [HttpGet]
        //[ResponseCache(Location = ResponseCacheLocation.Client, Duration=60)] => Cache fica armazenado no client, não faz nem o Request              
        [ResponseCache(Duration = 60)] //Valor em minutos
        public IEnumerable<Category> Get()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category Get(int id)
        {
            // Find ainda não estava disponivel, por isso o uso do Where.
            return _context.Categories.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public List<Product> GetProducts(int id)
        {
            return _context.Products.AsNoTracking().Where(p => p.CategoryId == id).ToList();
        }

        [Route("v1/categories")]
        [HttpPost]
        public Category Post([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        [Route("v1/categories")]
        [HttpPut]
        public Category Put([FromBody] Category category)
        {
            _context.Entry<Category>(category).State = EntityState.Modified;
            _context.SaveChanges();

            return category;
        }

        [Route("v1/categories")]
        [HttpDelete]
        public Category Delete([FromBody] Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return category;
        }
    }
}