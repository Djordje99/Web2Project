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

        public int TakeOrder(DeliveryDto delivery)
        {
            var order = _dbContext.Orders.Find(delivery.OrderId);
            var user = _dbContext.Users.Find(delivery.DelivererEmail);

            if (order == null || order.Status != Enums.Enums.OrderStatusType.Wating || (user.Type == Enums.Enums.UserType.Deliverer &&
                (user.Veryfied == Enums.Enums.VeryfiedType.Denied || user.Veryfied == Enums.Enums.VeryfiedType.InProgress)))
                return -1;

            order.Status = Enums.Enums.OrderStatusType.InProgress;
            _dbContext.Orders.Update(order);

            _dbContext.Deliveries.Add(_mapper.Map<DeliveryModel>(delivery));
            _dbContext.SaveChanges();

            return new Random().Next(1, 40); 
        }

        public List<OrderDto> GetDeliveredOrders(UserEmailDto email)
        {
            List<OrderDto> ordersDto = new List<OrderDto>();

            var deliverisModel = _dbContext.Deliveries.Where(x => x.DelivererEmail == email.Email).ToList();

            foreach (var item in deliverisModel)
            {
                var orders = _dbContext.Orders.Where(x => x.Id == item.OrderId && x.Status == Enums.Enums.OrderStatusType.Delivered).ToList();

                foreach (var orderModel in orders)
                {
                    ordersDto.Add(_mapper.Map<OrderDto>(orderModel));
                }
            }

            return ordersDto;
        }

        public List<OrderDto> GetActualOrders(UserEmailDto email)
        {
            List<OrderDto> ordersDto = new List<OrderDto>();

            var deliverisModel = _dbContext.Deliveries.Where(x => x.DelivererEmail == email.Email).ToList();

            foreach (var item in deliverisModel)
            {
                var orders = _dbContext.Orders.Where(x => x.Id == item.OrderId && x.Status == Enums.Enums.OrderStatusType.InProgress).ToList();

                foreach (var orderModel in orders)
                {
                    ordersDto.Add(_mapper.Map<OrderDto>(orderModel));
                }
            }

            return ordersDto;
        }

        public List<OrderDetailsDto> GetOrdersDetails(UserEmailDto email)
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
