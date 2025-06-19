using static spotivy_app.spotivy.Constants;

namespace spotivy_app.spotivy
{
    public class Song : IPlayable
    {
        public string Title { get; set; }
        public List<Artist> Artists { get; set; }
        public Genre Genre { get; set; }
        public int Length { get; set; }

        private bool Paused = false;
        private bool Playing = true;

        public Song(string title, List<Artist> artists, Genre genre, int length)
        {
            Title = title;
            Artists = artists;
            Genre = genre;
            Length = length;
        }

        public void Play()
        {
            CancellationTokenSource CancellationToken = new();
            Task animationTask = Task.Run(async () =>
            {
                string[] animation = { "..  ", " .. ", "  ..", ".  ." };
                string artistNames = string.Join("\n", Artists.Select(a => "- " + a.ToString()));
                Console.WriteLine("");
                Messenger.SendMessage($"Playing song: {Title}\nBy:\n{artistNames}\nGenre: {Genre}");
                for (int i = 0;  i <= Length * 4; i++)
                {
                    if (!Playing)
                        break;

                    if (Paused)
                    {
                        while (Paused && Playing)
                        {
                            await Task.Delay(100, CancellationToken.Token);
                        }
                        if (!Playing) break;
                    }

                    Console.Write($"\r{animation[i % animation.Length]} - {TimeFormatter.FormatTime(i / 4)}");
                    await Task.Delay(250, CancellationToken.Token);
                }
                Stop();
            }, CancellationToken.Token);
        }
        public void Pause()
        {
            Paused = true;
            Console.Write("\r \r");
            Messenger.SendMessage($"Paused song: " + Title);
        }
        public void Continue()
        {
            Paused = false;
        }

        public void Next()
        {
            Playing = false;
            Console.Write("\r \r");
            Messenger.SendMessage("Skipping to next song.");
        }
        public void Stop()
        {
            Playing = false;
            Console.WriteLine("");
            Messenger.SendMessage($"Stopped song:" + Title);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
