using AutoMapper;
using pokemonAPI.Dtos;
using pokemonAPI.Model;

namespace pokemonAPI.Helper
{
    /*
        É necessario instalar a dependencia do automapper e de injecção de dependencia no nugget
    Então herdar a classe de profile do automaper que configura todas as entidades qeu queremos transformar para um Dto.

    Em seguida em program.cs e instancialos lá
     */
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
        }
    }
}
