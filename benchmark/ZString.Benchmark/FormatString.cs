using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ZString.Benchmark
{
    [MemoryDiagnoser]
    [ShortRunJob]
    public class FormatString
    {
        const string SampleString = "abcdef";
        [Benchmark]
        public void ZStringFormat()
        {
            Cysharp.Text.ZString.Format("aaaa: {0}", SampleString);
        }
        [Benchmark]
        public void StringFormatterFormat()
        {
            System.Text.Formatting.StringBuffer.Format("aaaa: {0}", SampleString);
        }
        [Benchmark]
        public void BclFormat()
        {
            string.Format("aaaa: {0}", SampleString);
        }
    }
}