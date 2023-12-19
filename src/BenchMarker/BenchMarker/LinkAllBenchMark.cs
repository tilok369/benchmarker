using BenchmarkDotNet.Attributes;

namespace BenchMarker;

[MemoryDiagnoser]
[RankColumn]
public class LinkAllBenchMark
{
    public List<int> Numbers { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(100);

        Numbers = Enumerable
            .Range(0, 10000)
            .Select( _ => random.Next(1, int.MaxValue))
            .ToList();
    }

    [Benchmark]
    public bool WithAll()
    {
        return Numbers.All(n => n > 0);
    }

    [Benchmark]
    public bool WithTrueForAll()
    {
        return Numbers.TrueForAll(n => n > 0);
    }
}
