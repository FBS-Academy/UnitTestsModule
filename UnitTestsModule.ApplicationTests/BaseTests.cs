using AutoFixture;

namespace UnitTestsModule.ApplicationTests
{
    public class BaseTests
    {
        protected readonly Fixture fixture;

        public BaseTests()
        {
            this.fixture = new Fixture();
        }
    }
}
