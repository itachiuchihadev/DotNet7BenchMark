using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace DotNet7BenchMark.BenchMarks
{
    [MemoryDiagnoser(false)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    public class LoopTest
    {
        [Params(100, 1000)]
        public int Size { get; set; }
        private int[] _items;
        private Wrapper[] _wrapperItems;
        [GlobalSetup]
        public void Setup()
        {
            var random = new Random(500);
            _items = Enumerable.Range(1, Size).Select(x => random.Next(x)).ToArray();
            _wrapperItems = Enumerable.Range(1, Size).Select(x => {
                var number = random.Next(x);
                return new Wrapper(number, number.ToString());
        }).ToArray();
        }
        [Benchmark]
        public int[] ForLoop()
        {
            for(int i =0; i < _items.Length; i++)
            {
                SomeLogic(_items[i]);
            }
            return _items;
        }
        [Benchmark]
        public int[] ForEachLoop()
        {
            foreach(var item in _items)
            {
                SomeLogic(item);
            }
            return _items;
        }
        [Benchmark]
        public int[] SpanLoop()
        {
            Span<int> span = _items;
            for(int i =0; i < span.Length; i++)
            {
                var item = span[i];
                SomeLogic(item);
            }
            return _items;
        }
        [Benchmark]
        public int[] ForRefLoop()
        {
            Span<int> span = _items;
            ref var searchSpan = ref MemoryMarshal.GetReference(span);
            for(int i = 0; i < span.Length; i++)
            {
                var item = Unsafe.Add(ref searchSpan, i);
                SomeLogic(item);
            }
            return _items;
        }
        [Benchmark]
        public Wrapper[] ForClassRefLoop()
        {
            ref var searchSpan = ref MemoryMarshal.GetArrayDataReference(_wrapperItems);
            for(int i = 0; i < _wrapperItems.Length; i++)
            {
                var item = Unsafe.Add(ref searchSpan, i);
                SomeLogic(item.Number);
            }
            return _wrapperItems;
        }
        private void SomeLogic(int item){ }

    }
    public record Wrapper(int Number, string Text);
}