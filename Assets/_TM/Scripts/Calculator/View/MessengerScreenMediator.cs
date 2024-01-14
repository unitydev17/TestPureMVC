using com.calculator.model;
using com.calculator.utils;

namespace com.calculator.view
{
    public class MessengerScreenMediator : BaseMediator
    {
        private const string Name = "MessengerScreenMediator";

        private MessengerProxy _proxy;

        private MessengerScreen view => (MessengerScreen) ViewComponent;

        public MessengerScreenMediator(MessengerScreen screen) : base(Name, screen)
        {
            RegisterListener(view.onMessageChange, UpdateMessage);
            RegisterListener(view.onButtonClick, value => SendMessage());
        }

        public override void OnRegister()
        {
            _proxy = Facade.RetrieveProxy(MessengerProxy.Name) as MessengerProxy;
        }

        private void UpdateMessage(string value)
        {
            _proxy.message = value;
        }

        private void SendMessage()
        {
            _proxy.messages.Add(_proxy.message);
            view.UpdateConsole(_proxy.messages.ToColumnReversed());
        }
    }
}