using spotivy_app.spotivy;
using System;
using System.Collections.Generic;

public class Client
{
    public IPlayable CurrentlyPlaying { get; private set; }
    public int CurrentTime { get; private set; }
    public bool Playing { get; private set; }
    public bool Shuffle { get; private set; }
    public bool Repeat { get; private set; }

    public SuperUser ActiveUser { get; private set; }

    public List<Album> AllAlbums { get; private set; }
    public List<Song> AllSongs { get; private set; }
    public List<Person> AllUsers { get; private set; }

    private Random random;
    private Playlist selectedPlaylist;

    public Client(List<Person> users, List<Album> albums, List<Song> songs)
    {
        
    }

    public void SetActiveUser(Person person)
    {
        if (person is SuperUser su)
        {
            ActiveUser = su;
            Console.WriteLine($"Active user set to: {ActiveUser.Naam}");
        }
        else
        {
            Console.WriteLine("Selected user is not a SuperUser.");
        }
    }

    // Album and Song Management
    public void ShowAllAlbums()
    {
        
    }

    public void SelectAlbum(int index)
    {
        
    }

    public void ShowAllSongs()
    {
        
    }

    public void SelectSong(int index)
    {
        
    }

    public void ShowAllUsers()
    {
        Console.WriteLine("All Users:");
        for (int i = 0; i < AllUsers.Count; i++)
        {
            Console.WriteLine($"{i}: {AllUsers[i].Naam}");
        }
    }

    public void SelectUser(int index)
    {
        if (index >= 0 && index < AllUsers.Count)
        {
            SetActiveUser(AllUsers[index]);
        }
    }

    public void ShowUserPlaylists()
    {
        if (ActiveUser != null)
        {
            ActiveUser.ShowPlaylists();
        }
    }

    public void SelectUserPlaylist(int index)
    {
        if (ActiveUser != null)
        {
            selectedPlaylist = ActiveUser.SelectPlaylist(index);
            Console.WriteLine($"Selected Playlist: {selectedPlaylist?.Title}");
        }
    }

    // Playback Controls
    public void Play()
    {
        
    }

    public void Pause()
    {
        if (CurrentlyPlaying != null && Playing)
        {
            Playing = false;
            CurrentlyPlaying.Pause();
            Console.WriteLine("Paused.");
        }
    }

    public void Stop()
    {
        if (CurrentlyPlaying != null)
        {
            Playing = false;
            CurrentTime = 0;
            CurrentlyPlaying.Stop();
            Console.WriteLine("Stopped.");
        }
    }

    public void NextSong()
    {
        
    }

    public void SetShuffle(bool shuffle)
    {
        Shuffle = shuffle;
        Console.WriteLine($"Shuffle: {Shuffle}");
    }

    public void SetRepeat(bool repeat)
    {
        Repeat = repeat;
        Console.WriteLine($"Repeat: {Repeat}");
    }

    // Playlist Management
    public void CreatePlaylist(string title)
    {
        ActiveUser?.CreatePlaylist(title);
    }

    public void ShowPlaylists()
    {
        ActiveUser?.ShowPlaylists();
    }

    public void SelectPlaylist(int index)
    {
        selectedPlaylist = ActiveUser?.SelectPlaylist(index);
    }

    public void RemovePlaylist(int index)
    {
        ActiveUser?.RemovePlaylist(index);
    }

    public void AddToPlaylist(int songIndex)
    {
        
    }

    public void ShowSongsInPlaylist()
    {
        
    }

    public void RemoveFromPlaylist(int songIndex)
    {
        
    }

    // Friend Management
    public void ShowFriends()
    {
        if (ActiveUser != null)
        {
            foreach (var f in ActiveUser.ShowFriends())
            {
                Console.WriteLine($"- {f.Naam}");
            }
        }
    }

    public void SelectFriend()
    {
        Console.WriteLine("Friend selection by index not implemented in this class.");
    }

    public void AddFriend(int index)
    {
        if (index >= 0 && index < AllUsers.Count)
        {
            ActiveUser?.AddFriend(AllUsers[index]);
        }
    }

    public void RemoveFriend(int index)
    {
        if (index >= 0 && index < AllUsers.Count)
        {
            ActiveUser?.RemoveFriend(AllUsers[index]);
        }
    }
}
