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

        public ConsumerService(IMapper mapper, FoodDeliveryDbContext dbContext, IConfiguration config)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public OrderDto CreateOrder(OrderDto newOrder)
        {
            OrderModel order = _mapper.Map<OrderModel>(newOrder);

            order.Status = Enums.Enums.OrderStatusType.Prepering;

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            return newOrder;
        }

        public bool Order(long orderId)
        {
            var order = _dbContext.Orders.Find(orderId);

            if (order == null)
                return false;

            order.Status = Enums.Enums.OrderStatusType.Wating;

            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();

            return true;
        }

        public OrderDetailsDto AddOrderDetail(long orderId, long productId, int amount)
        {
            var order = _dbContext.Orders.Find(orderId);
            var product = _dbContext.Products.Find(productId);

            if (order.Status != Enums.Enums.OrderStatusType.Prepering || product == null)
                return null;

            OrderDetailsDto orderDetails = new OrderDetailsDto
            {
                OrderId = orderId,
                ProductId = productId,
                Amount = amount,
                OrderDate = DateTime.Now,
                CurrentPrice = product.Price
            };

            var orderDetailsModel = _mapper.Map<OrderDetailsModel>(orderDetails);

            _dbContext.OrderDetails.Add(orderDetailsModel);
            _dbContext.SaveChanges();

            return orderDetails;
        }

        public List<OrderDto> GetOrders(string email)
        {
            List<OrderDto> orders = new List<OrderDto>();

            var ordersModel = _dbContext.Orders.Where(x => x.CreatorEmail == email && x.Status == Enums.Enums.OrderStatusType.Delivered).ToList();

            foreach (var item in ordersModel)
            {
                orders.Add(_mapper.Map<OrderDto>(item));
            }

            return orders;
        }

        public List<OrderDetailsDto> GetOrdersDetails(string email)
        {
            var orders = GetOrders(email);

            List<OrderDetailsDto> orderDetails = new List<OrderDetailsDto>();

            foreach (var item in orders)
            {
                var details = _dbContext.OrderDetails.Where(x => x.OrderId == item.Id);

                foreach (var item2 in details)
                {
                    orderDetails.Add(_mapper.Map<OrderDetailsDto>(item2));
                }
            }

            return orderDetails;
        }
    }
}
