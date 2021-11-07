using Xunit;
using Snakey.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snakey.Models;
using Snakey.Snacks;
using Snakey.Adapter;
using System.Threading;
using Snakey.Managers;
using SnakeyTests.Mocks;

namespace Snakey.Observer.Tests
{
    public class PublisherTests
    {
        [StaFact]
        public void NotifyObserversTest()
        {
            Mocks.GetGameState();

            var publisher = new Publisher();
            publisher.RegisterObserver(new SnackObserver());
            publisher.RegisterObserver(new SnackObserver());
            publisher.RegisterObserver(new AudioPlayer());
            publisher.RegisterObserver(new AudioPlayer());
            int notifiedObservers = publisher.NotifyObservers(new SnackAdapter(new MysteryApple()));
            Assert.True(notifiedObservers == 4);
        }

        [Fact()]
        public void PublisherTest()
        {
            var publisher = new Publisher();

            Assert.IsType<Publisher>(publisher);
        }

        

        [Fact()]
        public void RegisterObserverTest()
        {
            var publisher = new Publisher();
            IObserver given = new SnackObserver();
            IObserver returned = publisher.RegisterObserver(given);
            Assert.Equal<IObserver>(given, returned);
        }

        [Fact()]
        public void RemoveObserverTest()
        {
            var publisher = new Publisher();
            IObserver given = publisher.RegisterObserver(new SnackObserver());
            IObserver returned = publisher.RemoveObserver(given);
            Assert.Equal<IObserver>(given, returned);
        }
    }
}