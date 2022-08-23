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
        Assert.Equal("9", conversionService.Convert("L"));
        Assert.Equal("27", conversionService.Convert("XL"));
        Assert.Equal("81", conversionService.Convert("XXL"));
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
        Assert.Equal("L", conversionService.Convert("9"));
        Assert.Equal("XL", conversionService.Convert("27"));
        Assert.Equal("XXL", conversionService.Convert("81"));
        Assert.Equal("", conversionService.Convert("0.1"));
        Assert.Equal("", conversionService.Convert("100"));
    }
    
    
}