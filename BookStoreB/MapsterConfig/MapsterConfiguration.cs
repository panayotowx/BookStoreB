using Mapster;
using BookStoreB.Models.DTO;
using BookStoreB.Models.Requests;

namespace BookStoreB.MapsterConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<AddMovieRequest, Movie>
                .NewConfig();
        }
    }
}
