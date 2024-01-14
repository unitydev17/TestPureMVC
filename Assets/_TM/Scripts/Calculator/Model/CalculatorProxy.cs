using System;
using PureMVC.Patterns;

namespace com.calculator.model
{
    public class CalculatorProxy : Proxy
    {
        private CalculatorBo _bo;


        public override void OnRegister()
        {
            _bo = new CalculatorBo(0, 0, 1);
            UpdateButtonsState();
        }

        public void SetValue1(string value)
        {
            try
            {
                _bo.value1 = decimal.Parse(value);
            }
            catch (Exception)
            {
                _bo.value1 = 0;
            }

            CountResult();
        }

        public void SetValue2(string value)
        {
            try
            {
                _bo.value2 = decimal.Parse(value);
            }
            catch (Exception)
            {
                _bo.value1 = 0;
            }

            CountResult();
        }

        public void SetButtonsState(int state)
        {
            _bo.buttonsState = state;
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            SendNotification(Events.UpdateButtons);
            CountResult();
        }

        private void CountResult()
        {
            var buttons = _bo.buttonsBo;

            try
            {
                if (buttons.plusPushed) _bo.result = new CalculationResult(_bo.value1 + _bo.value2);
                else if (buttons.minusPushed) _bo.result = new CalculationResult(_bo.value1 - _bo.value2);
                else if (buttons.multiplyPushed) _bo.result = new CalculationResult(_bo.value1 * _bo.value2);
                else if (buttons.dividePushed) _bo.result = new CalculationResult(_bo.value1 / _bo.value2);
                else _bo.result = new EmptyResult();
            }
            catch (Exception e)
            {
                _bo.result = e switch
                {
                    OverflowException _ => new ErrorResult(Constants.Overflow),
                    DivideByZeroException _ => new ErrorResult(Constants.DivisionByZeroNotSupported),
                    _ => new ErrorResult(Constants.NotDefined)
                };
            }

            SendNotification(Events.UpdateResult);
        }

        public int GetButtonsState()
        {
            return _bo.buttonsState;
        }

        public IResult GetResult()
        {
            return _bo.result;
        }
    }
}