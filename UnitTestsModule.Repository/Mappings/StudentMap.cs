using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnitTestsModule.Domain;

namespace UnitTestsModule.Repository.Mappings
{
    public class StudentMap : BaseEntityMap<Student>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Student> builder)
        {
            builder.Property(student => student.Name).IsRequired(true);
        }
    }
}
