using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_DAL.Data.Configurations
{
    public class InitialInterlocutors : IEntityTypeConfiguration<Interlocutor>
    {
        public void Configure(EntityTypeBuilder<Interlocutor> builder)
        {
            builder.HasData
            (
                new Interlocutor
                {
                    Id = new("aa98af7a-45f0-4ad0-b0af-9594512a8481"),
                    FirstName = "Mohamed",
                    LastName = "MOUSSA",
                    AddedBy = new("021ca3c1-0deb-4afd-ae94-2159a8479811")
                },
                new Interlocutor
                {
                    Id = new("11bbfec4-f7f0-4fa0-8289-0dd682eb31df"),
                    FirstName = "Jamal",
                    LastName = "SALAHEDDINE",
                    AddedBy = new("021ca3c1-0deb-4afd-ae94-2159a8479811")
                },
                new Interlocutor
                {
                    Id = new("de194360-4865-4a95-a8fe-a28fc4168643"),
                    FirstName = "Aziz",
                    LastName = "KHALLADI",
                    AddedBy = new("021ca3c1-0deb-4afd-ae94-2159a8479811")
                },
                new Interlocutor
                {
                    Id = new("0583dc04-8226-4347-a2c8-c72da3f1ff8b"),
                    FirstName = "Taoufik",
                    LastName = "AZARUAL",
                    AddedBy = new("021ca3c1-0deb-4afd-ae94-2159a8479811")
                },
                new Interlocutor
                {
                    Id = new("7c09511c-dd8d-423e-9f6a-5cb458e1da53"),
                    FirstName = "Sarah",
                    LastName = "LAMRANI",
                    AddedBy = new("021ca3c1-0deb-4afd-ae94-2159a8479811")
                }
            );
        }
    }
}
