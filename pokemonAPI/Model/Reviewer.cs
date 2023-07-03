namespace pokemonAPI.Model
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //ont to many
        //um reviewr pode ter varias reviews
        public ICollection<Review> Reviews { get; set;}
    }
}
