using System;
using System.Collections.Generic;

public class SuperUser : Person
{
    public SuperUser(string naam) : base(naam)
    {
    }

    
    public void AddFriend(Person person)
    {
        if (person == null || Friends.Contains(person))
        {
            Console.WriteLine("Cannot add friend: null or already in list.");
            return;
        }
        Friends.Add(person);
        Console.WriteLine($"{Naam} added {person.Naam} as a friend.");
    }

    
    public void RemoveFriend(Person person)
    {
        if (Friends.Remove(person))
        {
            Console.WriteLine($"{Naam} removed {person.Naam} from friends.");
        }
        else
        {
            Console.WriteLine("Friend not found.");
        }
    }

    
    public void CreatePlaylist(string title)
    {
        Playlist newPlaylist = new Playlist(this, title);
        Playlists.Add(newPlaylist);
        Console.WriteLine($"{Naam} created playlist: {title}");
    }

    
    public void RemovePlaylist(int index)
    {
        if (index >= 0 && index < Playlists.Count)
        {
            Console.WriteLine($"{Naam} removed playlist: {Playlists[index].Title}");
            Playlists.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Invalid playlist index.");
        }
    }

    
}
