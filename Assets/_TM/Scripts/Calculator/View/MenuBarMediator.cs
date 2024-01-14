using System;
using System.Collections.Generic;
using com.calculator.model;
using PureMVC.Interfaces;
using UnityEngine;

namespace com.calculator.view
{
    public class MenuBarMediator : BaseMediator
    {
        private const string Name = "MenuBarMediator";

        private MenuBarProxy _proxy;

        private MenuBar view => (MenuBar) ViewComponent;

        private readonly MonoBehaviour _calculatorScreen;
        private readonly MonoBehaviour _messengerScreen;

        private enum ScreenType
        {
            Calculator,
            Messenger
        }

        public MenuBarMediator(IReadOnlyList<MonoBehaviour> screens) : base(Name, screens[0])
        {
            _calculatorScreen = screens[1];
            _messengerScreen = screens[2];

            RegisterListener(view.onButton1Click, value => SetScreen(ScreenType.Calculator));
            RegisterListener(view.onButton2Click, value => SetScreen(ScreenType.Messenger));
        }

        private void SetScreen(ScreenType type)
        {
            switch (type)
            {
                case ScreenType.Calculator:
                    _proxy.menuBarBo.calculatorActive = true;
                    _proxy.menuBarBo.messengerActive = false;
                    break;

                case ScreenType.Messenger:
                    _proxy.menuBarBo.calculatorActive = false;
                    _proxy.menuBarBo.messengerActive = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            UpdateMenuBar();
            UpdateScreens();
        }


        public override void OnRegister()
        {
            _proxy = Facade.RetrieveProxy(MenuBarProxy.NAME) as MenuBarProxy;
        }

        public override IList<string> ListNotificationInterests()
        {
            var notifications = base.ListNotificationInterests();
            notifications.Add(Events.UpdateMenuBar);
            return notifications;
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case Events.UpdateMenuBar:

                    UpdateMenuBar();
                    UpdateScreens();

                    break;
            }
        }

        private void UpdateMenuBar()
        {
            view.UpdateButtons(!_proxy.menuBarBo.calculatorActive, !_proxy.menuBarBo.messengerActive);
        }

        private void UpdateScreens()
        {
            _calculatorScreen.gameObject.SetActive(_proxy.menuBarBo.calculatorActive);
            _messengerScreen.gameObject.SetActive(_proxy.menuBarBo.messengerActive);
        }
    }
}