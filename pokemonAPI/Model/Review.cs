namespace pokemonAPI.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        //One to one
        //Uma review tem um Reviewr
        public Reviewer Reviewer { get; set; }
        //uma review é para um pokemon
        public Pokemon Pokemon { get; set; }
    }
}
