using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ZString.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            new BenchmarkSwitcher(typeof(Program).Assembly).Run();
        }
    }
}
