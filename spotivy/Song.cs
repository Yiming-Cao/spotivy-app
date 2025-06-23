using static spotivy_app.spotivy.Constants;

namespace spotivy_app.spotivy
{
    public class Song : IPlayable
    {
        public string Title { get; set; }
        public List<Artist> Artists { get; set; }
        public Genre Genre { get; set; }
        public int Length { get; set; }

        public Song(string title, List<Artist> artists, Genre genre, int length)
        {
            Title = title;
            Artists = artists;
            Genre = genre;
            Length = length;
        }

        public void Play()
        {
            string artistNames = string.Join("\n", Artists.Select(a => "- "+a.ToString()));
            Messenger.SendMessage("Playing song: " + Title + "\n By:\n"+ artistNames+ "\nGenre: "+Genre);
        }
        public void Pause()
        {
            Messenger.SendMessage($"Paused song: " + Title);
        }
        public void Next()
        {
            Messenger.SendMessage("Skipping to next song.");
        }
        public void Stop()
        {
            Messenger.SendMessage($"Stopped song:" + Title);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
