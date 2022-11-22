using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace DotNet7BenchMark
{
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60)]
    [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net70)]
    public class ReflectionTest
    {
        private MethodInfo _zeroArgs;
        private MethodInfo _oneArgs;
        private object[] _args = new object[] { 45 };

        [GlobalSetup]
        public void SetUp()
        {
             _zeroArgs = typeof(Program).GetMethod(nameof(Program.ZeroArgsMethod));
             _oneArgs = typeof(Program).GetMethod(nameof(Program.OneArgsMethod));
        }

        [Benchmark]
        public void InvokeZeroArgMethod() => _zeroArgs.Invoke(null, null);
        [Benchmark]
        public void InvokeOneArgMethod() => _oneArgs.Invoke(null, _args);
    }
}