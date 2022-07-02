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
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly FoodDeliveryDbContext _dbContext;

        public AdminService(IMapper mapper, FoodDeliveryDbContext dbContext, IConfiguration config)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public bool ActivateUser(UserEmailDto email)
        {
            UserModel user = _dbContext.Users.Find(email.Email);

            if (user.Type != Enums.Enums.UserType.Consumer && user.Type != Enums.Enums.UserType.Deliverer)
                return false;

            user.AccepredRegistration = true;

            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();

            return true;
        }

        public bool VerifyDeliverer(VerifyDto delivererVerify)
        {
            UserModel deliverer = _dbContext.Users.Find(delivererVerify.Email);

            if (deliverer.Type != Enums.Enums.UserType.Deliverer)
                return false;

            deliverer.Veryfied = delivererVerify.VerifyType;

            _dbContext.Users.Update(deliverer);
            _dbContext.SaveChanges();

            return true;
        }

        public List<UserDto> SeeDelivererStatus()
        {
            List<UserDto> userResult = new List<UserDto>();

            var user = _dbContext.Users;

            foreach (var item in user)
            {
                UserDto userDto = _mapper.Map<UserDto>(item);
                if (userDto.Type == Enums.Enums.UserType.Deliverer && userDto.Veryfied != Enums.Enums.VeryfiedType.Approved)
                    userResult.Add(userDto);
            }

            return userResult;
        }

        public List<UserDto> SeeActivationRequests()
        {
            List<UserDto> userResult = new List<UserDto>();

            var users = _dbContext.Users;

            foreach (var item in users)
            {
                UserDto userDto = _mapper.Map<UserDto>(item);
                if (userDto.AccepredRegistration == false)
                    userResult.Add(userDto);
            }

            return userResult;
        }

        public ProductDto CreateProduct(ProductDto newProduct)
        {
            ProductModel product = _mapper.Map<ProductModel>(newProduct);

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return newProduct;
        }

        public List<OrderDto> GetAllOrders()
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
    }
}