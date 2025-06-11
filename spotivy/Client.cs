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

    public Client(List<Person> users, List<Album> albums, List<Song> songs)
    {
        AllUsers = users;
        AllAlbums = albums;
        AllSongs = songs;
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

    public void ShowAllAlbums()
    {
        Console.WriteLine("All Albums:");
        for (int i = 0; i < AllAlbums.Count; i++)
        {
            Console.WriteLine($"{i}: {AllAlbums[i].ToString()}");
        }
    }

    public void SelectAlbum(int index)
    {
        if (index >= 0 && index < AllAlbums.Count)
        {
            CurrentlyPlaying = AllAlbums[index];
            Console.WriteLine($"Selected Album: {AllAlbums[index].Title}");
        }
    }

    public void ShowAllSongs()
    {
        Console.WriteLine("All Songs:");
        foreach (var song in AllSongs)
        {
            Console.WriteLine($"- {song.Title}");
        }
    }

    public void SelectSong(int index)
    {
        if (index >= 0 && index < AllSongs.Count)
        {
            CurrentlyPlaying = AllSongs[index];
            Console.WriteLine($"Selected Song: {AllSongs[index].Title}");
        }
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
            var playlist = ActiveUser.SelectPlaylist(index);
            if (playlist != null)
            {
                Console.WriteLine($"Selected Playlist: {playlist.Title}");
            }
            else
            {
                Console.WriteLine("Invalid playlist index.");
            }
        }
    }

    public void Play()
    {
        if (CurrentlyPlaying != null)
        {
            Playing = true;

            string title = "Unknown";
            if (CurrentlyPlaying is Album album)
            {
                title = album.Title;
            }
            else if (CurrentlyPlaying is Song song)
            {
                title = song.Title;
            }

            Console.WriteLine($"Playing: {title}");
            CurrentlyPlaying.Play();
        }
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
        if (ActiveUser != null)
        {
            // Fix: Provide an index argument to SelectPlaylist
            Playlist currentPlaylist = ActiveUser.SelectPlaylist(0); // Assuming index 0 for demonstration
            if (currentPlaylist != null)
            {
                var list = currentPlaylist.ShowPlayables(); // Get playable items
                if (list.Count == 0) return;

                int index = list.IndexOf(CurrentlyPlaying);
                int nextIndex = (index + 1) % list.Count;

                if (Shuffle)
                {
                    Random random = new Random(); // Ensure Random is instantiated
                    nextIndex = random.Next(list.Count); // Shuffle playback
                }

                CurrentlyPlaying = list[nextIndex];

                string title = CurrentlyPlaying is Song song ? song.Title :
                               CurrentlyPlaying is Album album ? album.Title : "Unknown";

                Console.WriteLine($"Next: {title}");
                Play(); // Play the next item
            }
            else
            {
                Console.WriteLine("No playlist selected.");
            }
        }
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
        if (ActiveUser != null)
        {
            var playlist = ActiveUser.SelectPlaylist(index);
            if (playlist != null)
            {
                Console.WriteLine($"Selected playlist: {playlist.Title}");
            }
            else
            {
                Console.WriteLine("Invalid playlist index.");
            }
        }
    }

    public void RemovePlaylist(int index)
    {
        ActiveUser?.RemovePlaylist(index);
    }

    // 关键点：AddToPlaylist 需要传入playlistIndex和songIndex，因为Client没有存selectedPlaylist字段
    public void AddToPlaylist(int playlistIndex, int songIndex)
    {
        if (ActiveUser == null)
        {
            Console.WriteLine("No active user.");
            return;
        }

        var playlist = ActiveUser.SelectPlaylist(playlistIndex);
        if (playlist == null)
        {
            Console.WriteLine("Invalid playlist index.");
            return;
        }

        if (songIndex < 0 || songIndex >= AllSongs.Count)
        {
            Console.WriteLine("Invalid song index.");
            return;
        }

        IPlayable song = AllSongs[songIndex];

        // 调用SuperUser的AddToPlaylist(IPlayable)方法
        ActiveUser.AddToPlaylist(song);
        string title = "(unknown title)";
        if (song is Song s)
        {
            title = s.Title;
        }

        Console.WriteLine($"Added song {title} to playlist {playlist.Title}");
    }

    // 显示播放列表里的歌曲
    public void ShowSongsInPlaylist(int playlistIndex)
    {
        if (ActiveUser == null)
        {
            Console.WriteLine("No active user.");
            return;
        }

        var playlist = ActiveUser.SelectPlaylist(playlistIndex);
        if (playlist == null)
        {
            Console.WriteLine("Invalid playlist index.");
            return;
        }

        Console.WriteLine($"Songs in playlist {playlist.Title}:");
        foreach (var playable in playlist.ShowPlayables())
        {
            Console.WriteLine($"- {playable}");
        }
    }

    public void RemoveFromPlaylist(int playlistIndex, int songIndex)
    {
        if (ActiveUser == null)
        {
            Console.WriteLine("No active user.");
            return;
        }

        var playlist = ActiveUser.SelectPlaylist(playlistIndex);
        if (playlist == null)
        {
            Console.WriteLine("Invalid playlist index.");
            return;
        }

        var playables = playlist.ShowPlayables();
        if (songIndex < 0 || songIndex >= playables.Count)
        {
            Console.WriteLine("Invalid song index.");
            return;
        }

        IPlayable playable = playables[songIndex];
        playlist.Remove(playable);
        ActiveUser.RemoveFromPlaylist(playable);
        Console.WriteLine($"Removed {playable} from playlist {playlist.Title}");
    }

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

    public void SelectFriend(int index)
    {
        Console.WriteLine("SelectFriend by index not implemented in Client.");
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
