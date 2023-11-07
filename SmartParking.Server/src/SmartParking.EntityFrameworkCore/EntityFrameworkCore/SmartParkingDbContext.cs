using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartParking.Entitys;
using System.Globalization;
using System.Linq;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SmartParking.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class SmartParkingDbContext : AbpDbContext<SmartParkingDbContext>
    {
        public DbSet<SysUserInfo> SysUserInfos { get; set; }

        public DbSet<SysMenu> SysMenus { get; set; }

        public DbSet<SysRole> SysRoles { get; set; }

        public DbSet<SysRoleMenu> SysRoleMenus { get; set; }

        public DbSet<SysUserMenu> SysUserMenus { get; set; }

        public DbSet<SysUpdateFile> SysUpdateFiles { get; set; }

        public SmartParkingDbContext(DbContextOptions<SmartParkingDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAuditLogging();

            builder.Entity<SysUserInfo>(b => b.Property(p => p.State).HasDefaultValue(1));
            builder.Entity<SysMenu>(b => b.Property(p => p.State).HasDefaultValue(1));
            builder.Entity<SysRole>(b => b.Property(p => p.State).HasDefaultValue(1));
            builder.Entity<SysMenu>().Property(p => p.MenuIcon).HasConversion(new ValueConverter<string, string>(
                v => string.IsNullOrEmpty(v) ? null : ((int)v.ToArray()[0]).ToString("x"),
                v => string.IsNullOrEmpty(v) ? "" : ((char)int.Parse(v, NumberStyles.HexNumber)).ToString()
            ));
        }
    }
}
