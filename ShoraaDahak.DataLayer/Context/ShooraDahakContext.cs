using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoraaDahak.DataLayer.Models.User;

namespace ShoraaDahak.DataLayer.Context
{
    public class ShooraDahakContext : DbContext
    {
        public ShooraDahakContext(DbContextOptions<ShooraDahakContext> option) : base(option)
        {

        }

        #region User

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        #endregion
    }
}
