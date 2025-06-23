using spotivy_app.spotivy;
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
        Messenger.SendMessage($"Added to playlist '{Title}': {playable}");
    }

    public void Remove(IPlayable playable)
    {
        if (playables.Remove(playable))
        {
            Messenger.SendMessage($"Removed from playlist '{Title}': {playable}");
        }
        else
        {
            Messenger.SendMessage("Playable not found in playlist.");
        }
    }

    public override string ToString()
    {
        return $"Playlist: {Title}, Owner: {Owner.Naam}, Songs: {playables.Count}";
    }
}
