namespace pokemonAPI.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //One to many
        //Uma cidade pode ter varios usuarios
        public ICollection<Owner> Owners { get; set;}

    }
}
