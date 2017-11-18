using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUnitTestProject.ManageProgramFlow {

    [TestClass, TestCategory(nameof(ManageProgramFlow))]
    public class MultithreadingAndAsynchronousProcessing {

        // In cases where a query is performing a significant amount of non-compute-bound work such as File I/O, 
        // it might be beneficial to specify a degree of parallelism greater than the number of cores on the machine.
        [TestMethod]
        public void TestSimpleMultithreading() {
            var source = Enumerable.Range(1, 10000);

            var evenNums = (from num in source.AsParallel().AsUnordered().WithExecutionMode(ParallelExecutionMode.ForceParallelism).WithDegreeOfParallelism(2)
                           where num % 2 == 0
                           select num).ToList();

            var before = int.MinValue;
            var ordered = true;
            Assert.IsFalse(evenNums.Any(e => e % 2 != 0), "a number was not even");
            for (var i = 0; i < evenNums.Count(); i++) {
                if (evenNums[i] < before) { ordered = false; break; }
                before = evenNums[i];
            }
            Assert.IsFalse(ordered);

            evenNums = (from num in source.AsParallel().AsOrdered()
                        where num % 2 == 0
                        select num).ToList();

            ordered = true;
            before = int.MinValue;
            for (var i = 0; i < evenNums.Count(); i++) {
                if (evenNums[i] < before) { ordered = false; break; }
                before = evenNums[i];
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestForAll() {
            var concurrentBag = new ConcurrentBag<int>();
            var nums = Enumerable.Range(10, 10000);
            var query = from num in nums.AsParallel()
                        where num % 10 == 0
                        select num;

            query.ForAll(n => concurrentBag.Add(n % 10));

            Assert.IsFalse(concurrentBag.Any(n => n != 0));
        }

        [TestMethod]
        public void TestPartitioner() {
            var nums = Enumerable.Range(0, 10000000).ToArray();

            var customPartitioner = Partitioner.Create(nums, false);

            var q = from x in customPartitioner.AsParallel()
                    select x * Math.PI;

            var watch = Stopwatch.StartNew();
            q.ForAll(i => Validate(i, 0, 10000000));
            Trace.WriteLine($"With a custom partitioner: {watch.Elapsed.ToString()}");

            watch = Stopwatch.StartNew();
            q.AsSequential().ToList().ForEach(d => Validate(d, 0, 10000000));
            Trace.WriteLine($"Parallel + Sequential: {watch.Elapsed.ToString()}");
            watch.Stop();

            var q1 = from x in nums
                select x * Math.PI;

            watch = Stopwatch.StartNew();
            q1.ToList().ForEach(d => Validate(d, 0, 10000000));
            Trace.WriteLine($"Sequential all the way: {watch.Elapsed.ToString()}");

            var q2 = from x in nums.AsParallel()
                     select x * Math.PI;
            watch = Stopwatch.StartNew();
            q2.ForAll(i => Validate(i, 0, 10000000));
            Trace.WriteLine($"Letting the PLINQ handle for itself: {watch.Elapsed.ToString()}");
        }

        void Validate(double n, int f, int c) {
            var i = (int)Math.Round(n / Math.PI);
            Assert.IsTrue(i >= f && i <= c);
        }
    }
}
