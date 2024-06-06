using SharedLibrary.Models;

namespace GameBazaar.Client.Clients
{
    public class GamesClient
    {
        private readonly List<Game> games = new()
            {
        new Game()
        {
            Id = 1 ,
            Name = "Street Fighter II",
            Genre ="Fighting",
            Price = 19.99M,
            ReleaseDate = new DateTime(1999,2,1)

        },
         new Game()
        {
            Id = 2 ,
            Name = "Final Fantasy XIV",
            Genre ="Roleplaying",
            Price = 59.99M,
            ReleaseDate = new DateTime(2010,9,30)


        },
        new Game()
        {
            Id = 3 ,
            Name = "FIFA 23 ",
            Genre ="Sports",
            Price = 69.99M,
            ReleaseDate = new DateTime(2022,9,27)

        },
    };
        private readonly Genre[] genres = new GenresClient().GetGenres();

        public Game[] GetGames() => [.. games];

        public void AddGame(GameDetails game)
        {

            ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
            var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));
            var gameSummary = new Game
            {
                Id = games.Count + 1,
                Name = game.Name,
                Genre = genre.Name,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,

            };

            games.Add(gameSummary);
        }
    }
}
