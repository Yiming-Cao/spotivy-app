using System.Collections.Generic;

public class SongCollection : IPlayable
{
    public string Title { get; protected set; }
    protected List<IPlayable> playables = new List<IPlayable>();

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
        Console.WriteLine($"Playing collection: {Title}");
        foreach (var playable in playables)
        {
            playable.Play();
        }
    }

    public virtual void Pause()
    {
        Console.WriteLine($"Paused collection: {Title}");
    }

    public virtual void Stop()
    {
        Console.WriteLine($"Stopped collection: {Title}");
    }

    public void Next()
    {
        Console.WriteLine($"Skipping to the next item in collection: {Title}");
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

