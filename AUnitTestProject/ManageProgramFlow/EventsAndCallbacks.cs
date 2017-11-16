using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AUnitTestProject.ManageProgramFlow {

    [TestClass]
    public class EventsAndCallbacks {

        [TestMethod, TestCategory("ManageProgramFlow")]
        public void CreateEventHandlers() {
            int i = 0;
            var counter = new Counter();
            counter.ThresholdReached += (o, e) => {
                Assert.AreEqual(typeof(Counter), o.GetType());
                var c = (Counter)o;
                c.IsThresholdReached = true;
                Interlocked.Increment(ref i);
            };

            counter.ThresholdReached2 += (o, e) => {
                Assert.AreEqual(typeof(Counter), o.GetType());
                var c = (Counter)o;
                c.IsThresholdReached = e?.IsThresholdReached ?? false;
                Interlocked.Increment(ref i);
            };

            counter.ThresholdReached3 += (e) => {
                counter.IsThresholdReached = e?.IsThresholdReached ?? false;
                Interlocked.Increment(ref i);
            };

            Assert.IsFalse(counter.IsThresholdReached);
            counter.Count(60);
            while (i < 3) Thread.Sleep(10);
            Assert.IsTrue(counter.IsThresholdReached);
            Assert.IsTrue(i == 3);
        }

    }
    
    // A delegate is a type that holds a reference to a method. A delegate is declared with a
    // signature that shows the return type and parameters for the methods it references, and 
    // can hold references only to methods that match its signature. A delegate is thus equivalent
    // to a type-safe function pointer or a callback. A delegate is sufficient to define a delegate class;
    delegate void ThresholdReachedEventHandler(ThresholdReachedEventArgs e);

    class ThresholdReachedEventArgs {
        public bool IsThresholdReached { get; set; }
    }

    class Counter {

        // An event is a message sent by an object to signal the occurrence of an action.
        // The action could be caused by user interaction, such as a button click, or it could
        // be raised by some other program logic, such as changing a property's value. The object
        // that raises the event is called the event sender. The event sender doesn't know which object or
        // method will receibe (handle) the events it raises. The event is typically a member of the event sender;
        // for exemple, the Click event is a member of the Button class, and the PropertyChanged event
        // is a member of the class that implements the INotifyPropertyChanged interface.
        public event EventHandler ThresholdReached;

        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached2;

        public event ThresholdReachedEventHandler ThresholdReached3;

        public bool IsThresholdReached { get; set; }

        protected virtual void OnThresholdReached(EventArgs e) {
            ThresholdReached(this, e);
        }

        protected virtual void OnThresholdReached2(ThresholdReachedEventArgs e) {
            ThresholdReached2(this, e);
        }

        protected virtual void OnThresholdReached3(ThresholdReachedEventArgs e) {
            ThresholdReached3(e);
        }

        public void Count(int threshold) {
            var i = 0;
            while (i < threshold) { Thread.Sleep(10); i++; }

            OnThresholdReached(new EventArgs());
            OnThresholdReached2(new ThresholdReachedEventArgs { IsThresholdReached = true });
            OnThresholdReached3(new ThresholdReachedEventArgs { IsThresholdReached = true });
        }
    }
}
