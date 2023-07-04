namespace pokemonAPI.Dtos
{
    /*
        Os Dto(Data transfer Object) além de ajudar na segurança dos dados como intermedio entre o usuario e a API
    Ela filtra as informações desnecessarias que não precisariamos retornar para o usuario, ao inves de todas as collections de pokemon tem no model
    O Dto irá retornar para o usuario somente o necessario naquele determinado DTO.
     */
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
