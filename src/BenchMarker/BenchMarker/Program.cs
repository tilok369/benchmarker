// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using BenchMarker;

//BenchmarkRunner.Run<ValidPasswordBenchMark>();
BenchmarkRunner.Run<ExtractWordsBenchMark>();

Console.ReadKey(true);
