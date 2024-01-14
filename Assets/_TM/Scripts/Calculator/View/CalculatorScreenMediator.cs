using System.Collections.Generic;
using com.calculator.model;
using PureMVC.Interfaces;

namespace com.calculator.view
{
    public class CalculatorScreenMediator : BaseMediator
    {
        private const string Name = "CalculatorScreenMediator";

        private CalculatorProxy _calculatorProxy;
        private CalculatorScreen view => (CalculatorScreen) ViewComponent;

        public CalculatorScreenMediator(CalculatorScreen screen) : base(Name, screen)
        {
            RegisterListener(view.onValue1Changed, ChangeValue1);
            RegisterListener(view.onValue2Changed, ChangeValue2);
            RegisterListener(view.onPlusBtnChanged, value => UpdateState(1));
            RegisterListener(view.onMinusBtnChanged, value => UpdateState(2));
            RegisterListener(view.onMultiplyBtnChanged, value => UpdateState(4));
            RegisterListener(view.onDivideBtnChanged, value => UpdateState(8));
        }

        public override void OnRegister()
        {
            _calculatorProxy = Facade.RetrieveProxy(CalculatorProxy.NAME) as CalculatorProxy;
        }

        private void UpdateState(int state)
        {
            _calculatorProxy.SetButtonsState(state);
        }

        private void ChangeValue1(string value)
        {
            _calculatorProxy.SetValue1(value);
        }

        private void ChangeValue2(string value)
        {
            _calculatorProxy.SetValue2(value);
        }

        public override IList<string> ListNotificationInterests()
        {
            var events = base.ListNotificationInterests();
            events.Add(Events.UpdateButtons);
            events.Add(Events.UpdateResult);
            return events;
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case Events.UpdateButtons:
                    view.UpdateButtons(_calculatorProxy.GetButtonsState());
                    break;

                case Events.UpdateResult:
                    view.UpdateResult(_calculatorProxy.GetResult());
                    break;
            }
        }
    }
}