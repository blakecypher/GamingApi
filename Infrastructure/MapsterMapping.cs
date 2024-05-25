using GamingApi.Model;
using Mapster;

namespace Infrastructure
{
    public class MapsterMapping : IMapseterMapper
    {
        public static void Map()
        {
            TypeAdapterConfig<GameInfo, GameItem>.NewConfig()
                .Map(dest => dest.Id, src => src.AppId)
                .Map(dest => dest.ReleaseDate, src => src.ReleaseDate)
                .Map(dest => dest.RequiredAge, src => src.RequiredAge)
                .Map(dest => dest.Platforms, src => src.Platforms);
        }

        public Task<GameSummary> ConvertToSummary(GameInfo[]? games)
        {
            var summaryItems = (from game in games
                select game.Adapt<GameItem>()).ToList();

            return Task.FromResult(new GameSummary
            {
                Items = summaryItems.ToArray(),
                TotalItems = summaryItems.Count
            });
        }
    }

    public interface IMapseterMapper
    {
        Task<GameSummary> ConvertToSummary(GameInfo[]? sourceGames);
    }
}
