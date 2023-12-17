using BenchmarkDotNet.Attributes;

namespace BenchMarker;

[MemoryDiagnoser]
[RankColumn]
public class ExtractWordsBenchMark
{
    [Params("This is a sentence.",
        "Performance is always an important factor in software development.",
        "Huntsman spiders, members of the family Sparassidae, are known by this name because of their speed and mode of hunting. They are also called giant crab spiders because of their size and appearance. Larger species sometimes are referred to as wood spiders, because of their preference for woody places.")]
    public string Book { get; set; }



    [Benchmark]
    public int ParseWithString()
    {
        var firstIndex = 0; 
        var lastIndex=0;
        //var words = new List<string>();
        var wordCount = 0;
        foreach (var c in Book)
        {
            lastIndex++;
            if (c == ' ' || c == '.' || c == ',' || c == ';' || c == '!')
            {
                var word = Book.Substring(firstIndex, lastIndex - firstIndex - 1);
                //words.Add(word);
                wordCount++;
                firstIndex = lastIndex;
            }
        }

        //Console.WriteLine(string.Join("|", words));
        return wordCount;
    }

    [Benchmark]
    public int ParseWithSpan()
    {
        var bookSpan = Book.AsSpan();
        var firstIndex = 0;
        var lastIndex = 0;
        //var words = new List<string>();
        var wordCount = 0;
        foreach (var c in bookSpan)
        {
            lastIndex++;
            if (c == ' ' || c == '.' || c == ',' || c == ';' || c == '!')
            {
                var word = bookSpan.Slice(firstIndex, lastIndex - firstIndex - 1);
                //words.Add(word.ToString());
                wordCount++;
                firstIndex = lastIndex;
            }
        }

        //Console.WriteLine(string.Join("|", words));
        return wordCount;
    }
}
