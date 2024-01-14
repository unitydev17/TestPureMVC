using System;
using com.calculator.utils;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace com.calculator.view
{
    public class CalculatorScreen : MonoBehaviour
    {
        [SerializeField] private Button _plusBtn;
        [SerializeField] private Button _minusBtn;
        [SerializeField] private Button _multiplyBtn;
        [SerializeField] private Button _divideBtn;

        [SerializeField] private TMP_InputField _value1;
        [SerializeField] private TMP_InputField _value2;
        [SerializeField] private TMP_InputField _result;
        [SerializeField] private TMP_Text _error;


        public IObservable<string> onValue1Changed => _value1.onValueChanged.AsObservable();
        public IObservable<string> onValue2Changed => _value2.onValueChanged.AsObservable();

        public IObservable<Unit> onPlusBtnChanged => _plusBtn.onClick.AsObservable();
        public IObservable<Unit> onMinusBtnChanged => _minusBtn.onClick.AsObservable();
        public IObservable<Unit> onMultiplyBtnChanged => _multiplyBtn.onClick.AsObservable();
        public IObservable<Unit> onDivideBtnChanged => _divideBtn.onClick.AsObservable();


        public void UpdateResult(IResult result)
        {
            switch (result)
            {
                case ErrorResult errorResult:

                    _error.gameObject.SetActive(true);
                    _error.text = errorResult.errorMessage;
                    _result.text = Constants.NotANumber;
                    break;

                case CalculationResult calcResult:

                    _error.gameObject.SetActive(false);
                    _result.text = calcResult.value;
                    break;
            }

            if (string.IsNullOrWhiteSpace(_value1.text)) _value1.text = 0.ToString();
            if (string.IsNullOrWhiteSpace(_value2.text)) _value2.text = 0.ToString();
        }

        public void UpdateButtons(int state)
        {
            var values = state.Convert(4);
            _plusBtn.interactable = !values[0];
            _minusBtn.interactable = !values[1];
            _multiplyBtn.interactable = !values[2];
            _divideBtn.interactable = !values[3];
        }
    }
}