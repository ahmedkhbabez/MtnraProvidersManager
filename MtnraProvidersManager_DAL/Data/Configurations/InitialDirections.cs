using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_DAL.Data.Configurations
{
    public class InitialDirections : IEntityTypeConfiguration<Direction>
    {
        public void Configure(EntityTypeBuilder<Direction> builder)
        {
            builder.HasData
            (

                new Direction
                {
                    Id = Guid.NewGuid(),
                    Abbreviation = "DSI",
                    ExtendedName = "Direction des Systèmes d'Information",
                    InterlocutorId = new("aa98af7a-45f0-4ad0-b0af-9594512a8481"),
                    AddedBy = new("021ca3c1-0deb-4afd-ae94-2159a8479811")
                },
                new Direction
                {
                    Id = Guid.NewGuid(),
                    Abbreviation = "DMA",
                    ExtendedName = "Direction de la Modernisation de l'Administration",
                    InterlocutorId = new("11bbfec4-f7f0-4fa0-8289-0dd682eb31df"),
                    AddedBy = new("021ca3c1-0deb-4afd-ae94-2159a8479811")
                    
                },
                new Direction
                {
                    Id = Guid.NewGuid(),
                    Abbreviation = "DRHF",
                    ExtendedName = "Direction des Ressources Humaines et Financières",
                    InterlocutorId = new("de194360-4865-4a95-a8fe-a28fc4168643"),
                    AddedBy = new("021ca3c1-0deb-4afd-ae94-2159a8479811")
                },
                new Direction
                {
                    Id = Guid.NewGuid(),
                    Abbreviation = "DFP",
                    ExtendedName = "Direction de la Fonction Publique",
                    InterlocutorId = new("0583dc04-8226-4347-a2c8-c72da3f1ff8b"),
                    AddedBy = new("021ca3c1-0deb-4afd-ae94-2159a8479811")
                },
                new Direction
                {
                    Id = Guid.NewGuid(),
                    Abbreviation = "DECC",
                    ExtendedName = "Direction des Études, de la Communication et de la Coopération",
                    InterlocutorId = new("7c09511c-dd8d-423e-9f6a-5cb458e1da53"),
                    AddedBy = new("021ca3c1-0deb-4afd-ae94-2159a8479811")
                }
            );
        }
    }
}
