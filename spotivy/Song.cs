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
            CancellationTokenSource CancellationToken = new();
            bool playing = true;
            Task animationTask = Task.Run(async () =>
            {
                string[] animation = { "..  ", " .. ", "  ..", ".  ." };
                string artistNames = string.Join("\n", Artists.Select(a => "- " + a.ToString()));
                Messenger.SendMessage($"Playing song: {Title}\nBy:\n{artistNames}\nGenre: {Genre}");
                for(int i = 0; i <= Length*4; i++)
                {
                    Console.Write($"\r{animation[i % animation.Length]} - {TimeFormatter.FormatTime(i / 4)}");
                    await Task.Delay(250, CancellationToken.Token);
                }

                CancellationToken.Cancel();
                playing = false;
                Console.WriteLine("");
                Messenger.SendMessage($"Finished playing song: {Title}");
            }, CancellationToken.Token);

            while (playing)
            {
                string? input = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop-1);
                if (input?.ToLower() == "skip")
                {
                    CancellationToken.Cancel();
                    Next();
                    break;
                }
                else if (input?.ToLower() == "stop")
                {
                    CancellationToken.Cancel();
                    Stop();
                    break;
                }
            }
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
