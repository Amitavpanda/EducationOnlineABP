using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Acme.OnlineEducation.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class OnlineEducationDbContext :
    AbpDbContext<OnlineEducationDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */


    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    
    
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<SessionDetail> SessionDetails { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<CourseCategory> CourseCategories { get; set; }


    public OnlineEducationDbContext(DbContextOptions<OnlineEducationDbContext> options)
        : base(options)
    {
        

    }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(OnlineEducationConsts.DbTablePrefix + "YourEntities", OnlineEducationConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<CourseCategory>(b =>
        {
            b.ToTable("CourseCategory"); // Maps to the "CourseCategory" table
            b.ConfigureByConvention(); // Configures base properties by convention
            b.Property(x => x.CategoryName).IsRequired().HasMaxLength(50);
            b.Property(x => x.Description).HasMaxLength(250);
        });
        
        builder.Entity<Course>(b =>
        {
            b.ToTable("Courses");
            b.ConfigureByConvention(); // Configures base class properties
            b.Property(x => x.Title).IsRequired().HasMaxLength(128);
            b.Property(x => x.Description).HasMaxLength(500);
            b.Property(x => x.Price).HasColumnType("decimal(18, 2)");
            b.Property(x => x.CourseType).HasMaxLength(50);
            b.Property(x => x.Thumbnail);
        });
        
        builder.Entity<Enrollment>(b =>
        {
            b.ToTable("Enrollments");
            b.ConfigureByConvention();
            b.Property(x => x.PaymentStatus).IsRequired().HasMaxLength(20);
        });
       
        builder.Entity<Instructor>(b =>
        {
            b.ToTable("Instructors");
            b.ConfigureByConvention();
            b.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            b.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            b.Property(x => x.Email);
            b.Property(x => x.Bio);
        });

        builder.Entity<Payment>(b =>
        {
            b.ToTable("Payments");
            b.ConfigureByConvention();
            b.Property(x => x.Amount).HasColumnType("decimal(18, 2)");
            b.Property(x => x.PaymentMethod).IsRequired().HasMaxLength(50);
            b.Property(x => x.PaymentStatus).IsRequired().HasMaxLength(20);
        });

        builder.Entity<Review>(b =>
        {
            b.ToTable("Reviews");
            b.ConfigureByConvention();
            b.Property(x => x.Comments).HasMaxLength(500);
        });
        
        builder.Entity<SessionDetail>(b =>
        {
            b.ToTable("SessionDetails");
            b.ConfigureByConvention();
            b.Property(x => x.Title).IsRequired().HasMaxLength(128);
            b.Property(x => x.Description).HasMaxLength(500);
            b.Property(x => x.VideoUrl).IsRequired().HasMaxLength(200);
        });
        
        builder.Entity<UserProfile>(b =>
        {
            b.ToTable("UserProfiles");
            b.ConfigureByConvention();
            b.Property(x => x.DisplayName).IsRequired().HasMaxLength(100);
            b.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            b.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            b.Property(x => x.ProfilePictureUrl).HasMaxLength(200);
        });
    }
}
