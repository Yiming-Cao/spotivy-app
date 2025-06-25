using spotivy_app.spotivy;
using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Naam { get; set; }
    public List<Person> Friends { get; private set; }
    public List<Playlist> Playlists { get; private set; }

    public Person(string naam)
    {
        Naam = naam;
        Friends = new List<Person>();
        Playlists = new List<Playlist>();
    }

    public List<Person> ShowFriends()
    {   

        string friendNames = string.Join("\n", Friends.Select(a => "- " + a.ToString()));
        Messenger.SendMessage($"{Naam}'s Friends:\n"+friendNames);
        return Friends;
    }


    public List<Playlist> ShowPlaylists()
    {
        string playlistNames = string.Join("\n", Playlists.Select(a => "- " + a.ToString()));
        Messenger.SendMessage($"{Naam}'s Playlists:\n"+playlistNames);
        return Playlists;
    }

    public Playlist SelectPlaylist(int index)
    {
        if (index >= 0 && index < Playlists.Count)
        {
            return Playlists[index];
        }
        Messenger.SendMessage("Invalid playlist index.");
        return null;
    }

    public override string ToString()
    {
        return Naam;
    }
}
