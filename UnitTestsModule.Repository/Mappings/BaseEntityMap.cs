using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnitTestsModule.Domain;

namespace UnitTestsModule.Repository.Mappings
{
    public abstract class BaseEntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
       where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CreatedDate);
            builder.Property(p => p.LastUpdatedDate);
            ConfigureEntity(builder);
        }

        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    }
}
