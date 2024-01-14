using com.calculator.controller;
using PureMVC.Patterns;
using UnityEngine;

namespace com.calculator
{
    public class ApplicationFacade : Facade
    {
        public static ApplicationFacade instance => (ApplicationFacade) (m_instance ?? new ApplicationFacade());

        protected override void InitializeController()
        {
            base.InitializeController();
            RegisterCommand(Events.Startup, typeof(StartUpCommand));
        }
        public void StartUp(MonoBehaviour[] screens)
        {
            SendNotification(Events.Startup, screens);
        }
    }
}