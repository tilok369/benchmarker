﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System.Buffers;

namespace BenchMarker;

[MemoryDiagnoser]
//[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class ValidPasswordBenchMark
{
    private static readonly string validCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890!@#$";

    private static readonly SearchValues<char> validCharacterSearchValues = SearchValues.Create(validCharacters);

    [Params("Test@123", "Admin%1234", "Test@123Admin!@12asfatsrhyAERD543")]
    public string Password { get; set; }

    [Benchmark]
    public bool IsValidPasswordWithIteration()
    {
        foreach (char p in Password) 
        { 
            if(!validCharacters.Contains(p))
                return false;
        }
        return true;
    }

    [Benchmark]
    public bool IsValidPasswordWithLinq()
    {
        return Password.All(validCharacters.Contains);
    }

    [Benchmark]
    public bool IsValidPasswordWithSpan()
    {
        return Password.AsSpan().IndexOfAnyExcept(validCharacters) == -1;
    }

    [Benchmark]
    public bool IsValidPasswordWithSearchValues()
    {
        return Password.AsSpan().IndexOfAnyExcept(validCharacterSearchValues) == -1;
    }
}
