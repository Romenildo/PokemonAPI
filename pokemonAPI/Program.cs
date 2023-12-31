using Microsoft.EntityFrameworkCore;
using pokemonAPI;
using pokemonAPI.Data;
using pokemonAPI.Interfaces;
using pokemonAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//desnecessario � so para injetar os dados iniciais no banco de dados
builder.Services.AddTransient<Seed>();

//Automapper � necessario isntalar a dependencia de inje��o de dependencia no nugget do automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Inje��es de dependencias das interfaces dos repositorios
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewerRepository, ReviewerRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

//--------------------
//desnecessario � so para criar o banco com alguns dados j� pre definitos
//antes do app iniciar ele injetar os valores da SEED e j� cria uma tabela com alguns pokemons e donos

//para executar com isso � necessario executar a partir do prompt: dotnet run seeddata
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
