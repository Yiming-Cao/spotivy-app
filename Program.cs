using spotivy_app.spotivy;
using static spotivy_app.spotivy.Constants;

namespace spotivy_app
{
    internal class Program
    {
        static Client client;
        static Dictionary<string, SuperUser> userCache = new Dictionary<string, SuperUser>();


        static void Main(string[] args)
        {
            List<Person> users = new List<Person>() 
            {
                new Person("Thomas"),
                new Person("Yiming"),
                new Person("Robert")
            };

            var artist1 = new Artist("Ed Sheeran", new List<Album>());
            var artist2 = new Artist("The Weeknd", new List<Album>());
            var artist3 = new Artist("Adele", new List<Album>());

            List<Song> songs = new List<Song>()
            {
                new Song("Shape of You", new List<Artist> { artist1 }, Genre.Pop, 3),
                new Song("Blinding Lights", new List<Artist> { artist2 }, Genre.Pop, 4),
                new Song("Someone Like You", new List<Artist> { artist3 }, Genre.Pop, 5)
            };

                        List<Album> albums = new List<Album>()
            {
                new Album(new List<Artist> { artist1, artist2 }, "Top Hits", new List<Song> { songs[0], songs[1] }),
                new Album(new List<Artist> { artist3 }, "Emotional", new List<Song> { songs[2] })
            };

            client = new Client(users, albums, songs);

            Messenger.SendMessage("Welcome to Spotivy! This is a simple app to play music, built with C#!");

            var options = users
                .Select(su => new Option { Label = su.Naam, Action = () => Login(su) })
                .ToArray();

            Messenger.OptionBox("Login", options);
        }

        public static void Login(Person user)
        {
            SuperUser superUser;

            if (!userCache.ContainsKey(user.Naam))
            {
                superUser = new SuperUser(user.Naam);
                userCache[user.Naam] = superUser;
            }
            else
            {
                superUser = userCache[user.Naam];
            }

            client.SetActiveUser(superUser);
            Messenger.SendMessage($"Already logged in as: {client.ActiveUser.Naam}");
            client.ActiveUser.ShowFriends();
            client.ActiveUser.ShowPlaylists();
            ShowMainMenu();
        }

        public static void ShowListWithIndex<T>(List<T> list, string header = null)
        {
            if (!string.IsNullOrEmpty(header))
                Messenger.SendMessage(header);

            for (int i = 0; i < list.Count; i++)
            {
                Messenger.SendMessage($"{i}. {list[i]}");
            }
        }


        static void ShowMainMenu()
        {
            while (true)
            {
                Messenger.SendMessage(
                    "\nOptions:\n" +
                    "1. Add friends\n" +
                    "2. Remove friends\n" +
                    "3. Create playlist\n" +
                    "4. Remove playlist\n" +
                    "5. Add music to playlist\n" +
                    "6. Remove music from playlist\n" +
                    "0. Logout"
                );

                string input = Console.ReadLine();
                if (input == "0")
                {
                    Messenger.SendMessage("Logged out.");
                    Main(null); // 返回登录界面
                    return;
                }

                var superUser = client.ActiveUser as SuperUser;
                if (superUser == null)
                {
                    Messenger.SendMessage("You are not a superuser.");
                    return;
                }

                switch (input)
                {
                    case "1":
                        ShowListWithIndex(client.AllUsers, "All users:");
                        Messenger.SendMessage("Enter the number of the friend to add:");

                        if (int.TryParse(Console.ReadLine(), out int friendIndex))
                        {
                            if (friendIndex >= 0 && friendIndex < client.AllUsers.Count)
                            {
                                var selected = client.AllUsers[friendIndex];
                                if (selected.Naam == superUser.Naam)
                                {
                                    Messenger.SendMessage("Cannot add yourself.");
                                }
                                else if (superUser.Friends.Contains(selected))
                                {
                                    Messenger.SendMessage("Friend already added.");
                                }
                                else
                                {
                                    superUser.AddFriend(selected);
                                    Messenger.SendMessage("Friend added.");
                                }
                            }
                        }
                        break;

                    case "2":
                        ShowListWithIndex(superUser.Friends, "Your friends:");
                        Messenger.SendMessage("Enter the number of the friend to remove:");

                        if (int.TryParse(Console.ReadLine(), out int removeIndex))
                        {
                            if (removeIndex >= 0 && removeIndex < superUser.Friends.Count)
                            {
                                superUser.RemoveFriend(superUser.Friends[removeIndex]);
                                Messenger.SendMessage("Friend removed.");
                            }
                        }
                        break;

                    case "3":
                        Messenger.SendMessage("Enter a name for the new playlist:");
                        string title = Console.ReadLine();
                        superUser.CreatePlaylist(title);
                        break;

                    case "4":
                        ShowListWithIndex(superUser.Playlists, "Your playlists:");
                        Messenger.SendMessage("Enter the number of the playlist to remove:");
                        if (int.TryParse(Console.ReadLine(), out int playlistIndex))
                        {
                            if (playlistIndex >= 0 && playlistIndex < superUser.Playlists.Count)
                            {
                                superUser.RemovePlaylist(playlistIndex);
                                Messenger.SendMessage("Playlist removed.");
                            }
                        }
                        break;

                    case "5":
                        ShowListWithIndex(superUser.Playlists, "Your playlists:");
                        Messenger.SendMessage("Enter the number of the playlist:");

                        if (int.TryParse(Console.ReadLine(), out int plIndex))
                        {
                            if (plIndex >= 0 && plIndex < superUser.Playlists.Count)
                            {
                                ShowListWithIndex(client.AllSongs, "All songs:");
                                Messenger.SendMessage("Enter the number of the song to add:");
                                if (int.TryParse(Console.ReadLine(), out int songIndex))
                                {
                                    if (songIndex >= 0 && songIndex < client.AllSongs.Count)
                                    {
                                        superUser.Playlists[plIndex].Add(client.AllSongs[songIndex]);
                                        Messenger.SendMessage("Song added to playlist.");
                                    }
                                }
                            }
                        }
                        break;

                    case "6":
                        ShowListWithIndex(superUser.Playlists, "Your playlists:");
                        Messenger.SendMessage("Enter the number of the playlist:");
                        if (int.TryParse(Console.ReadLine(), out int plIdx))
                        {
                            if (plIdx >= 0 && plIdx < superUser.Playlists.Count)
                            {
                                var playlist = superUser.Playlists[plIdx];
                                var playables = playlist.ShowPlayables();
                                ShowListWithIndex(playables, $"Songs in playlist \"{playlist.Title}\":");
                                Messenger.SendMessage("Enter the number of the song to remove:");
                                if (int.TryParse(Console.ReadLine(), out int songIdx))
                                {
                                    if (songIdx >= 0 && songIdx < playables.Count)
                                    {
                                        playlist.Remove(playables[songIdx]);
                                        Messenger.SendMessage("Song removed from playlist.");
                                    }
                                }
                            }
                        }
                        break;

                    default:
                        Messenger.SendMessage("Wrong choice, try again.");
                        break;
                }
            }
        }
    }
}
