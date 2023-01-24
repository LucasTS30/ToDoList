using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Models;

namespace ToDoList.EntityConfigs;

public class ToDoEntityConfig : IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        builder.ToTable("ToDo");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("Id");

        builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("NVARCHAR(150)").IsRequired();

        builder.Property(x => x.Date).HasColumnName("Date").HasColumnType("DATE").IsRequired();

        builder.Property(x => x.IsCompleted).HasColumnName("IsCompleted").HasColumnType("BIT");
    }
}