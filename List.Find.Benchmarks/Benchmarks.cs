using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace List.Find.Benchmarks;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[Config(typeof(Config))]
public class Benchmarks
{
    private List<Product> _list;
    private RefactoredList<Product> _refactoredList;
    
    [Params(50, 500, 5_000, 5_000_000)] public int TotalItemCount { get; set; }
    
    [Params(10, 100, 1_000, 1_000_000)] public int SearchValue { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        var random = new Random(99);
        var products = Enumerable.Range(1, TotalItemCount).Select(i =>
        {
            var productName = new string('a', random.Next(1,100));
            return new Product(i, productName);
        }).ToList();
        
        _list = new List<Product>(products);
        _refactoredList = new RefactoredList<Product>(products);
    }

    [BenchmarkCategory("Find"), Benchmark(Baseline = true)]
    public Product? Before_Find()
    {
        Product? result = null;

        for (int i = 0; i < 100_000; i++)
        {
            result = _list.Find(x => x.ProductId == SearchValue);
        }

        return result;
    }
    
    [BenchmarkCategory("Find"), Benchmark(Baseline = false)]
    public Product? After_Find()
    {
        Product? result = null;

        for (int i = 0; i < 100_000; i++)
        {
            result = _refactoredList.Find(x => x.ProductId == SearchValue);
        }

        return result;
    }
}