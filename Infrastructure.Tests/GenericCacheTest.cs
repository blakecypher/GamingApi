using GamingApi.Model;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Infrastructure;
using Xunit;

public class GenericCacheTests
{
    [Fact]
    public void Constructor_WhenCacheIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        IMemoryCache? cache = null;
        IConfiguration? config = new ConfigurationBuilder().Build();
        
        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => new GenericCache<GameInfo[]>(cache, config));
    }
    
    [Fact]
    public void Constructor_WhenConfigIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        using IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());
        IConfiguration? config = null;
        
        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => new GenericCache<GameInfo[]>(cache, config));
    }
    
    [Fact]
    public void Constructor_WhenCacheExpiryMinutesIsNotValidInteger_ShouldThrowFormatException()
    {
        // Arrange
        using IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());
        IConfiguration? config = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string>
        {
            { "cache_expiry_minutes", "abc" }
        }).Build();
        
        // Act and Assert
        Assert.Throws<FormatException>(() => new GenericCache<GameInfo[]>(cache, config));
    }
    
    [Fact]
    public void Constructor_WhenAllInputsAreValid_ShouldSetCacheOptions()
    {
        // Arrange
        IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());
        IConfiguration? config = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string>
        {
            { "cache_expiry_minutes", "5" }
        }).Build();
        
        // Act
        using var genericCache = new GenericCache<GameInfo[]>(cache, config);
        
        // Assert
        Assert.NotNull(genericCache.cacheOptions);
    }
}