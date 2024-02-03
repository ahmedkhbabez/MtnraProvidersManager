using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_DAL.Data.Configurations
{
    public class MockUsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User
                {
                    Id = new("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    FirstName = "Mock",
                    LastName = "Admin",
                    Username = "admin",
                    HashedPassword = "$2a$12$N1WBrH9z10xi1OSrcgvG..3xMyWIMgaaO.f6CcC.r33Nhzn4Mm4ve",  // Password is: 123456
                    Role = "Admin",
                    AddedBy = null
                },
                new User
                {
                    Id = new("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    FirstName = "Mock",
                    LastName = "Moderator",
                    Username = "user",
                    HashedPassword = "$2a$12$G5zksm0jpyy63xRlG3NACuACiwJ13cX3uROX4UKrmVWI9lA4ZF60O",  // Password is: 123456
                    Role = "Moderator",
                    AddedBy = new("021ca3c1-0deb-4afd-ae94-2159a8479811")
                }
            );
        }
    }
}
