using System;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using Core.Util;

namespace Domain.UseCase.Base
{
    public abstract class BaseUseCase<T>
    {
        private IDisposable disposable;
        private object scheduler;

        protected abstract IObservable<T> BuildUseCaseObserable(params object[] p);

        public void Execute(IObserver<T> observer, params object[] parameters)
        {
            Dispose();
            IObservable<T> observable = BuildUseCaseObserable(parameters)
                    .SubscribeOn(new TaskPoolScheduler(new TaskFactory()))
                    .ObserveOnWith(this.scheduler);
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

        public void SetScheduler(object scheduler)
        {
            this.scheduler = scheduler;
        }
    }
}
