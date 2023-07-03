using System.Reflection.Emit;

namespace pokemonAPI.Model
{
    public class PokemonOwner
    {
        //tabela join do many to many
        //manter a tabela com todas as relacoes de pokemon e dono
        //  1  2 red charizard
        //  1  3 red chicorita
        // uma tabela com muitos para muitos, ao puxar o com id 1 do red ira trazer todos seus pokemons
        // ou trazer o pokemon 2 ira retornar todos os donos que possui um charizard
        // Dono tem varios pokemons
        // pokemon tem varios donos
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public Pokemon Pokemon { get; set; }
        public Owner Owner { get; set; }
    }
}
