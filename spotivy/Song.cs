using static spotivy_app.spotivy.Constants;

namespace spotivy_app.spotivy
{
    public class Song : IPlayable
    {
        public string Title { get; set; }
        public List<Artist> Artists { get; set; }
        public Constants.Genre SongGenre { get; set; }
        public int Length { get; set; }

        public Song(string title, List<Artist> artists, Constants.Genre genre, int length)
        {
            Title = title;
            Artists = artists;
            SongGenre = genre;
            Length = length;
        }

        public void Play()
        {
            Console.Write("Playing song:" + Title + "by");
            foreach (var artist in Artists)
            {
                Console.Write(artist.ToString());
                if (artist != Artists.Last())
                {
                    Console.Write(".");
                } else Console.WriteLine(", ");
            }
        }
        public void Pause()
        {
            Console.WriteLine($"Paused song: " + Title);
        }
        public void Next()
        {
            Console.WriteLine("Skipping to next song.");
        }
        public void Stop()
        {
            Console.WriteLine($"Stopped song:" + Title);
        }
    }
}
