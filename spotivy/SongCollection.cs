using System.Collections.Generic;

public class SongCollection
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

    public override string ToString()
    {
        return "SongCollection: " + Title + ", Items: " + playables.Count;
    }
}
