using System;

public class Playlist : SongCollection
{
    public Person Owner { get; private set; }

    public Playlist(Person owner, string title) : base(title)
    {
        Owner = owner;
    }

    public void Add(IPlayable playable)
    {
        playables.Add(playable);
        Console.WriteLine($"Added to playlist '{Title}': {playable}");
    }

    public void Remove(IPlayable playable)
    {
        if (playables.Remove(playable))
        {
            Console.WriteLine($"Removed from playlist '{Title}': {playable}");
        }
        else
        {
            Console.WriteLine("Playable not found in playlist.");
        }
    }

    public override string ToString()
    {
        return $"Playlist: {Title}, Owner: {Owner.Naam}, Songs: {playables.Count}";
    }
}
