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
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IMapper _mapper;
        private readonly FoodDeliveryDbContext _dbContext;

        public OrderDetailsService(IMapper mapper, FoodDeliveryDbContext dbContext, IConfiguration config)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public bool DeleteOrderDetail(long orderDetailsId)
        {
            var orderDetails = _dbContext.OrderDetails.Find(orderDetailsId);

            if (orderDetails == null)
                return false;

            _dbContext.OrderDetails.Remove(orderDetails);
            _dbContext.SaveChanges();

            return true;
        }

        public OrderDetailsDto FindById(long orderDetailsId)
        {
            var order = _dbContext.OrderDetails.Find(orderDetailsId);

            return _mapper.Map<OrderDetailsDto>(order);
        }

        public List<OrderDetailsDto> RetrieveOrdersDetails()
        {
            List<OrderDetailsDto> orederDetailsResult = new List<OrderDetailsDto>();

            var ordersDetails = _dbContext.OrderDetails;

            foreach (var item in ordersDetails)
            {
                OrderDetailsDto orderDetailsDto = _mapper.Map<OrderDetailsDto>(item);
                orederDetailsResult.Add(orderDetailsDto);
            }

            return orederDetailsResult;
        }

        public bool UpdateOrderDetail(OrderDetailsDto updatedOrderDetails)
        {
            _dbContext.OrderDetails.Update(_mapper.Map<OrderDetailsModel>(updatedOrderDetails));

            return true;
        }
    }
}
