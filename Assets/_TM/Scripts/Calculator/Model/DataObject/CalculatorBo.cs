namespace com.calculator.model
{
    public class CalculatorBo
    {
        public decimal value1;
        public decimal value2;
        public IResult result;

        private int _buttonState;

        public int buttonsState
        {
            set
            {
                _buttonState = value;
                if (buttonsBo == null)
                {
                    buttonsBo = new ButtonsBo(_buttonState);
                }

                buttonsBo.Set(_buttonState);
            }
            get => _buttonState;
        }

        public ButtonsBo buttonsBo;

        public CalculatorBo(int value1, int value2, int buttonsState)
        {
            this.buttonsState = buttonsState;
            this.value1 = value1;
            this.value2 = value2;
            result = new EmptyResult();
        }
    }
}