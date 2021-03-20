using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        private const int SaltByteSize = 24;
        private const int HashByteSize = 24;
        private const int Pbkdf2Iterations = 1000;

        private const int IterationIndex = 0;
        private const int SaltIndex = 1;
        private const int Pbkdf2Index = 2;

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
        public StorageUser Login(LoginModel model)
        {
            var user = _userService.GetByName(model.UserName);

            if (user == null)
            {
                return null;
            }

            user.LastLogin = DateTime.Now;

            _userService.Update(user);

            return ValidatePassword(model.Password, user.Password)
                ? new StorageUser
                {
                    Token = Token(user), UserName = user.UserName, Id = user.Id, Email = user.Email,
                    FullName = user.FullName
                }
                : null;
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
        public string Token(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
                new Claim("lastlogin", user.LastLogin.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string HashPassword(string password)
        {
            var cryptoServiceProvider = new RNGCryptoServiceProvider();
            var salt = new byte[SaltByteSize];
            cryptoServiceProvider.GetBytes(salt);

            var hash = Pbkdf2(password, salt, Pbkdf2Iterations, HashByteSize);
            return Pbkdf2Iterations + ":" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
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
            int iterations = Int32.Parse(split[IterationIndex]);

            byte[] salt = Convert.FromBase64String(split[SaltIndex]);
            byte[] hash = Convert.FromBase64String(split[Pbkdf2Index]);

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