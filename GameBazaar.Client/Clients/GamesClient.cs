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
            Genre genre = GetGenreById(game.GenreId);
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



        public GameDetails GetGame(int id)
        {
            Game game = GetGameSummaryById(id);

            var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

            return new GameDetails
            {
                Id = game.Id,
                Name = game.Name,
                GenreId = genre.Id.ToString(),
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
            };


        }

        public void UpdateGame(GameDetails updateGame)
        {
            var genre = GetGenreById(updateGame.GenreId);
            Game existingGame = GetGameSummaryById(updateGame.Id);

            existingGame.Name = updateGame.Name;
            existingGame.Genre = genre.Name;
            existingGame.Price = updateGame.Price;
            existingGame.ReleaseDate = updateGame.ReleaseDate;
        }

        public void DeleteGame(int id)
        {
            var game = GetGameSummaryById(id);
            games.Remove(game);
        }

        private Game GetGameSummaryById(int id)
        {
            Game? game = games.Find(game => game.Id == id);
            ArgumentNullException.ThrowIfNull(game);
            return game;
        }

        private Genre GetGenreById(string? id)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(id);
            return genres.Single(genre => genre.Id == int.Parse(id));

        }
    }


}
