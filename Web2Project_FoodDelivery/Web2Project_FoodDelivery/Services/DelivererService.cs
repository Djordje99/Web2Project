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
    public class DelivererService : IDelivererService
    {
        private readonly IMapper _mapper;
        private readonly FoodDeliveryDbContext _dbContext;

        public DelivererService(IMapper mapper, FoodDeliveryDbContext dbContext, IConfiguration config)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public List<OrderDto> SeeAvailableOrders()
        {
            List<OrderDto> orederResult = new List<OrderDto>();

            var orders = _dbContext.Orders;

            foreach (var item in orders)
            {
                OrderDto orderDto = _mapper.Map<OrderDto>(item);
                if(orderDto.Status == Enums.Enums.OrderStatusType.Wating)
                    orederResult.Add(orderDto);
            }

            return orederResult;
        }

        public int TakeOrder(long orderId, string delivererEmail)
        {
            var order = _dbContext.Orders.Find(orderId);
            var user = _dbContext.Users.Find(delivererEmail);

            if (order == null || order.Status != Enums.Enums.OrderStatusType.Wating || (user.Type == Enums.Enums.UserType.Deliverer &&
                (user.Veryfied == Enums.Enums.VeryfiedType.Denied || user.Veryfied == Enums.Enums.VeryfiedType.InProgress)))
                return -1;

            order.Status = Enums.Enums.OrderStatusType.InProgress;
            _dbContext.Orders.Update(order);

            DeliveryDto delivery = new DeliveryDto
            {
                DelivererEmail = delivererEmail,
                OrderId = orderId
            };

            _dbContext.Deliveries.Add(_mapper.Map<DeliveryModel>(delivery));
            _dbContext.SaveChanges();

            return new Random().Next(1, 40); 
        }

        public List<OrderDto> GetDeliveredOrders(string email)
        {
            List<OrderDto> orders = new List<OrderDto>();

            var deliverisModel = _dbContext.Deliveries.Where(x => x.DelivererEmail == email).ToList();

            foreach (var item in deliverisModel)
            {
                var order = _dbContext.Orders.Where(x => x.Id == item.OrderId && x.Status == Enums.Enums.OrderStatusType.Delivered);

                orders.Add(_mapper.Map<OrderDto>(order));
            }

            return orders;
        }

        public List<OrderDetailsDto> GetOrdersDetails(string email)
        {
            var orders = GetDeliveredOrders(email);

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
