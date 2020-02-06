using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

namespace ZString.Benchmark
{
    [MemoryDiagnoser]
    [ShortRunJob]
    public class BuilderInt
    {
        const string SampleString = "abcdef";
        [Benchmark]
        public void ZStringBuildInt()
        {
            var builder = Cysharp.Text.ZString.CreateStringBuilder();
            builder.Append((int)1);
            builder.ToString();
            builder.Dispose();
        }
        [Benchmark]
        public void StringBuildInt()
        {
            var builder = new System.Text.Formatting.StringBuffer();
            builder.Append((int)1, System.Text.Formatting.StringView.Empty);
            builder.ToString();
        }
        [Benchmark]
        public void BclBuildInt()
        {
            var builder = new StringBuilder();
            builder.Append((int)1);
            builder.ToString();
        }
    }
    [MemoryDiagnoser]
    [ShortRunJob]
    public class BuilderString
    {
        const string SampleString = "abcdef";
        [Benchmark]
        public void ZStringBuildString()
        {
            var builder = Cysharp.Text.ZString.CreateStringBuilder();
            builder.Append(SampleString);
            builder.ToString();
            builder.Dispose();
        }
        [Benchmark]
        public void StringBuildString()
        {
            var builder = new System.Text.Formatting.StringBuffer();
            builder.Append(SampleString);
            builder.ToString();
        }
        [Benchmark]
        public void BclBuildString()
        {
            var builder = new StringBuilder();
            builder.Append(SampleString);
            builder.ToString();
        }
    }
}