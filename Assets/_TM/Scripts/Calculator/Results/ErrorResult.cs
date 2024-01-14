namespace com.calculator
{
    public class ErrorResult : IResult
    {
        private readonly string _errorMessage;

        public string errorMessage => _errorMessage ?? "";

        public ErrorResult(string errorMessage)
        {
            _errorMessage = errorMessage;
        }
    }
}