using CompanyName.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanyName.Entities.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //This is an example table that is called Article
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(i =>
            {
                i.ToTable("AppUser");
                i.HasKey(x => x.Id);
            });

            builder.Entity<IdentityRole<int>>(i =>
            {
                i.ToTable("Role");
                i.HasKey(x => x.Id);
            });

            builder.Entity<IdentityUserRole<int>>(i =>
            {
                i.ToTable("UserRole");
                i.HasKey(x => new { x.RoleId, x.UserId });
            });

            builder.Entity<IdentityUserLogin<int>>(i =>
            {
                i.ToTable("UserLogin");
                i.HasKey(x => new { x.ProviderKey, x.LoginProvider });
            });
            builder.Entity<IdentityRoleClaim<int>>(i =>
            {
                i.ToTable("UserRoleClaim");
                i.HasKey(x => x.Id);
            });
            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserToken");
            });
            builder.Entity<IdentityUserClaim<int>>(i =>
            {
                i.ToTable("UserClaim");
                i.HasKey(x => x.Id);
            });
        }
    }
}
