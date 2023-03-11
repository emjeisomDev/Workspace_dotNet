using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using todo.Models;

namespace todo.Data.Mappings
{
    public class TodoMap : IEntityTypeConfiguration<TodoModel>
    {
        public void Configure(EntityTypeBuilder<TodoModel> builder)
        {
            //Tabela
            builder.ToTable("Todos");

            //Primary Key
            builder.HasKey(x => x.Id);

            //Identity
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            //Properties
            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder
                .Property(x => x.Description)
                .IsRequired(false)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            builder
                .Property(x => x.Done)
                .IsRequired()
                .HasColumnName("Done")
                .HasColumnType("BIT");

            builder
                .Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("DATETIME");

            builder
                .Property(x => x.UpdatedAt)
                .IsRequired()
                .HasColumnName("UpdatedAt")
                .HasColumnType("DATETIME");

        }
    }
}
