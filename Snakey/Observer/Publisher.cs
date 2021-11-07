using Snakey.Adapter;
using System.Collections.Generic;

namespace Snakey.Observer
{
    public class Publisher : ISubject
    {
        private List<IObserver> Observers;

        public Publisher()
        {
            this.Observers = new();
        }

        public int NotifyObservers(ISnackTarget snack)
        {
            Observers.ForEach(observers => observers.Update(snack));
            return Observers.Count;
        }

        public IObserver RegisterObserver(IObserver observer)
        {
            Observers.Add(observer);
            return observer;
        }

        public IObserver RemoveObserver(IObserver observer)
        {
            Observers.Remove(observer);
            return observer;
        }
    }
}
