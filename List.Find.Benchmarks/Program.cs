using BenchmarkDotNet.Running;
using List.Find.Benchmarks;

BenchmarkRunner.Run<Benchmarks>();
BenchmarkRunner.Run<LinqBenchmarks>();