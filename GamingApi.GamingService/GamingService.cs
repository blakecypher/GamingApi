using System.Net.Http.Json;
using System.Text.Json;
using GamingApi.Model;
using Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace GamingApi.GamingService;

public class GamingService : IGamingService
{
    private readonly HttpClient httpClient = new();
    private readonly IMapseterMapper mapper;
    private readonly GenericCache<GameInfo[]?> gameCache;
    private readonly string feedUrl;

    public GamingService(
        IConfiguration? config, 
        IMapseterMapper mapper,
        IMemoryCache? gameCache)
    {
        this.mapper = mapper;
        this.feedUrl = config["FeedUrl"];
        this.gameCache = new GenericCache<GameInfo[]?>(gameCache, config);
        var baseUrl = new Uri(config["BaseUrl"]);
        httpClient.BaseAddress = baseUrl;
    }
    public async Task<(int TotalItems, GameSummary summary)> Get(int offset, int limit)
    {
        try
        {
            if (offset < 0)
                throw new ArgumentException("Offset cannot be a negative value");
            switch (limit)
            {
                case < 0:
                    throw new ArgumentException("Limit cannot be a negative value");
                case > 10:
                    throw new ArgumentException("Max limit is 10");
            }
            
            var result = await GetOrFetchGames(feedUrl);

            var games = await GetFilteredGames(result, offset, limit);
            return games;

        }
        catch (ArgumentException ex)
        {
            throw new ArgumentException("Argument exception" + ex);
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Exception" + ex);
        }
    }
    
    private async Task<GameInfo[]?> GetOrFetchGames(string url)
    {
        return await gameCache.GetOrCreate("games", () => FetchGames(url));
    }
    
    private async Task<GameInfo[]?> FetchGames(string url)
    {
        var result = await httpClient.GetFromJsonAsync<GameInfo[]>(
                         requestUri: url,
                         options: new JsonSerializerOptions { IncludeFields = true })!
                     ??
                     throw new Exception("Error retrieving feed");
        return result;
    }

    private async Task<(int TotalItems, GameSummary summary)> GetFilteredGames(GameInfo[]? result, int offset, int limit)
    {

        var summary = await mapper.ConvertToSummary(result);

        if (summary.Items != null)
        {
            var filtered = summary.Items.Skip(offset).Take(limit).ToArray();

            summary.Items = filtered;

            return (summary.TotalItems, summary);
        }

        return (0, null)!;
    }
}