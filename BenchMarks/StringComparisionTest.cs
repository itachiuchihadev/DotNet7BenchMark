using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace DotNet7BenchMark.BenchMarks
{
    [MemoryDiagnoser(true)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class StringComparisionTest
    {
        [Benchmark]
        [Arguments("https://github.com")]
        public bool StartWith(string text) => text.StartsWith("https", StringComparison.OrdinalIgnoreCase);
    }
}