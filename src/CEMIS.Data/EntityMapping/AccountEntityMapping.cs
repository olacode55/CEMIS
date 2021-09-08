using CEMIS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CEMIS.Data.EntityMapping
{
    //public class CoreUserEntityMapping
    //{
    //    public CoreUserEntityMapping(EntityTypeBuilder<TCoreUser> entity)
    //    {
    //        entity.HasKey(e => e.UserId);

    //        entity.ToTable("t_core_user");

    //        entity.Property(e => e.UserId).HasColumnName("user_id");

    //        entity.Property(e => e.AppuserId)
    //            .HasColumnName("appuser_id")
    //            .HasMaxLength(450);

    //        entity.Property(e => e.CreatedBy)
    //            .IsRequired()
    //            .HasColumnName("created_by")
    //            .HasMaxLength(255);

    //        entity.Property(e => e.CreatedDate)
    //            .HasColumnName("created_date")
    //            .HasColumnType("datetime");

    //        entity.Property(e => e.Firstname)
    //            .HasColumnName("firstname")
    //            .HasMaxLength(255);

    //        entity.Property(e => e.IsActive)
    //            .IsRequired()
    //            .HasColumnName("is_active")
    //            .HasDefaultValueSql("((1))");

    //        entity.Property(e => e.LastModified)
    //            .HasColumnName("last_modified")
    //            .HasColumnType("datetime");

    //        entity.Property(e => e.Lastname)
    //            .HasColumnName("lastname")
    //            .HasMaxLength(255);

    //        entity.Property(e => e.Middlename)
    //            .HasColumnName("middlename")
    //            .HasMaxLength(255);

    //        entity.Property(e => e.ModifiedBy)
    //            .HasColumnName("modified_by")
    //            .HasMaxLength(255);

    //        entity.Property(e => e.Nationality).HasColumnName("nationality");

    //        entity.Property(e => e.UserCategory)
    //            .IsRequired()
    //            .HasColumnName("user_category")
    //            .HasMaxLength(1);

    //        entity.HasOne(d => d.Appuser)
    //            .WithMany(p => p.TCoreUser)
    //            .HasForeignKey(d => d.AppuserId)
    //            .HasConstraintName("fk1_core_user");

    //        entity.HasOne(d => d.NationalityNavigation)
    //            .WithMany(p => p.TCoreUser)
    //            .HasForeignKey(d => d.Nationality)
    //            .HasConstraintName("fk2_core_user");
    //    }
    //}
   
    
    public class UserLoginHistoryEntityMapping
    {
        public UserLoginHistoryEntityMapping(EntityTypeBuilder<UserLoginHistory> entity)
        {
            entity.HasKey(e => e.Id)
                        .HasName("Id");

            entity.ToTable("bt_user_login_history");

            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.Browser)
                .HasColumnName("browser")
                .HasMaxLength(50);

            entity.Property(e => e.IpAddress)
                .IsRequired()
                .HasColumnName("ip_address")
                .HasMaxLength(50);

            entity.Property(e => e.Operation)
                .IsRequired()
                .HasColumnName("operation")
                .HasMaxLength(50);

            entity.Property(e => e.SessionDate)
                .HasColumnName("session_date")
                .HasColumnType("datetime");

            entity.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("user_id")
                .HasMaxLength(450);
        }
    }
    public class UsersEntityMapping
    {
        public UsersEntityMapping(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("bt_user");

            entity.Property(e => e.Id).HasColumnName("user_id");

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("created_by")
                .HasMaxLength(255);

            entity.Property(e => e.DateCreated)
                .HasColumnName("DateCreated")
                .HasColumnType("datetime");

            entity.Property(e => e.Email).HasMaxLength(256);
          

            entity.Property(e => e.ForcePwdChange).HasColumnName("force_pwd_change");

            entity.Property(e => e.LastLoginDate).HasColumnName("last_login_date");

            entity.Property(e => e.ModifiedBy)
                .HasColumnName("ModifiedBy")
                .HasMaxLength(255);

            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            entity.Property(e => e.PwdChangedDate)
                .HasColumnName("pwd_changed_date")
                .HasColumnType("datetime");

            entity.Property(e => e.PwdExpiryDate)
                .HasColumnName("pwd_expiry_date")
                .HasColumnType("datetime");

            entity.Property(e => e.UserName).HasMaxLength(256);
        }
    }
    //public class UserPermissionMapping
    //{
    //    public UserPermissionMapping(EntityTypeBuilder<BtPermissions> entity)
    //    {
    //        entity.HasKey(e => e.PermissionId);

    //        entity.ToTable("t_gnsys_permissions");

    //        entity.HasIndex(e => e.MerchantId)
    //            .HasName("uq1_gnsys_permissions")
    //            .IsUnique();

    //        entity.Property(e => e.PermissionId)
    //            .HasColumnName("permission_id")
    //            .ValueGeneratedNever();

    //        entity.Property(e => e.CreatedBy)
    //            .HasColumnName("created_by")
    //            .HasMaxLength(255);

    //        entity.Property(e => e.CreatedDate)
    //            .HasColumnName("created_date")
    //            .HasColumnType("datetime");

    //        entity.Property(e => e.IsActive).HasColumnName("is_active");

    //        entity.Property(e => e.LastModified)
    //            .HasColumnName("last_modified")
    //            .HasColumnType("datetime");

    //        entity.Property(e => e.MerchantId).HasColumnName("merchant_id");

    //        entity.Property(e => e.MerchantPermissions)
    //            .IsRequired()
    //            .HasColumnName("merchant_permissions");

    //        entity.Property(e => e.ModifiedBy)
    //            .HasColumnName("modified_by")
    //            .HasMaxLength(255);

    //        entity.HasOne(d => d.Merchant)
    //            .WithOne(p => p.TGnsysPermissions)
    //            .HasForeignKey<TGnsysPermissions>(d => d.MerchantId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("fk1_gnsys_permissions");
    //    }
    //}
    public class UserRoleMapping
    {
        public UserRoleMapping(EntityTypeBuilder<UserRole> entity)
        {
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.Property(e => e.LastModified)
                .HasColumnName("last_modified")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.ModifiedBy)
                .HasColumnName("modified_by")
                .HasMaxLength(255);
        }
    }
    public class UserLoginsEntityMapping
    {
        public UserLoginsEntityMapping(EntityTypeBuilder<UserLogin> entity)
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey,e.UserId });

           // entity.ToTable("bt_user_login");

            entity.Property(e => e.UserId).HasColumnName("user_id");
        }
    }
    //public class TGenesysRolePermissionEntityMapping
    //{
    //    public TGenesysRolePermissionEntityMapping(EntityTypeBuilder<TGnsysRolePermission> entity)
    //    {
    //        entity.HasKey(e => new { e.RoleId, e.PermissionId });

    //        entity.ToTable("t_gnsys_role_permissions");

    //        entity.HasIndex(e => e.PermissionId);

    //        entity.Property(e => e.MerchantId).HasColumnName("merchant_id");

    //        entity.HasOne(d => d.Permission)
    //            .WithMany(p => p.TGnsysRolePermissions)
    //            .HasForeignKey(d => d.PermissionId);

    //        entity.HasOne(d => d.Role)
    //            .WithMany(p => p.TGnsysRolePermissions)
    //            .HasForeignKey(d => d.RoleId);
    //    }
    //}
    public class RolesEntityMapping
    {
        public RolesEntityMapping(EntityTypeBuilder<Role> entity)
        {

            entity.HasKey(e => e.Id);

            entity.ToTable("bt_roles");

            entity.Property(e => e.Id).HasColumnName("role_id");

            entity.Property(e => e.ConcurrencyStamp).HasColumnName("concurrency_stamp");

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("created_by")
                .HasMaxLength(255);

            entity.Property(e => e.CreatedDate)
                .HasColumnName("created_date")
                .HasColumnType("datetime");

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasColumnName("is_active")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.IsSuperUser).HasColumnName("is_super_user");

            entity.Property(e => e.LastModified)
                .HasColumnName("last_modified")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.ModifiedBy)
                .HasColumnName("modified_by")
                .HasMaxLength(255);

            entity.Property(e => e.PermissionsInRole).HasColumnName("permissions_in_role");

            entity.Property(e => e.RoleDesc)
                .HasColumnName("role_desc")
                .HasMaxLength(1024);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("role_name")
                .HasMaxLength(256);

            entity.Property(e => e.NormalizedName)
                .HasColumnName("role_name_normalised")
                .HasMaxLength(256);
        }
    }
    //public class TGnsysUsersPasswordHistEntityMapping
    //{
    //    public TGnsysUsersPasswordHistEntityMapping(EntityTypeBuilder<TGnsysUsersPasswordHist> entity)
    //    {
    //        entity.HasKey(e => e.HistryId)
    //                .HasName("pk_core_users_password_hist");

    //        entity.ToTable("t_gnsys_users_password_hist");

    //        entity.Property(e => e.HistryId)
    //            .HasColumnName("histry_id")
    //            .ValueGeneratedNever();

    //        entity.Property(e => e.CreatedBy)
    //            .IsRequired()
    //            .HasColumnName("created_by")
    //            .HasMaxLength(255);

    //        entity.Property(e => e.CreatedDate)
    //            .HasColumnName("created_date")
    //            .HasColumnType("datetime")
    //            .HasDefaultValueSql("(getdate())");

    //        entity.Property(e => e.EmpId).HasColumnName("emp_id");

    //        entity.Property(e => e.LastModified)
    //            .HasColumnName("last_modified")
    //            .HasColumnType("datetime");

    //        entity.Property(e => e.ModifiedBy)
    //            .HasColumnName("modified_by")
    //            .HasMaxLength(255);

    //        entity.Property(e => e.PwdCount).HasColumnName("pwd_count");

    //        entity.Property(e => e.PwdEncrypt)
    //            .IsRequired()
    //            .HasColumnName("pwd_encrypt");

    //        entity.HasOne(d => d.Emp)
    //            .WithMany(p => p.TGnsysUsersPasswordHist)
    //            .HasForeignKey(d => d.EmpId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("fk1_core_users_password_hist");
    //    }
    //}
    //public class TGnsysUserLoginHistoryEntityMapping
    //{
    //    public TGnsysUserLoginHistoryEntityMapping(EntityTypeBuilder<TGnsysUserLoginHistory> entity)
    //    {
    //        entity.HasKey(e => e.LoginhistId);

    //        entity.ToTable("t_gnsys_user_login_history");

    //        entity.Property(e => e.LoginhistId)
    //            .HasColumnName("loginhist_id")
    //            .ValueGeneratedNever();

    //        entity.Property(e => e.Browser)
    //            .HasColumnName("browser")
    //            .HasMaxLength(50);

    //        entity.Property(e => e.IpAddress)
    //            .IsRequired()
    //            .HasColumnName("ip_address")
    //            .HasMaxLength(50);

    //        entity.Property(e => e.MerchantId).HasColumnName("merchant_id");

    //        entity.Property(e => e.Operation)
    //            .IsRequired()
    //            .HasColumnName("operation")
    //            .HasMaxLength(50);

    //        entity.Property(e => e.SessionDate)
    //            .HasColumnName("session_date")
    //            .HasColumnType("datetime");

    //        entity.Property(e => e.UserId)
    //            .IsRequired()
    //            .HasColumnName("user_id")
    //            .HasMaxLength(450);

    //        entity.HasOne(d => d.Merchant)
    //            .WithMany(p => p.TGnsysUserLoginHistory)
    //            .HasForeignKey(d => d.MerchantId)
    //            .OnDelete(DeleteBehavior.ClientSetNull)
    //            .HasConstraintName("fk1_gnsys_user_login_history");
    //    }
    //}
}
