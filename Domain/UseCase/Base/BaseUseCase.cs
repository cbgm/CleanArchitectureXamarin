using System;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using System.Threading;
using Core.Util;

namespace Domain.UseCase.Base
{
    public abstract class BaseUseCase<T>
    {
        private IDisposable disposable;

        protected abstract IObservable<T> BuildUseCaseObserable(params object[] p);

        public void Execute<S>(IObserver<T> observer, S scheduler, params object[] parameters)
        {
            Dispose();
            IObservable<T> observable = BuildUseCaseObserable(parameters)
                    .SubscribeOn(new TaskPoolScheduler(new TaskFactory()))
                    .ObserveOnWith(scheduler);
            if (observable != null)
            {
                disposable = observable.Subscribe(observer);
            }
        }

        public void Dispose()
        {
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
