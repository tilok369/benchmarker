// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using BenchMarker;

BenchmarkRunner.Run<ValidPasswordBenchMark>();
//BenchmarkRunner.Run<ExtractWordsBenchMark>();
//BenchmarkRunner.Run<LinkAllBenchMark>();

Console.ReadKey(true);
