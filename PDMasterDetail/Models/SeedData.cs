using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace RazorPagesMovie.Models;

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
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.RockClass.Any())
            {
                return;   // DB has been seeded
            }

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
                    Location = "Found everywhere, but mainly mountainous areas",
                    Hardness = 7
                },
                new RockClass
                {
                    Name = "Quartz",
                    Type = "Sedimentary and Igneous",
                    Color = "White",
                    Location = "Found everywhere, but Arkansas has the largest deposits",
                    Hardness = 7
                },
                new RockClass
                {
                    Name = "Talc",
                    Type = "Metamorphic",
                    Color = "White, Green, Grey, Brown",
                    Location = "Found mainly in southeastern United States",
                    Hardness = 1
                }
            );
            context.SaveChanges();
        }
    }
}
