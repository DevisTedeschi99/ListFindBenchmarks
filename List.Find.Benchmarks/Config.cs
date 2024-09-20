using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;

namespace List.Find.Benchmarks;

public class Config : ManualConfig
{
    public Config()
    {
        SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage);
    }
}