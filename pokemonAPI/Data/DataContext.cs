using Microsoft.EntityFrameworkCore;
using pokemonAPI.Model;

namespace pokemonAPI.Data
{
    public class DataContext: DbContext
    {
        /*
            O Entity framework é o ORM(Object-Relacional Mapper) ele faz o mapeamento das classes criadas no Model
          para o formato do banco de dados. O objeto com variaveis para as colunas no banco de dados


            O DBContext mantém todo o contexto dessas tabelas e as manipula, a injecção de dependencia dele da a maioria
        das funções necessarias para manipular a tabela como add, update, get, delete...
         */
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {
        
        }

        /*
            DbSet São todas as tabelas que o contexto irá criar, cada entidade deve posssuir a sua tabela e assim podendo ter
        as funções para manipular a mesma.
         */

        //Cada DbSet é uma tabela diferente que o ORM irá criar
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> reviewers { get; set; }

        /*
            Reescrever a função da ORM no momento que for mapear seguir os detalhes definitos na função
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Pokemon Category Many to many
            //chave
            modelBuilder.Entity<PokemonCategory>()
                 .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            //um pokemon tem varias categorias
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(p => p.PokemonId);
            // e uma categoria tem varios pokemons
            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.CategoryId);

            //Pokemon Owner Many to many
            modelBuilder.Entity<PokemonOwner>()
                 .HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(po => po.PokemonOwners)
                .HasForeignKey(p => p.OwnerId);
            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Owner)
                .WithMany(po => po.PokemonOwners)
                .HasForeignKey(c => c.PokemonId);
        }

        /*
         Apos criar isso entra as migrations
        O Entity framework utiliza o Code First: voce deve gerar todo o codigo com as entidades e atributos para ai então
        mandar o ORM criar as migrations,q ue é o codigo que criará todo o comando para criar as tabelas no banco de dados.

        Então, apos tudo configurado deve executar os comandos no console do gerenciador de pacotes:

        PM> Add-Migration nomeDaMigration(InitialMigration)
        ou no prompt: dotnet ef migrations add InitialMigration --- dentro da pasta do projeto

        para desfazer: dotnet ef migrations remove
        +
         */
    }
}
