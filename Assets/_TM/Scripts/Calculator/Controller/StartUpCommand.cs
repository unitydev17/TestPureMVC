using System;
using System.Collections.Generic;
using com.calculator.model;
using com.calculator.view;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;

namespace com.calculator.controller
{
    public class StartUpCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            if (!(notification.Body is MonoBehaviour[] screens))
            {
                throw new Exception(Constants.ScreensArrayIsEmpty);
            }

            RegisterMenuBar(screens);
            RegisterCalculator(screens[1]);
            RegisterMessenger(screens[2]);

            SendNotification(Events.UpdateMenuBar);
        }

        private void RegisterCalculator(MonoBehaviour obj)
        {
            Facade.RegisterProxy(new CalculatorProxy());;
            var screen = obj as CalculatorScreen;
            Facade.RegisterMediator(new CalculatorScreenMediator(screen));
        }

        private void RegisterMessenger(MonoBehaviour obj)
        {
            Facade.RegisterProxy(new MessengerProxy());
            var screen = obj as MessengerScreen;
            Facade.RegisterMediator(new MessengerScreenMediator(screen));
        }

        private void RegisterMenuBar(IReadOnlyList<MonoBehaviour> screens)
        {
            Facade.RegisterProxy(new MenuBarProxy());
            Facade.RegisterMediator(new MenuBarMediator(screens));
        }
    }
}