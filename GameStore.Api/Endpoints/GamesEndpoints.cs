using GameStore.Api.Dtos;

namespace GameStore.Api.endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = 
    [
        new (
            1,
            "Street Fighter II",
            "Fighting",
            19.99m,
            new DateOnly(1992, 7, 15)
            ),
        new (
            2,
            "Pac-Man",
            "Arcade",
            12.99m,
            new DateOnly(1980, 5, 22)
            ),
        new (
            3,
            "Need for Speed: Most Wanted",
            "Racing",
            29.99m,
            new DateOnly(2005, 11, 15)
            )
    ];

    public static void MapGameEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("/games");

        // GET /games
        group.MapGet("/", () => games);



        // GET /games/id
        group.MapGet("/{id}", (int id) => 
        {
            var game = games.Find(game => game.Id == id);

            if (game == null)
                return Results.NotFound();

            else
                return Results.Ok(game);
            
        })
            .WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("/", (CreateGameDto newGame) =>
        {

            

            GameDto game = new (
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
        });

        // PUT /games/id
        group.MapPut("/{id}", (int id, UpdateGameDto updateGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);
            
            if (index == -1)
                    return Results.NotFound();   
                    
            games[index] = new GameDto(
                    id,
                    updateGame.Name,
                    updateGame.Genre,
                    updateGame.Price,
                    updateGame.ReleaseDate
                );

            return Results.NoContent();
        });

        // DELETE /games/id
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });
    }
}
