using System.Globalization;

namespace com.calculator
{
    public class CalculationResult : IResult
    {
        public string value => _value.ToString(CultureInfo.InvariantCulture);

        private readonly decimal _value;

        public CalculationResult(decimal value)
        {
            _value = value;
        }
    }
}