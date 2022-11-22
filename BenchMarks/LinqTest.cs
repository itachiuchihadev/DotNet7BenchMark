using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace DotNet7BenchMark.BenchMarks
{
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    public class LinqTest
    {
        [Params(100)]
        public int ListSize { get; set; }

        private IEnumerable<int> _items;

        [GlobalSetup]
        public void Setup()
        {
            _items = Enumerable.Range(1, ListSize).ToArray();
        }
        [Benchmark]
        public int Max() => _items.Max();
        [Benchmark]
        public int Min() => _items.Min();
        [Benchmark]
        public double Average() => _items.Average();
        [Benchmark]
        public int Sum() => _items.Sum();
        
        [Benchmark]
        public bool IsEqualString() =>  "Abhishek" == "KUmar";

    }
}