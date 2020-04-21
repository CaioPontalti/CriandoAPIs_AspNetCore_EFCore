using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Interfaces;
using ProductCatalog.Models;
using ProductCatalog.ViewModels;
using ProductCatalog.ViewModels.ProductViewModels;

namespace ProductCatalog.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("v1/products")]
        [HttpGet]
        public IEnumerable<ListProductViewModel> GetAll()
        {
            return _productRepository.Get();
        }


        [Route("v1/product/{id}")]
        [HttpGet]
        public Product Get(int id)
        {
            // Find ainda não estava disponivel, por isso o uso do Where.
            return _productRepository.Get(id);
        }


        [Route("v1/product")]
        [HttpPost]
        public ResultViewModel Post([FromBody] CreateEditorProductViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o produto!",
                    Data = model.Notifications
                };
            }

            var product = new Product();
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.CreateDate = DateTime.Now;  //nunca recebe esse informação da tela
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now; //nunca recebe esse informação da tela
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _productRepository.Post(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto cadastrado com sucesso!",
                Data = product
            };
        }

        [Route("v1/product")]
        [HttpPut]
        public ResultViewModel Put([FromBody] CreateEditorProductViewModel model)
        {
            model.Validate();
            if (model.Invalid)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível atualizar o produto!",
                    Data = model.Notifications
                };
            }

            var product = _productRepository.Get(model.Id);
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.CreateDate = DateTime.Now;  //nunca recebe esse informação da tela
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now; //nunca recebe esse informação da tela
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _productRepository.Put(product);

            return new ResultViewModel
            {
                Success = true,
                Message = "Produto atualizado com sucesso!",
                Data = product
            };
        }
    }
}