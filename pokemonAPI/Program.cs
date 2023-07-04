using Microsoft.EntityFrameworkCore;
using pokemonAPI;
using pokemonAPI.Data;
using pokemonAPI.Interfaces;
using pokemonAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//desnecessario é so para injetar os dados iniciais no banco de dados
builder.Services.AddTransient<Seed>();

//Injeções de dependencias das interfaces dos repositorios
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

//--------------------
//desnecessario é so para criar o banco com alguns dados já pre definitos
//antes do app iniciar ele injetar os valores da SEED e já cria uma tabela com alguns pokemons e donos

//para executar com isso é necessario executar a partir do prompt: dotnet run seeddata
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}
//---------------------------------

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
