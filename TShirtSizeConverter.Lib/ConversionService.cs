using System.Globalization;

namespace TShirtSizeConverter.Lib;

public class ConversionService : IConversionService
{
    private readonly IDictionary<int, Tuple<string, double>> _dict;

    public ConversionService(Func<double, double>? incrementation = null)
    {
        _dict = new Dictionary<int, Tuple<string, double>>();
        if (incrementation == null)
        {
            _dict.Add(0, new Tuple<string, double>("XS", 0.5));
            _dict.Add(1, new Tuple<string, double>("S", 1));
            _dict.Add(2, new Tuple<string, double>("M", 3));
            _dict.Add(3, new Tuple<string, double>("L", 8));
            _dict.Add(4, new Tuple<string, double>("XL", 21));
            _dict.Add(5, new Tuple<string, double>("XXL", 55));
        }
        else
        {
            _dict.Add(0, new Tuple<string, double>("XS", 0));
            _dict.Add(1, new Tuple<string, double>("S", 0));
            _dict.Add(2, new Tuple<string, double>("M", 0));
            _dict.Add(3, new Tuple<string, double>("L", 0));
            _dict.Add(4, new Tuple<string, double>("XL", 0));
            _dict.Add(5, new Tuple<string, double>("XXL", 0));
            SetShirtSizes(0.5, incrementation);
        }
    }

    public string Convert(string input)
    {
        var value = string.Empty;
        if (double.TryParse(input, out var manDays))
        {
            value = DaysToTShirtSize(manDays);
        }
        else if (_dict.Any(e => e.Value.Item1 == input))
        {
            value = ShirtSizeToDays(input);
        }
        return value;
    }

    private string DaysToTShirtSize(double manDays)
    {
        var first = new KeyValuePair<int, Tuple<string, double>>();
        foreach (var i in _dict)
        {
            if (Math.Abs(i.Value.Item2 - manDays) > 0.1) continue;
            first = i;
            break;
        }
        return first.Value?.Item1 ?? string.Empty;
    }
    
    private string ShirtSizeToDays(string shirtSize)
    {
        return _dict.FirstOrDefault(i => i.Value.Item1 == shirtSize).Value.Item2.ToString(
            CultureInfo.InvariantCulture);
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
    
}