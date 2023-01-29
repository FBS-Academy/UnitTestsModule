namespace UnitTestsModule.Domain.Exceptions
{
    public class ErrorMessage
    {
        public ErrorMessage(string property, string message)
        {
            this.Property = property;
            this.Message = message;
        }

        public string Property { get; set; }
        public string Message { get; set; }
    }
}
