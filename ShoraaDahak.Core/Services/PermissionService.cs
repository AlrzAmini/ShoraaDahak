using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoraaDahak.Core.Services.Interfaces;
using ShoraaDahak.DataLayer.Context;
using ShoraaDahak.DataLayer.Models.Permission;
using ShoraaDahak.DataLayer.Models.User;

namespace ShoraaDahak.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly ShooraDahakContext _context;

        public PermissionService(ShooraDahakContext context)
        {
            _context = context;
        }

        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public void AddRolesToUser(List<int> roleIds, int userId)
        {
            foreach (int roleId in roleIds)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });

            }

            _context.SaveChanges();
        }

        public void EditRolesUser(List<int> rolesId, int userId)
        {

            #region Delete User Roles

            _context.UserRoles.Where(u => u.UserId == userId).ToList().ForEach(r => _context.UserRoles.Remove(r));

            #endregion

            #region Add New Roles

            AddRolesToUser(rolesId, userId);

            #endregion

            _context.SaveChanges();
        }

        public int AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();

            return role.RoleId;
        }

        public Role GetRoleByRoleId(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public void UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public void DeleteRole(Role role)
        {
            _context.Roles.Remove(role);
            _context.SaveChanges();
        }

        public List<Permission> GetAllPermissions()
        {
            return _context.Permission.ToList();
        }

        public void AddPermissionsToRole(int roleId, List<int> permission)
        {
            foreach (var item in permission)
            {
                _context.RolePermission.Add(new RolePermission()
                {
                    PermissionId = item,
                    RoleId = roleId
                });
            }

            _context.SaveChanges();
        }

        public List<int> PermissionsRole(int roleId)
        {
            return _context.RolePermission
                .Where(r => r.RoleId == roleId)
                .Select(r => r.PermissionId).ToList();
        }

        public void EditPermissionsRole(int roleId, List<int> permissions)
        {
            _context.RolePermission.Where(p => p.RoleId == roleId)
                .ToList().ForEach(p => _context.RolePermission.Remove(p));

            AddPermissionsToRole(roleId, permissions);
        }

        public int GetUserIdByEmail(string email)
        {
            return _context.Users.Single(u => u.Email == email).UserId;
        }

        public bool CheckPermission(int permissionId, string email)
        {
            int userId = GetUserIdByEmail(email);

            // this(username is in input) user roles
            List<int> UserRoles = _context.UserRoles
                .Where(r => r.UserId == userId)
                .Select(r => r.RoleId)
                .ToList();

            if (!UserRoles.Any())
            {
                return false;
            }

            // this permissions role
            List<int> RolesPermission = _context.RolePermission
                .Where(p => p.PermissionId == permissionId)
                .Select(p => p.RoleId)
                .ToList();

            return RolesPermission.Any(p => UserRoles.Contains(p));
        }


    }
}
