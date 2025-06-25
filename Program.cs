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
            Constants constants = new Constants();
            List<Artist> Artists = constants.artists;
            List<Album> Albums = constants.albums;
            List<Song> Songs = Albums.SelectMany(album => album.playables.OfType<Song>()).ToList();
            List<Person> users = new List<Person>()
            {
                new Person("Thomas"),
                new Person("Yiming"),
                new Person("Robert")
            };

            client = new Client(users, Albums, Songs);

            Messenger.SendMessage("Welcome to Spotivy! This is a simple app to play music, built with C#!");
            // 构造登录选项，包括用户和退出选项
            var loginOptions = users
                .Select(su => new Option { Label = su.Naam, Action = () => Login(su) })
                .ToList();

            // 添加退出选项
            loginOptions.Insert(0, new Option
            {
                Label = "Exit Application",
                Action = () =>
                {
                    Messenger.SendMessage("Exiting application...");
                    Environment.Exit(0);
                }
            });

            var playOptions = new List<Option>
            {
                new Option { Label = "Play", Action = () => client.CurrentlyPlaying?.Play() },
                new Option { Label = "Pause", Action = () => client.CurrentlyPlaying?.Pause() },
                new Option { Label = "Stop", Action = () => client.CurrentlyPlaying?.Stop() },
                new Option { Label = "Next Song", Action = () => client.NextSong() },
            }.ToArray();


            Messenger.OptionBox("Login", loginOptions.ToArray(), true);

            client.SelectAlbum(0);
            client.Play();
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


        static void ShowMainMenu()
        {
            var superUser = client.ActiveUser as SuperUser;
            if (superUser == null)
            {
                Messenger.SendMessage("You are not a superuser.");
                return;
            }

            var options = new List<Option>
            {
                new Option
                {
                    Label = "Add friends",
                    Action = () =>
                    {
                        var friendOptions = client.AllUsers
                            .Where(u => u != superUser && !superUser.Friends.Contains(u))
                            .Select(u => new Option
                            {
                                Label = u.Naam,
                                Action = () =>
                                {
                                    superUser.AddFriend(u);
                                    Messenger.SendMessage($"{u.Naam} added as a friend.");
                                }
                            }).ToList();

                        friendOptions.Insert(0, new Option
                        {
                            Label = "Return to Main Menu",
                            Action = () => ShowMainMenu()
                        });

                        Messenger.OptionBox("Select a user to add as friend:", friendOptions.ToArray(), false);
                    }
                },
                new Option
                {
                    Label = "Remove friends",
                    Action = () =>
                    {
                        var friendOptions = superUser.Friends
                            .Select(f => new Option
                            {
                                Label = f.Naam,
                                Action = () =>
                                {
                                    superUser.RemoveFriend(f);
                                    Messenger.SendMessage($"{f.Naam} removed from friends.");
                                }
                            }).ToList();

                        friendOptions.Insert(0, new Option
                        {
                            Label = "Return to Main Menu",
                            Action = () => ShowMainMenu()
                        });

                        Messenger.OptionBox("Select a friend to remove:", friendOptions.ToArray(), false);
                    }
                },
                new Option
                {
                    Label = "Create playlist",
                    Action = () =>
                    {
                        Messenger.SendMessage("Enter a name for the new playlist (or 0 to cancel):");
                        string title = Console.ReadLine();
                        if (title == "0")
                        {
                            ShowMainMenu();
                            return;
                        }
                        superUser.CreatePlaylist(title);
                        Messenger.SendMessage($"Playlist '{title}' created.");
                    }
                },
                new Option
                {
                    Label = "Remove playlist",
                    Action = () =>
                    {
                        var playlistOptions = superUser.Playlists
                            .Select((pl, i) => new Option
                            {
                                Label = pl.Title,
                                Action = () =>
                                {
                                    superUser.RemovePlaylist(i);
                                    Messenger.SendMessage($"Playlist '{pl.Title}' removed.");
                                }
                            }).ToList();

                        playlistOptions.Insert(0, new Option
                        {
                            Label = "Return to Main Menu",
                            Action = () => ShowMainMenu()
                        });

                        Messenger.OptionBox("Select a playlist to remove:", playlistOptions.ToArray(), false);
                    }
                },
                new Option
                {
                    Label = "Add music to playlist",
                    Action = () =>
                    {
                        var playlistOptions = superUser.Playlists
                            .Select(pl => new Option
                            {
                                Label = pl.Title,
                                Action = () =>
                                {
                                    var songOptions = client.AllSongs.Select(song => new Option
                                    {
                                        Label = song.ToString(),
                                        Action = () =>
                                        {
                                            pl.Add(song);
                                            Messenger.SendMessage($"Song '{song.Title}' added to playlist '{pl.Title}'.");
                                        }
                                    }).ToList();

                                    songOptions.Insert(0, new Option
                                    {
                                        Label = "Return to Main Menu",
                                        Action = () => ShowMainMenu()
                                    });

                                    Messenger.OptionBox("Select a song to add:", songOptions.ToArray(), false);
                                }
                            }).ToList();

                        playlistOptions.Insert(0, new Option
                        {
                            Label = "Return to Main Menu",
                            Action = () => ShowMainMenu()
                        });

                        Messenger.OptionBox("Select a playlist:", playlistOptions.ToArray(), false);
                    }
                },
                new Option
                {
                    Label = "Remove music from playlist",
                    Action = () =>
                    {
                        var playlistOptions = superUser.Playlists
                            .Select(pl => new Option
                            {
                                Label = pl.Title,
                                Action = () =>
                                {
                                    var playables = pl.ShowPlayables();
                                    var playableOptions = playables.Select(p => new Option
                                    {
                                        Label = p.ToString(),
                                        Action = () =>
                                        {
                                            pl.Remove(p);
                                            Messenger.SendMessage($"Removed '{p}' from playlist '{pl.Title}'.");
                                        }
                                    }).ToList();

                                    playableOptions.Insert(0, new Option
                                    {
                                        Label = "Return to Main Menu",
                                        Action = () => ShowMainMenu()
                                    });

                                    Messenger.OptionBox("Select a song to remove:", playableOptions.ToArray(), false);
                                }
                            }).ToList();

                        playlistOptions.Insert(0, new Option
                        {
                            Label = "Return to Main Menu",
                            Action = () => ShowMainMenu()
                        });

                        Messenger.OptionBox("Select a playlist:", playlistOptions.ToArray(), false);
                    }
                },
                new Option
                {
                    Label = "Logout",
                    Action = () =>
                    {
                        Messenger.SendMessage("Logged out.");
                        Main(null);
                    }
                }
            };

            while (true)
            {
                Messenger.OptionBox("Main Menu", options.ToArray(), true);
            }
        }
    }
}
