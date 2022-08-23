using TShirtSizeConverter.Lib;

namespace TShirtSizeConverter.Test;

public class ConversionServiceTests
{
    [Fact]
    public void TestDefaultConvertWithShirtSize()
    {
        var conversionService = new ConversionService();
        Assert.Equal("0.5", conversionService.Convert("XS"));
        Assert.Equal("1", conversionService.Convert("S"));
        Assert.Equal("3", conversionService.Convert("M"));
        Assert.Equal("8", conversionService.Convert("L"));
        Assert.Equal("21", conversionService.Convert("XL"));
        Assert.Equal("55", conversionService.Convert("XXL"));
        Assert.Equal("", conversionService.Convert("XXS"));
        Assert.Equal("", conversionService.Convert("XXXL"));
        Assert.Equal("", conversionService.Convert(""));
    }
    
    [Fact]
    public void TestDefaultConvertWithManDays()
    {
        var conversionService = new ConversionService();
        Assert.Equal("XS", conversionService.Convert("0.5"));
        Assert.Equal("S", conversionService.Convert("1"));
        Assert.Equal("M", conversionService.Convert("3"));
        Assert.Equal("L", conversionService.Convert("8"));
        Assert.Equal("XL", conversionService.Convert("21"));
        Assert.Equal("XXL", conversionService.Convert("55"));
        Assert.Equal("", conversionService.Convert("0.1"));
        Assert.Equal("", conversionService.Convert("100"));
    }
     
    [Fact]
    public void TestMultipliedByThreeConvertWithShirtSize()
    {
        double ByThree(double x) => Math.Pow(3, Math.Round(x * 0.9, MidpointRounding.ToZero));
        var conversionService = new ConversionService(ByThree);
        Assert.Equal("0.5", conversionService.Convert("XS"));
        Assert.Equal("1", conversionService.Convert("S"));
        Assert.Equal("3", conversionService.Convert("M"));
        Assert.Equal("9", conversionService.Convert("L"));
        Assert.Equal("27", conversionService.Convert("XL"));
        Assert.Equal("81", conversionService.Convert("XXL"));
        Assert.Equal("", conversionService.Convert("XXS"));
        Assert.Equal("", conversionService.Convert("XXXL"));
        Assert.Equal("", conversionService.Convert(""));
    }
    
    [Fact]
    public void TestMultipliedByThreeConvertWithManDays()
    {
        double ByThree(double x) => Math.Pow(3, Math.Round(x * 0.9, MidpointRounding.ToZero));
        var conversionService = new ConversionService(ByThree);
        Assert.Equal("XS", conversionService.Convert("0.5"));
        Assert.Equal("S", conversionService.Convert("1"));
        Assert.Equal("M", conversionService.Convert("3"));
        Assert.Equal("L", conversionService.Convert("9"));
        Assert.Equal("XL", conversionService.Convert("27"));
        Assert.Equal("XXL", conversionService.Convert("81"));
        Assert.Equal("", conversionService.Convert("0.1"));
        Assert.Equal("", conversionService.Convert("100"));
    }
    
    [Fact]
    public void TestFibonacciConvertWithShirtSize()
    {
        double Fib(double x) => x > 1 ? Fib(x - 1) + Fib(x - 2) : (x == 0) ? x : 1;
        var conversionService = new ConversionService(Fib);
        Assert.Equal("0.5", conversionService.Convert("XS"));
        Assert.Equal("1", conversionService.Convert("S"));
        Assert.Equal("2", conversionService.Convert("M"));
        Assert.Equal("3", conversionService.Convert("L"));
        Assert.Equal("5", conversionService.Convert("XL"));
        Assert.Equal("8", conversionService.Convert("XXL"));
        Assert.Equal("", conversionService.Convert("XXS"));
        Assert.Equal("", conversionService.Convert("XXXL"));
        Assert.Equal("", conversionService.Convert(""));
    }
    
    [Fact]
    public void TestFibonacciConvertWithManDays()
    {
        double Fib(double x) => x > 1 ? Fib(x - 1) + Fib(x - 2) : (x == 0) ? x : 1;
        var conversionService = new ConversionService(Fib);
        Assert.Equal("XS", conversionService.Convert("0.5"));
        Assert.Equal("S", conversionService.Convert("1"));
        Assert.Equal("M", conversionService.Convert("2"));
        Assert.Equal("L", conversionService.Convert("3"));
        Assert.Equal("XL", conversionService.Convert("5"));
        Assert.Equal("XXL", conversionService.Convert("8"));
        Assert.Equal("", conversionService.Convert("0.1"));
        Assert.Equal("", conversionService.Convert("100"));
    }

}