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
        Assert.Equal("2", conversionService.Convert("M"));
        Assert.Equal("5", conversionService.Convert("L"));
        Assert.Equal("13", conversionService.Convert("XL"));
        Assert.Equal("34", conversionService.Convert("XXL"));
        Assert.Equal("<0.5", conversionService.Convert("XXS"));
        Assert.Equal("Project", conversionService.Convert("XXXL"));
        Assert.Equal("", conversionService.Convert(""));
    }

    [Fact]
    public void TestDefaultConvertWithManDays()
    {
        var conversionService = new ConversionService();
        Assert.Equal("XS", conversionService.Convert("0.5"));
        Assert.Equal("S", conversionService.Convert("1"));
        Assert.Equal("M", conversionService.Convert("2"));
        Assert.Equal("L", conversionService.Convert("5"));
        Assert.Equal("XL", conversionService.Convert("13"));
        Assert.Equal("XXL", conversionService.Convert("34"));
        // Closest
        Assert.Equal("XS", conversionService.Convert("0.1"));
        Assert.Equal("Project", conversionService.Convert("100"));
        Assert.Equal("L", conversionService.Convert("6"));
        Assert.Equal("L", conversionService.Convert("8"));
        Assert.Equal("XL", conversionService.Convert("14"));
        Assert.Equal("XXL", conversionService.Convert("55"));
    }

    [Fact]
    public void TestEvenSkippedFibonacciConvertWithShirtSize()
    {
        var conversionService = new ConversionService(f => Incrementation.EvenSkippedFibonacci((int)f));
        Assert.Equal("0.5", conversionService.Convert("XS"));
        Assert.Equal("1", conversionService.Convert("S"));
        Assert.Equal("3", conversionService.Convert("M"));
        Assert.Equal("8", conversionService.Convert("L"));
        Assert.Equal("21", conversionService.Convert("XL"));
        Assert.Equal("55", conversionService.Convert("XXL"));
        Assert.Equal("<0.5", conversionService.Convert("XXS"));
        Assert.Equal("Project", conversionService.Convert("XXXL"));
        Assert.Equal("", conversionService.Convert(""));
    }
    
    [Fact]
    public void TestEvenSkippedFibonacciConvertWithManDays()
    {
        var conversionService = new ConversionService(f => Incrementation.EvenSkippedFibonacci((int)f));
        Assert.Equal("XS", conversionService.Convert("0.5"));
        Assert.Equal("S", conversionService.Convert("1"));
        Assert.Equal("M", conversionService.Convert("3"));
        Assert.Equal("L", conversionService.Convert("8"));
        Assert.Equal("XL", conversionService.Convert("21"));
        Assert.Equal("XXL", conversionService.Convert("55"));
        // Closest
        Assert.Equal("XS", conversionService.Convert("0.1"));
        Assert.Equal("Project", conversionService.Convert("100"));
        Assert.Equal("L", conversionService.Convert("6"));
        Assert.Equal("L", conversionService.Convert("14"));
        Assert.Equal("XL", conversionService.Convert("20"));
    }
    
    [Fact]
    public void TestOddSkippedFibonacciConvertWithShirtSize()
    {
        var conversionService = new ConversionService(f => Incrementation.OddSkippedFibonacci((int)f));
        Assert.Equal("0.5", conversionService.Convert("XS"));
        Assert.Equal("1", conversionService.Convert("S"));
        Assert.Equal("2", conversionService.Convert("M"));
        Assert.Equal("5", conversionService.Convert("L"));
        Assert.Equal("13", conversionService.Convert("XL"));
        Assert.Equal("34", conversionService.Convert("XXL"));
        Assert.Equal("<0.5", conversionService.Convert("XXS"));
        Assert.Equal("Project", conversionService.Convert("XXXL"));
        Assert.Equal("", conversionService.Convert(""));
    }
    
    [Fact]
    public void TestOddSkippedFibonacciConvertWithManDays()
    {
        var conversionService = new ConversionService(f => Incrementation.OddSkippedFibonacci((int)f));
        Assert.Equal("XS", conversionService.Convert("0.5"));
        Assert.Equal("S", conversionService.Convert("1"));
        Assert.Equal("M", conversionService.Convert("2"));
        Assert.Equal("L", conversionService.Convert("5"));
        Assert.Equal("XL", conversionService.Convert("13"));
        Assert.Equal("XXL", conversionService.Convert("34"));
        // Closest
        Assert.Equal("XS", conversionService.Convert("0.1"));
        Assert.Equal("Project", conversionService.Convert("100"));
        Assert.Equal("L", conversionService.Convert("6"));
        Assert.Equal("L", conversionService.Convert("8"));
        Assert.Equal("XL", conversionService.Convert("14"));
        Assert.Equal("XXL", conversionService.Convert("55"));
    }
     
    [Fact]
    public void TestMultipliedByThreeConvertWithShirtSize()
    {
        var conversionService = new ConversionService(Incrementation.ByThree);
        Assert.Equal("0.5", conversionService.Convert("XS"));
        Assert.Equal("1", conversionService.Convert("S"));
        Assert.Equal("3", conversionService.Convert("M"));
        Assert.Equal("9", conversionService.Convert("L"));
        Assert.Equal("27", conversionService.Convert("XL"));
        Assert.Equal("81", conversionService.Convert("XXL"));
        Assert.Equal("<0.5", conversionService.Convert("XXS"));
        Assert.Equal("Project", conversionService.Convert("XXXL"));
        Assert.Equal("", conversionService.Convert(""));
    }
    
    [Fact]
    public void TestMultipliedByThreeConvertWithManDays()
    {
        var conversionService = new ConversionService(Incrementation.ByThree);
        Assert.Equal("XS", conversionService.Convert("0.5"));
        Assert.Equal("S", conversionService.Convert("1"));
        Assert.Equal("M", conversionService.Convert("3"));
        Assert.Equal("L", conversionService.Convert("9"));
        Assert.Equal("XL", conversionService.Convert("27"));
        Assert.Equal("XXL", conversionService.Convert("81"));
        Assert.Equal("XS", conversionService.Convert("0.1"));
        Assert.Equal("XXL", conversionService.Convert("100"));
    }
    
    [Fact]
    public void TestFibonacciConvertWithShirtSize()
    {
        var conversionService = new ConversionService(Incrementation.Fibonacci);
        Assert.Equal("0.5", conversionService.Convert("XS"));
        Assert.Equal("1", conversionService.Convert("S"));
        Assert.Equal("2", conversionService.Convert("M"));
        Assert.Equal("3", conversionService.Convert("L"));
        Assert.Equal("5", conversionService.Convert("XL"));
        Assert.Equal("8", conversionService.Convert("XXL"));
        Assert.Equal("<0.5", conversionService.Convert("XXS"));
        Assert.Equal("Project", conversionService.Convert("XXXL"));
        Assert.Equal("", conversionService.Convert(""));
    }
    
    [Fact]
    public void TestFibonacciConvertWithManDays()
    {
        var conversionService = new ConversionService(Incrementation.Fibonacci);
        Assert.Equal("XS", conversionService.Convert("0.5"));
        Assert.Equal("S", conversionService.Convert("1"));
        Assert.Equal("M", conversionService.Convert("2"));
        Assert.Equal("L", conversionService.Convert("3"));
        Assert.Equal("XL", conversionService.Convert("5"));
        Assert.Equal("XXL", conversionService.Convert("8"));
        Assert.Equal("XS", conversionService.Convert("0.1"));
        Assert.Equal("Project", conversionService.Convert("100"));
    }

}