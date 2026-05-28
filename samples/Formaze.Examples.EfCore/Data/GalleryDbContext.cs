using Formaze.Blazor.Mudblazor.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Formaze.Examples.EfCore.Data;

public class GalleryDbContext(DbContextOptions<GalleryDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Registers the FormazeConfigs table used to persist form definitions.
        modelBuilder.UseFormaze();
    }
}
