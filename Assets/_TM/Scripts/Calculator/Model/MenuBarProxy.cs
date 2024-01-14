using PureMVC.Patterns;

namespace com.calculator.model
{
    public class MenuBarProxy : Proxy
    {
        public override void OnRegister()
        {
            menuBarBo = new MenuBarBo
            {
                calculatorActive = true,
                messengerActive = false
            };
        }

        public MenuBarBo menuBarBo { get; private set; }
    }
}