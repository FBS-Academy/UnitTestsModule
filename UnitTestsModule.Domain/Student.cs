namespace UnitTestsModule.Domain
{
    public class Student : BaseEntity
    {
        public Student(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
