using GamingApi.Model;

namespace GamingApi.GamingService;

public interface IGamingService
{
    /// <summary>
    /// OCP - We don't want to expose the Caching mechanism or Summary filtering.
    /// All we care about is the results.
    /// </summary>
    /// <param name="offset"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    Task<(int TotalItems, GameSummary summary)> Get(int offset, int limit);
}