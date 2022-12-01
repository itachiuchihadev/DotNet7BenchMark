using BenchmarkDotNet.Running;
using BenchmarkDotNet;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Validators;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Columns;
using DotNet7BenchMark.BenchMarks;


namespace DotNet7BenchMark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("------- DotNet6 Vs DotNet7 Performance Test ---------");
            var config = new ManualConfig()
                            .WithOptions(ConfigOptions.Default)
                            // .AddValidator(JitOptimizationsValidator.DontFailOnError)
                            .AddLogger(ConsoleLogger.Default)
                            .AddColumnProvider(DefaultColumnProviders.Instance);
            // BenchmarkRunner.Run<LinqTest>(config);
            // BenchmarkRunner.Run<ReflectionTest>(config);
            // BenchmarkRunner.Run<LoopTest>(config);
            // BenchmarkRunner.Run<RegexTest>(config);
            BenchmarkRunner.Run<StringComparisionTest>(config);
        }

        public static void ZeroArgsMethod() { }
        public static void OneArgsMethod(int i) { }
    }
}





