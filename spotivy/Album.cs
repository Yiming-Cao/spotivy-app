namespace spotivy_app.spotivy
{
    public class Album : SongCollection
    {
        public List<Artist> Artists { get; set; }

        public Album(List<Artist> artists, string title, List<Song> songs) : base(title)
        {
            Artists = artists;
        }

        public List<Artist> ShowArtists()
        {
            return Artists;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
