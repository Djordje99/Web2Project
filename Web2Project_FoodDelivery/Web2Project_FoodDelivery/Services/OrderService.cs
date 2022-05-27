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
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly FoodDeliveryDbContext _dbContext;

        public OrderService(IMapper mapper, FoodDeliveryDbContext dbContext, IConfiguration config)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public bool DeleteOrder(long orderId)
        {
            var order = _dbContext.Orders.Find(orderId);

            if (order == null)
                return false;

            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();

            return true;
        }

        public OrderDto FindById(long orderId)
        {
            var order = _dbContext.Orders.Find(orderId);

            return _mapper.Map<OrderDto>(order);
        }

        public List<OrderDto> RetrieveOrders()
        {
            List<OrderDto> orederResult = new List<OrderDto>();

            var orders = _dbContext.Orders;

            foreach (var item in orders)
            {
                OrderDto orderDto = _mapper.Map<OrderDto>(item);
                orederResult.Add(orderDto);
            }

            return orederResult;
        }

        public bool UpdateOrder(OrderDto updatedOrder)
        {
            _dbContext.Orders.Update(_mapper.Map<OrderModel>(updatedOrder));

            return true;
        }
    }
}
