// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using BenchMarker;

BenchmarkRunner.Run<ValidPasswordBenchMark>();

Console.ReadKey(true);
