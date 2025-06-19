using spotivy_app.spotivy;

public class SongCollection : IPlayable
{
    public string Title { get; protected set; }
    protected List<IPlayable> playables = new List<IPlayable>();
    protected IPlayable CurrentSong;

    public SongCollection(string title)
    {
        Title = title;
        CurrentSong = playables.FirstOrDefault();
    }

    public virtual List<IPlayable> ShowPlayables()
    {
        return playables;
    }

    public virtual void Play()
    {
        CurrentSong?.Play();
    }

    public virtual void Pause()
    {
        CurrentSong?.Pause();
    }

    public virtual void Stop()
    {
        CurrentSong?.Stop();
    }

    public void Next()
    {
        CurrentSong?.Next();
        playables.Remove(CurrentSong);

        if (playables.Count > 0)
        {
            CurrentSong = playables.FirstOrDefault();
        }
        else
        {
            CurrentSong = null;
            Messenger.SendMessage("All songs played");
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

