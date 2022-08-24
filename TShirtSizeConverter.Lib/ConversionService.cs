using System.Globalization;

namespace TShirtSizeConverter.Lib;

public class ConversionService : IConversionService
{
    private readonly IDictionary<int, Tuple<string, double>> _dict;

    public ConversionService(Func<double, double>? incrementation = null)
    {
        _dict = new Dictionary<int, Tuple<string, double>>();
        _dict.Add(0, new Tuple<string, double>("XS", 0));
        _dict.Add(1, new Tuple<string, double>("S", 0));
        _dict.Add(2, new Tuple<string, double>("M", 0));
        _dict.Add(3, new Tuple<string, double>("L", 0));
        _dict.Add(4, new Tuple<string, double>("XL", 0));
        _dict.Add(5, new Tuple<string, double>("XXL", 0));
        _dict.Add(6, new Tuple<string, double>("Project", 0));

        incrementation ??= f => SkippedFib((int)f);
        SetShirtSizes(0.5, incrementation);
    }

    public string Convert(string input)
    {
        return double.TryParse(input, out var manDays) ?
            DaysToTShirtSize(manDays) : ShirtSizeToDays(input);
    }

    private string DaysToTShirtSize(double manDays)
    {
        return _dict.MinBy(i => Math.Abs(manDays - i.Value.Item2)).Value.Item1;
    }
    
    private string ShirtSizeToDays(string shirtSize)
    {
        if (string.IsNullOrEmpty(shirtSize)) return string.Empty;
        return shirtSize.Length switch
        {
            > 2 when shirtSize.EndsWith("S") => "<0.5",
            > 3 when shirtSize.EndsWith("L") => "Project",
            _ => _dict.FirstOrDefault(i => i.Value.Item1 == shirtSize)
                .Value.Item2.ToString(CultureInfo.InvariantCulture)
        };
    }

    private void SetShirtSizes(double startValue, Func<double, double> incrementation)
    {
        SetShirtSize(0, startValue, incrementation);
    }

    private void SetShirtSize(int pos, double value, Func<double, double> incrementation)
    {
        if (pos >= _dict.Count) return;

        if (value > 0)
        {
            if (!_dict.Values.Any(i => Math.Abs(i.Item2 - value) < 0.1))
            {
                _dict[pos] = new Tuple<string, double>(_dict[pos++].Item1, value);
                value = incrementation(pos);
            }
            else
            {
                value = incrementation(pos + 1);
            }
        }
        SetShirtSize(pos, value, incrementation);
    }
    
    private double SkippedFib(int p)
    {
        int Fib(int x) => x > 1 ? Fib(x - 1) + Fib(x - 2) : (x == 0) ? x : 1;
        var dict = new Dictionary<int, int> { {0,0}, {1,1} };
        var counter = 2;
        for (var i = 3; i <= 12; i++)
        {
            if (i % 2 == 0)
            {
                dict.Add(counter++, Fib(i));
            }
        }
        return dict.ContainsKey(p) ? dict[p] : 0;
    }
    
}