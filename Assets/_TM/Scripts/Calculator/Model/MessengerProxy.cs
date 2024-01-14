using System.Collections.Generic;
using PureMVC.Patterns;

namespace com.calculator.model
{
    public class MessengerProxy : Proxy
    {
        public const string Name = "MessengerProxy";

        public string message;
        public readonly List<string> messages;

        public MessengerProxy() : base(Name)
        {
            messages = new List<string>();
        }
    }
}