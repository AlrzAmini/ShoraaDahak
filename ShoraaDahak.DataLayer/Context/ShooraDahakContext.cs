using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoraaDahak.DataLayer.Models.Blog;
using ShoraaDahak.DataLayer.Models.Discussion;
using ShoraaDahak.DataLayer.Models.Letter;
using ShoraaDahak.DataLayer.Models.Permission;
using ShoraaDahak.DataLayer.Models.quote;
using ShoraaDahak.DataLayer.Models.ReportAbuse;
using ShoraaDahak.DataLayer.Models.Services;
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

        #region Permissions

        public DbSet<Permission> Permission { get; set; }

        public DbSet<RolePermission> RolePermission { get; set; }


        #endregion

        #region Service

        public DbSet<ServiceGroup> ServiceGroups { get; set; }

        public DbSet<ServiceStatus> ServiceStatus { get; set; }

        public DbSet<Service> Service { get; set; }

        #endregion

        #region Discussion

        public DbSet<Discussion> Discussions { get; set; }

        public DbSet<DiscussionImpLevel> DiscussionImpLevels { get; set; }

        public DbSet<Answer> Answers { get; set; }

        #endregion

        #region Letter

        public DbSet<Letter> Letters { get; set; }

        public DbSet<LetterTo> LetterTos { get; set; }

        public DbSet<LetterAnswer> LetterAnswers { get; set; }

        #endregion

        #region Quote

        public DbSet<Quote> Quotes { get; set; }

        #endregion

        #region Blogs

        public DbSet<BlogCategory> BlogCategories { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<CommentAnswer> CommentAnswers { get; set; }


        #endregion

        #region Report Abuse

        public DbSet<ReportAbuse> ReportAbuses { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogCategory>()
                .HasQueryFilter(c => !c.IsDelete);

            modelBuilder.Entity<Comment>()
                .HasQueryFilter(c => !c.IsDelete);

            modelBuilder.Entity<CommentAnswer>()
                .HasQueryFilter(c => !c.IsDelete);

            base.OnModelCreating(modelBuilder);
        }
    }
}
