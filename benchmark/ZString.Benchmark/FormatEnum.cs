using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ZString.Benchmark
{
    [MemoryDiagnoser]
    [ShortRunJob]
    public class FormatEnum
    {
        enum TestEnum
        {
            A,
            B,
            C,
            D
        }
        const TestEnum SampleValue = TestEnum.A;
        [GlobalSetup]
        public void Setup()
        {
            // StringFormatter needs registering custom formatter.
            System.Text.Formatting.StringBuffer.SetCustomFormatter<TestEnum>(TestEnumFormatter);
        }
        static void TestEnumFormatter(System.Text.Formatting.StringBuffer buffer, TestEnum value, System.Text.Formatting.StringView view)
        {
            switch(value)
            {
                case TestEnum.A:
                    buffer.Append("A");
                    break;
                case TestEnum.B:
                    buffer.Append("B");
                    break;
                case TestEnum.C:
                    buffer.Append("C");
                    break;
                case TestEnum.D:
                    buffer.Append("D");
                    break;
                default:
                    buffer.Append((int)value, view);
                    break;
            }
        }

        [Benchmark]
        public void ZStringFormat()
        {
            Cysharp.Text.ZString.Format("aaaa: {0}", SampleValue);
        }
        [Benchmark]
        public void StringFormatterFormat()
        {
            System.Text.Formatting.StringBuffer.Format("aaaa: {0}", SampleValue);
        }
        [Benchmark]
        public void BclFormat()
        {
            string.Format("aaaa: {0}", SampleValue);
        }
    }
}