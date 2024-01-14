using System;
using PureMVC.Patterns;
using UniRx;

namespace com.calculator.view
{
    public class BaseMediator : Mediator, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();


        protected BaseMediator(string name, object viewComponent) : base(name, viewComponent)
        {
        }

        protected void RegisterListener(IObservable<string> observable, Action<string> handler)
        {
            _disposables.Add(observable.Subscribe(handler));
        }

        protected void RegisterListener(IObservable<Unit> observable, Action<Unit> handler)
        {
            _disposables.Add(observable.Subscribe(handler));
        }

        public void Dispose()
        {
            _disposables?.Dispose();
        }
    }
}