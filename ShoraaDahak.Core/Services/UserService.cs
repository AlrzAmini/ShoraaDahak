using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.Core.Consts;
using ShoraaDahak.Core.Convertors;
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

        public User GetUserByNCode(string nCode)
        {
            return _context.Users.SingleOrDefault(u => u.NCode == nCode);
        }

        public UserInformationViewModel GetUserInformation(string nCode)
        {
            var user = GetUserByNCode(nCode);

            var information = new UserInformationViewModel
            {
                Email = user.Email,
                NCode = user.NCode,
                PhoneNumber = user.PhoneNumber,
                Name = user.Name,
                BirthDate = user.BirthDate,
                RegisterDate = user.RegisterDate
            };

            return information;
        }

        public EditUserInfoViewModel GetUserInfoForEdit(string email)
        {


            return _context.Users.Where(u => u.Email == email)
                .Select(u => new EditUserInfoViewModel()
                {
                    Email = u.Email,
                    NCode = u.NCode,
                    BirthDate = u.BirthDate,
                    Name = u.Name,
                    PhoneNumber = u.PhoneNumber
                }).Single();
        }

        public void EditUserInfo(string email, EditUserInfoViewModel info)
        {
            User user = GetUserByEmail(email);

            user.BirthDate = info.BirthDate;
            user.NCode = info.NCode;
            user.Name = info.Name;
            user.PhoneNumber = info.PhoneNumber;

            UpdateUser(user);
        }

        public bool CompareOldPassword(string email, string oldPass)
        {
            string hashedOldPass = PasswordHasher.EncodePasswordMd5(oldPass);
            return _context.Users.Any(u => u.Email == email && u.Password == hashedOldPass);
        }

        public void ChangePassword(string email, string newPass)
        {
            User user = GetUserByEmail(email);

            user.Password = PasswordHasher.EncodePasswordMd5(newPass);

            UpdateUser(user);
        }

        public UsersForAdminViewModel GetAllUsers(int pageId = 1, string filterName = "", string filterNCode = "")
        {
            IQueryable<User> result = _context.Users;

            if (!string.IsNullOrEmpty(filterName))
            {
                result = result.Where(u => u.Name.Contains(filterName));
            }

            if (!string.IsNullOrEmpty(filterNCode))
            {
                result = result.Where(u => u.NCode.Contains(filterNCode));
            }

            // Paging
            int take = Pagings.TakeUserInAdmin;
            int skip = (pageId - 1) * take;

            UsersForAdminViewModel users = new UsersForAdminViewModel()
            {
                CurrentPage = pageId,
                TotalPages = (int)Math.Ceiling((decimal)result.Count() / take),
                Users = result.OrderBy(u => u.Name).Skip(skip).Take(take).ToList()
            };

            return users;
        }

        public int AddUserFromAdmin(CreateUserViewModel user)
        {
            User mUser = new User()
            {
                Name = user.Name,
                NCode = user.NCode,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                BirthDate = user.BirthDate,
                IsActive = true,
                Password = PasswordHasher.EncodePasswordMd5(user.Password),
                ActivationCode = CodeGenerator.GenerateUniqCode(),
                RegisterDate = DateTime.Now
            };

            return AddUser(mUser);
        }

        public EditUserViewModel GetUserForEditInAdmin(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId).Select(u => new EditUserViewModel()
            {
                UserId = u.UserId,
                BirthDate = u.BirthDate,
                Email = u.Email,
                NCode = u.NCode,
                Name = u.Name,
                PhoneNumber = u.PhoneNumber,
                UserRoles = u.UserRoles.Select(r => r.RoleId).ToList()
            }).Single();
        }

        public User GetUserByUserId(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void EditUserFromAdmin(EditUserViewModel editUser)
        {
            User user = GetUserByUserId(editUser.UserId);

            user.BirthDate = editUser.BirthDate;
            user.NCode = editUser.NCode;
            if (!string.IsNullOrEmpty(editUser.Password))
            {
                user.Password = PasswordHasher.EncodePasswordMd5(editUser.Password);
            }
            user.PhoneNumber = editUser.PhoneNumber;

            UpdateUser(user);
        }

        public DeleteUserViewModel GetUserForDeleteInAdmin(int userId)
        {
            return _context.Users.Where(u=>u.UserId == userId).Select(u=> new DeleteUserViewModel()
            {
                UserId = u.UserId,
                Name = u.Name,
                NCode = u.NCode
            }).Single();
        }

        public void DeleteUserFromAdmin(int userId)
        {
            var user = GetUserByUserId(userId);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
