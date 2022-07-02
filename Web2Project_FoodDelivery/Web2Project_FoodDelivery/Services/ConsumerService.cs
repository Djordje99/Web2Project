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
    public class ConsumerService : IConsumerService
    {
        private readonly IMapper _mapper;
        private readonly FoodDeliveryDbContext _dbContext;
        private List<ProductDto> products = new List<ProductDto>();

        public ConsumerService(IMapper mapper, FoodDeliveryDbContext dbContext, IConfiguration config)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public OrderDto CreateOrder(OrderDto newOrder)
        {
            OrderModel order = _mapper.Map<OrderModel>(newOrder);

            order.Status = Enums.Enums.OrderStatusType.Wating;

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            return _mapper.Map<OrderDto>(order);
        }

        public OrderDetailsDto AddProdactOrder(OrderDetailsDto product)
        {
            var productDb = _dbContext.Products.Find(product.ProductId);

            if (productDb == null)
                return null;

            var productDetail = _mapper.Map<OrderDetailsModel>(product);

            _dbContext.OrderDetails.Add(productDetail);
            _dbContext.SaveChanges();

            return _mapper.Map<OrderDetailsDto>(productDetail);
        }

        public List<OrderDto> GetOrders(UserEmailDto email)
        {
            List<OrderDto> orders = new List<OrderDto>();

            var ordersModel = _dbContext.Orders.Where(x => x.CreatorEmail == email.Email && x.Status == Enums.Enums.OrderStatusType.Delivered).ToList();

            foreach (var item in ordersModel)
            {
                orders.Add(_mapper.Map<OrderDto>(item));
            }

            return orders;
        }

        public List<OrderDto> GetCurrentOrders(UserEmailDto email)
        {
            List<OrderDto> orders = new List<OrderDto>();

            var ordersModel = _dbContext.Orders.Where(x => x.CreatorEmail == email.Email && x.Status != Enums.Enums.OrderStatusType.Delivered).ToList();

            foreach (var item in ordersModel)
            {
                orders.Add(_mapper.Map<OrderDto>(item));
            }

            return orders;
        }


        public List<ProductDto> GetOrdersDetails(UserProductsDto userProducts)
        {

            //var orders = GetOrders(new UserEmailDto { Email = userProducts.Email });
            //var order = orders.Find(x => x.Id == userProducts.OrderId);

            List<ProductDto> orderDetails = new List<ProductDto>();

            var details = _dbContext.OrderDetails.Where(x => x.OrderId == userProducts.OrderId);

            foreach (var item in details)
            {
                var productModel = _dbContext.Products.Find(item.ProductId);
                ProductDto productDto = _mapper.Map<ProductDto>(productModel);
                productDto.Amount = item.Amount;
                orderDetails.Add(productDto);
            }

            return orderDetails;
        }
    }
}
