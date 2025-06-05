using System;

public class Playlist : SongCollection
{
    public Person Owner { get; private set; }

    public Playlist(Person owner, string title) : base(title)
    {
        Owner = owner;
    }

    
}
