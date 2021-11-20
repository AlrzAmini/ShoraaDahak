using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.Core.DTOs;
using ShoraaDahak.Core.Generators;
using ShoraaDahak.Core.Security;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Context;
using ShoraaDahak.DataLayer.Models.User;

namespace ShoraaDahak.Core.Services
{
    public class UserService : IUserService
    {
        private readonly ShooraDahakContext _context;

        public UserService(ShooraDahakContext context)
        {
            _context = context;
        }

        public bool IsEmailExist(string email)
        {
            return _context.Users.Any(e => e.Email == email);
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.UserId;
        }

        public bool IsNCodeExist(string nCode)
        {
            return _context.Users.Any(u => u.NCode == nCode);
        }

        public User IsUserValid(LoginViewModel login)
        {
            return _context.Users.SingleOrDefault(u =>
                u.NCode == login.NCode && u.Password == PasswordHasher.EncodePasswordMd5(login.Password));
        }

        public bool ActiveUser(string activeCode)
        {
            User user = _context.Users.SingleOrDefault(u => u.ActivationCode == activeCode);

            if (user == null || user.IsActive)
            {
                return false;
            }

            user.IsActive = true;
            user.ActivationCode = CodeGenerator.GenerateUniqCode();

            _context.SaveChanges();

            return true;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User GetUserByActivationCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u => u.ActivationCode == activeCode);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
