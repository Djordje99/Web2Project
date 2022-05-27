using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;
using Web2Project_FoodDelivery.Infrastructure;
using Web2Project_FoodDelivery.Interfaces;
using Web2Project_FoodDelivery.Models;

namespace Web2Project_FoodDelivery.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly FoodDeliveryDbContext _dbContext;

        public ProductService(IMapper mapper, FoodDeliveryDbContext dbContext, IConfiguration config)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public bool DeleteProduct(long productId)
        {
            ProductModel product = _dbContext.Products.Find(productId);

            if (product == null)
                return false;

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();

            return true;
        }

        public ProductDto FindById(long productId)
        {
            ProductModel product = _dbContext.Products.Find(productId);

            return _mapper.Map<ProductDto>(product);
        }

        public List<ProductDto> RetreveProducts()
        {
            List<ProductDto> productResult = new List<ProductDto>();

            var products = _dbContext.Products;

            foreach (var item in products)
            {
                ProductDto productDto = _mapper.Map<ProductDto>(item);
                productResult.Add(productDto);
            }

            return productResult;
        }

        public bool UpdateProduct(ProductDto updateProduct)
        {
            var product = _mapper.Map<ProductModel>(updateProduct);

            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
