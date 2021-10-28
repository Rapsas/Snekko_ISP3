using Snakey.Adapter;
using System.Collections.Generic;

namespace Snakey.Observer
{
    class Publisher : ISubject
    {
        private List<IObserver> Observers;

        public Publisher()
        {
            this.Observers = new();
        }

        public void NotifyObservers(ISnackTarget snack)
        {
            Observers.ForEach(observers => observers.Update(snack));
        }

        public void RegisterObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }
    }
}
