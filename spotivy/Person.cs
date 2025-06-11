using System;
using System.Collections.Generic;

public class Person
{
    public string Naam { get; private set; }
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
        Console.WriteLine($"{Naam}'s Friends:");
        foreach (var friend in Friends)
        {
            Console.WriteLine($"- {friend.Naam}");
        }
        return Friends;
    }

    public List<Playlist> ShowPlaylists()
    {
        Console.WriteLine($"{Naam}'s Playlists:");
        foreach (var playlist in Playlists)
        {
            Console.WriteLine($"- {playlist.Title}");
        }
        return Playlists;
    }

    public Playlist SelectPlaylist(int index)
    {
        if (index >= 0 && index < Playlists.Count)
        {
            return Playlists[index];
        }
        Console.WriteLine("Invalid playlist index.");
        return null;
    }

    public override string ToString()
    {
        return Naam;
    }
}
