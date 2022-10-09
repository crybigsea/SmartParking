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
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        public DbSet<SysUserInfo> SysUserInfos { get; set; }

        public DbSet<SysMenu> SysMenus { get; set; }

        #region Entities from the modules

        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */

        #endregion

        public SmartParkingDbContext(DbContextOptions<SmartParkingDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigureAuditLogging();

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(SmartParkingConsts.DbTablePrefix + "YourEntities", SmartParkingConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
            builder.Entity<SysUserInfo>(b => b.Property(p => p.State).HasDefaultValue(1));
            builder.Entity<SysMenu>(b => b.Property(p => p.State).HasDefaultValue(1));
            builder.Entity<SysMenu>().Property(p => p.MenuIcon).HasConversion(new ValueConverter<string, string>(
                v => string.IsNullOrEmpty(v) ? null : ((int)v.ToArray()[0]).ToString("x"),
                v => string.IsNullOrEmpty(v) ? "" : ((char)int.Parse(v, NumberStyles.HexNumber)).ToString()
            ));
        }
    }
}
