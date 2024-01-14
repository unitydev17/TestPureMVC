using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MessengerScreen : MonoBehaviour
{
    [SerializeField] private TMP_InputField _text;
    [SerializeField] private Button _sendButton;
    [SerializeField] private TMP_Text _consoleText;

    public IObservable<Unit> onButtonClick => _sendButton.onClick.AsObservable();

    public IObservable<string> onMessageChange => _text.onEndEdit.AsObservable();

    public void UpdateConsole(string message)
    {
        _consoleText.text = message;
    }
}