namespace pokemonAPI.Model
{
    public class PokemonCategory
    {

        //tabela join do many to many
        //manter a tabela com todas as relacoes de pokemon e categoria
        //  1  2 charizard fogo
        //  7  2 charmilion fogo
        // uma tabela com muitos para muitos, ao puxar o com id 2 de fogo ira trazer todos com fogo
        public int PokemonId { get; set; }
        public int CategoryId { get; set; }

        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }
    }
}
