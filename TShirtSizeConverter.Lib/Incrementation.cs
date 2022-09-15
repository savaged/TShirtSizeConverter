namespace TShirtSizeConverter.Lib;

public static class Incrementation
{
    public static double EvenSkippedFibonacci(int p) => SkippedFib(p);
    
    public static double OddSkippedFibonacci(int p) => SkippedFib(p, true);
    
    public static double ByThree(double x) => Math.Pow(3, Math.Round(x * 0.9, MidpointRounding.ToZero));
    
    public static double Fibonacci(double x) => x > 1 ? Fibonacci(x - 1) + Fibonacci(x - 2) : (x == 0) ? x : 1;
    
    private static double SkippedFib(int p, bool skipOdd = false)
    {
        var dict = new Dictionary<int, int> { {0,0}, {1,1} };
        var counter = 2;
        for (var i = 3; i <= 12; i++)
        {
            if (i % 2 == (skipOdd ? 1 : 0))
            {
                dict.Add(counter++, (int)Fibonacci(i));
            }
        }
        return dict.ContainsKey(p) ? dict[p] : 0;
    }
    
}