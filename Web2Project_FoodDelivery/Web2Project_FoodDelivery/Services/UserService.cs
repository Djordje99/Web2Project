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
using static Web2Project_FoodDelivery.Enums.Enums;

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

        public TokenDto Login(LogInUserDto userToLog)
        {
            UserModel user = null;
            user = _dbContext.Users.Find(userToLog.Email);
            List<Claim> claims = new List<Claim>();

            if(user == null || user.Veryfied != VeryfiedType.Approved || user.AccepredRegistration == false)
                return null;

            if (BCrypt.Net.BCrypt.Verify(userToLog.Password, user.Password, false, BCrypt.Net.HashType.SHA256))
            {
                if (user.Type == Enums.Enums.UserType.Consumer)
                {
                    claims.Add(new Claim("role", "Consumer"));
                }
                else if (user.Type == Enums.Enums.UserType.Deliverer)
                {
                    claims.Add(new Claim("role", "Deliverer"));
                }
                else if (user.Type == Enums.Enums.UserType.Admin)
                {
                    claims.Add(new Claim("role", "Admin"));
                }

                claims.Add(new Claim("email", user.Email));


                SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.Value));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:44323/",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signinCredentials
                    );

                string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                TokenDto token = new TokenDto { Token = tokenString };
                
                return token;
            }
            else
            {
                return null;
            }
        }

        public UserDto Register(RegisterUserDto userToRegister)
        {

            UserModel userModel = _dbContext.Users.Find(userToRegister.Email);
            UserType ut = UserType.Consumer;
            var veryfied = VeryfiedType.Approved;
            var activate = false;
            if (userToRegister.UserType == 2)
            {
                ut = UserType.Deliverer;
                veryfied = VeryfiedType.InProgress;

            }
            else if (userToRegister.UserType == 0)
            {
                ut = UserType.Admin;
                activate = true;
            }

            if (userModel != null || userToRegister.Password != userToRegister.PasswordVerify)
                return null;

            UserDto user = new UserDto
            {
                FirstName = userToRegister.FirstName,
                LastName = userToRegister.LastName,
                Email = userToRegister.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userToRegister.Password),
                Username = userToRegister.Username,
                Address = userToRegister.Address,
                Birthday = userToRegister.Birthday,
                Picture = userToRegister.Photo,
                Veryfied = veryfied,
                AccepredRegistration = activate,
                Type = ut
            };

            userModel = _mapper.Map<UserModel>(user);

            _dbContext.Users.Add(userModel);
            _dbContext.SaveChanges();

            return user;
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

        public UserDto FindById(UserEmailDto email)
        {
            var userDb = _dbContext.Users.Find(email.Email);

            return _mapper.Map<UserDto>(userDb);
        }

        public bool AddUsersPicture(string email, string path)
        {
            UserModel user = _dbContext.Users.Find(email);

            if (user == null)
                return false;

            user.Picture = path;
            _dbContext.SaveChanges();
            return true;
        }

        public string GetUsersPicture(string email)
        {
            UserModel user = _dbContext.Users.Find(email);

            if (user == null)
                return string.Empty;
            else
                return user.Picture;
        }
    }
}
