using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace DotNet7BenchMark.BenchMarks
{
    [MemoryDiagnoser(true)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class RegexTest
    {
        [Params(RegexOptions.Compiled)]
        public RegexOptions Options { get; set; }
        [Params(false, true)]
        public bool BadInput { get; set; }
        private Regex? _regex;
        private string? _input;

        [GlobalSetup]
        public void Setup()
        {
            _regex = new(@"^[\s\u200c]+|[\s\u200c]+$", Options);
            _input = $"-- this benchmark will reveal everything {new string(' ', 10_000)}"+ (BadInput ? "!" : "");
        }

        [Benchmark]
        public bool IsMatch() => _regex!.IsMatch(_input!);
    }
}