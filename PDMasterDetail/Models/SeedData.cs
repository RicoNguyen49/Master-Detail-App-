using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;
using System;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PDMasterDetailContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PDMasterDetailContext>>()))
            {
                if (context == null || context.RockClass == null)
                {
                    throw new ArgumentNullException("Null PDMasterDetailContext");
                }

                // Check if the database has been seeded.
                if (context.RockClass.Any())
                {
                    return;   // DB has been seeded
                }

                // Seed data
                context.RockClass.AddRange(
                    new RockClass
                    {
                        Name = "Onyx",
                        Type = "Metamorphic",
                        Color = "Black",
                        Location = "Found mainly in North and South Americas",
                        Hardness = 7
                    },
                    new RockClass
                    {
                        Name = "Granite",
                        Type = "Igneous",
                        Color = "Red, White, Brown, Black",
                        Location = "Found everywhere, but mainly in mountainous areas",
                        Hardness = 7
                    },
                    new RockClass
                    {
                        Name = "Quartz",
                        Type = "Sedimentary and Igneous",
                        Color = "Clear to White",
                        Location = "Found everywhere, especially in Arkansas",
                        Hardness = 7
                    },
                    new RockClass
                    {
                        Name = "Talc",
                        Type = "Metamorphic",
                        Color = "White, Green, Grey, Brown",
                        Location = "Found mainly in southeastern United States",
                        Hardness = 1
                    },
                    new RockClass
                    {
                        Name = "Basalt",
                        Type = "Igneous",
                        Color = "Black",
                        Location = "Found in oceanic crust and volcanic islands",
                        Hardness = 6
                    },
                    new RockClass
                    {
                        Name = "Marble",
                        Type = "Metamorphic",
                        Color = "White, Gray, Pink, Green",
                        Location = "Commonly found in mountainous regions",
                        Hardness = 3
                    },
                    new RockClass
                    {
                        Name = "Sandstone",
                        Type = "Sedimentary",
                        Color = "Tan, Brown, Red",
                        Location = "Commonly found in deserts and riverbeds",
                        Hardness = 6
                    },
                    new RockClass
                    {
                        Name = "Limestone",
                        Type = "Sedimentary",
                        Color = "Light Gray, Cream",
                        Location = "Commonly found in marine environments",
                        Hardness = 4
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
