using Contellect_Task.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contellect_Task.Configurations;

public class ContactNoteConfiguration : IEntityTypeConfiguration<ContactNote>
{
    public void Configure(EntityTypeBuilder<ContactNote> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder
            .Property(at => at.Note)
            .HasMaxLength((int)Globals.StringLength.CommentLength)
            .IsRequired(true);


        builder.HasOne(x => x.Contact)
               .WithMany(x => x.Notes)
               .HasForeignKey(x => x.ContactId);
    }
}

