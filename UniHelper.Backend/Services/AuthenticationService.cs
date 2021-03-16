using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UniHelper.Backend.Entities;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Services
{
    /// <inheritdoc />
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        /// <summary>
        /// Authentication Service
        /// </summary>
        /// <param name="configuration">Configuration</param>
        /// <param name="userService">User Service</param>
        public AuthenticationService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }
        
        /// <inheritdoc />
        public string Login(LoginModel model)
        {
            var user = _userService.GetByName(model.UserName);

            if (user == null)
            {
                return "";
            }

            return ValidatePassword(model.Password, user.Password) ? Token() : "";
        }

        /// <inheritdoc />
        public void Registration(RegistrationModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email,
                Password = HashPassword(model.Password),
                LastLogin = DateTime.Now,
                Registration = DateTime.Now
            };
            
            _userService.Add(user);
        }

        /// <inheritdoc />
        public string Token()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"], 
                _configuration["Jwt:Issuer"], 
                null,
                expires: DateTime.Now.AddMinutes(120), 
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string HashPassword(string password)
        {
            var cryptoServiceProvider = new RNGCryptoServiceProvider();
            var salt = new byte[SALT_BYTE_SIZE];
            cryptoServiceProvider.GetBytes(salt);

            var hash = Pbkdf2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        private byte[] Pbkdf2(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt) {IterationCount = iterations};
            return pbkdf2.GetBytes(outputBytes);
        }

        private bool ValidatePassword(string password, string passwordHash)
        {
            char[] delimiter = {':'};
            string[] split = passwordHash.Split(delimiter);
            int iterations = Int32.Parse(split[ITERATION_INDEX]);

            byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
            byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            byte[] testHash = Pbkdf2(password, salt, iterations, hash.Length);

            return SlowEquals(hash, testHash);
        }

        private bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint) a.Length ^ (uint) b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint) (a[i] ^ b[i]);
            }

            return diff == 0;
        }
    }
}