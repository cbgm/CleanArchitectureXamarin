using System;
using Core.UI;

namespace Domain.UseCase.Base
{
    public abstract class BaseObserver<V, T>: IObserver<T>
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
            throw new NotImplementedException();
        }

        public virtual void OnNext(T value)
        {
            throw new NotImplementedException();
        }
    }
}
