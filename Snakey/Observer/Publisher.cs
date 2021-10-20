using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Observer
{
    class Publisher : ISubject
    {
        private List<IObserver> Observers;

        public Publisher()
        {
            this.Observers = new();
        }

        public void NotifyObservers(Snack snack)
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
