using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MenuBar : MonoBehaviour
{
    [SerializeField] private Button _calculatorButton;
    [SerializeField] private Button _messengerButton;
    public IObservable<Unit> onButton1Click => _calculatorButton.onClick.AsObservable();
    public IObservable<Unit> onButton2Click => _messengerButton.onClick.AsObservable();

    public void UpdateButtons(in bool calculatorActive, in bool messengerActive)
    {
        _calculatorButton.interactable = calculatorActive;
        _messengerButton.interactable = messengerActive;
    }
}