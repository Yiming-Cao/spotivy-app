using spotivy_app.spotivy;

public class SongCollection : IPlayable
{
    public string Title { get; protected set; }
    public List<IPlayable> playables { get; set; } = new List<IPlayable>();

    protected int songIndex = 0;

    public SongCollection(string title)
    {
        Title = title;
    }

    public virtual List<IPlayable> ShowPlayables()
    {
        return playables;
    }

    public virtual void Play()
    {
        playables[songIndex]?.Play();
    }

    public virtual void Pause()
    {
        playables[songIndex]?.Pause();
    }

    public virtual void Stop()
    {
        playables[songIndex]?.Stop();
    }

    public void Next()
    {
        playables[songIndex]?.Next();

        if (playables.Count > 0)
        {
            songIndex++;
            if (playables[songIndex] == null) Messenger.SendMessage("All songs played");
            songIndex = 0;
        }
    }

    public int Length
    {
        get
        {
            int totalLength = 0;
            foreach (var playable in playables)
            {
                totalLength += playable.Length;
            }
            return totalLength;
        }
    }

    public override string ToString()
    {
        return Title;
    }
}

