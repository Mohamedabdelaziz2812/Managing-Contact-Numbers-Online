using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contellect_Task.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder
            .Property(at => at.Name)
            .HasMaxLength((int)Globals.StringLength.ShortName)
            .IsRequired(true);

        builder
            .Property(at => at.Address)
            .HasMaxLength((int)Globals.StringLength.AddressLength)
            .IsRequired(true);


        builder
            .Property(at => at.Phone)
            .HasMaxLength((int)Globals.StringLength.phoneLength)
            .IsRequired(true);


        builder
            .Property(at => at.Name)
            .HasMaxLength((int)Globals.StringLength.ShortName)
            .IsRequired(true);

    }
}

