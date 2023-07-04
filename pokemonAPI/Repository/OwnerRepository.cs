using pokemonAPI.Data;
using pokemonAPI.Interfaces;
using pokemonAPI.Model;

namespace pokemonAPI.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;
        public OwnerRepository(DataContext context) 
        {
            _context= context;
        }
        public Owner GetOwner(int id)
        {
            return _context.Owners.Where(o => o.Id == id).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
        {
            //A partir da tabela de manyTomany seleciona todos os pokemons que tem o ID passado, então retorna os Donos com aquele ID
            return _context.PokemonOwners.Where(po=> po.Pokemon.Id == pokeId).Select(po => po.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            //A partir da tabela many to many seleciona todos os donos com o ID passado, entao retorna a lista de pokemons
            /*
                    TABELA MANY TO MANY
                    1  2   Ken charizard
                    1  1   Ken charmander
                    2  5   Red Vaporeon
                    2  9   Red Poliwhil

            Ao passar o o id 2 do dono Red, irá filtrar e retornar somente
                    2  5   Red Vaporeon
                    2  9   Red Poliwhil
            Em seguida o select traz somente os pokemons dessa lista que é os com dono 2 Red
                    {Vaporeon, Poliwhil}
             
             */
            return _context.PokemonOwners.Where(po=>po.Owner.Id == ownerId).Select(po => po.Pokemon).ToList();
        }

        public bool OwnerExists(int id)
        {
            return _context.Owners.Any(o => o.Id == id);
        }
    }
}
