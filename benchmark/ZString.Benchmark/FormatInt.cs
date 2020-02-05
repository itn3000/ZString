using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ZString.Benchmark
{
    [MemoryDiagnoser]
    [ShortRunJob]
    public class FormatInt
    {
        const int SampleInteger = 0;
        [Benchmark]
        public void ZStringFormat()
        {
            Cysharp.Text.ZString.Format("aaaa: {0}", SampleInteger);
        }
        [Benchmark]
        public void StringFormatterFormat()
        {
            System.Text.Formatting.StringBuffer.Format("aaaa: {0}", SampleInteger);
        }
        [Benchmark]
        public void BclFormat()
        {
            string.Format("aaaa: {0}", SampleInteger);
        }
    }
}