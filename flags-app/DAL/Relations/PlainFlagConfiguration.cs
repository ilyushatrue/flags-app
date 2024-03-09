using DAL.Models.Flags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Relations;

internal class PlainFlagConfiguration : IEntityTypeConfiguration<PlainFlag>
{
    public void Configure(EntityTypeBuilder<PlainFlag> builder)
    {
        builder
            .HasOne(f=>f.Country)
            .WithOne(c=>c.PlFlag)
            .

    }
}
