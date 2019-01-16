using System;

namespace Core.Domain.UseCase.Base
{
    public abstract class BaseObserver<V, T> : IObserver<T>
    {
        protected V parentsView;

        protected BaseObserver(V parentsView)
        {
            this.parentsView = parentsView;
        }

        public virtual void OnCompleted()
        {
        }

        public virtual void OnError(Exception error)
        {
        }

        public virtual void OnNext(T value)
        {
        }
    }
}
