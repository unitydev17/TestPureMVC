using com.calculator.view;
using UnityEngine;

namespace com.calculator
{
    public class ApplicationStarter : MonoBehaviour
    {
        [SerializeField] private CalculatorScreen _calculatorScreen;
        [SerializeField] private MessengerScreen _messengerScreen;
        [SerializeField] private MenuBar _menuBar;

        private void Start()
        {
            var facade = ApplicationFacade.instance;
            facade?.StartUp(new MonoBehaviour[]
            {
                _menuBar,
                _calculatorScreen,
                _messengerScreen
            });
        }
    }
}