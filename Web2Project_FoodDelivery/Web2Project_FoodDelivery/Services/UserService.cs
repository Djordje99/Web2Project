using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.DTO;
using Web2Project_FoodDelivery.Infrastructure;
using Web2Project_FoodDelivery.Interfaces;
using Web2Project_FoodDelivery.Models;

namespace Web2Project_FoodDelivery.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly FoodDeliveryDbContext _dbContext;
        private readonly IConfigurationSection _secretKey;

        public UserService(IMapper mapper, FoodDeliveryDbContext dbContext, IConfiguration config)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _secretKey = config.GetSection("SecretKey");
        }

        public string Login(string email, string password)
        {
            UserModel user = null;
            user = _dbContext.Users.Find(email);
            List<Claim> claims = new List<Claim>();

            if(user == null || user.AccepredRegistration == false)
                return null;

            if (BCrypt.Net.BCrypt.Verify(password, user.Password, false, BCrypt.Net.HashType.SHA256))
            {
                if (user.Type == Enums.Enums.UserType.Consumer)
                    claims.Add(new Claim(ClaimTypes.Role, "Consumer"));
                else if (user.Type == Enums.Enums.UserType.Deliverer)
                    claims.Add(new Claim(ClaimTypes.Role, "Deliverer"));
                else if (user.Type == Enums.Enums.UserType.Admin)
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));


                SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.Value));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44398", //url servera koji je izdao token
                    claims: claims, //claimovi
                    expires: DateTime.Now.AddMinutes(20), //vazenje tokena u minutama
                    signingCredentials: signinCredentials, //kredencijali za potpis
                    audience: email
                    );

                string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return tokenString;
            }
            else
            {
                return null;
            }
        }

        public UserDto Register(string firstName, string lastName,
                                      string email, string password,
                                      string passwordVerify, string username,
                                      DateTime birthday, string address,
                                      string photo, Enums.Enums.UserType userType)
        {

            UserModel userModel = _dbContext.Users.Find(email);

            if(userModel != null || password != passwordVerify || userType == Enums.Enums.UserType.Admin)
                return null;

            UserDto user = new UserDto
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                Username = username,
                Address = address,
                Birthday = birthday,
                Picture = photo,
                Veryfied = Enums.Enums.VeryfiedType.InProgress,
                AccepredRegistration = false,
                Type = userType
            };

            userModel = _mapper.Map<UserModel>(user);

            _dbContext.Users.Add(userModel);
            _dbContext.SaveChanges();

            return FindById(user.Email);
        }

        public List<UserDto> RetrieveUsers()
        {
            List<UserDto> userResult = new List<UserDto>();

            var users = _dbContext.Users;

            foreach (var item in users)
            {
                UserDto userDto = _mapper.Map<UserDto>(item);
                userResult.Add(userDto);
            }

            return userResult;
        }

        public bool UpdateUser(UserDto updateUser)
        {
            _dbContext.Users.Update(_mapper.Map<UserModel>(updateUser));

            return true;
        }

        public bool DeleteUser(string email)
        {
            var user = _dbContext.Users.Find(email);

            if (user == null)
                return false;

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return true;
        }

        public UserDto FindById(string email)
        {
            var user = _dbContext.Users.Find(email);

            return _mapper.Map<UserDto>(user);
        }
    }
}
