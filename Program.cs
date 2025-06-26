using spotivy_app.spotivy;
using static spotivy_app.spotivy.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
    
namespace spotivy_app
{
    internal class Program
    {
        static Client client;
        static Dictionary<string, SuperUser> userCache = new Dictionary<string, SuperUser>();
        static Dictionary<string, List<string>> pendingFriendRequests = new Dictionary<string, List<string>>();
        public static string loggedInName; // <-- 加在 class Program 顶部作为全局变量
        static List<Person> users = new List<Person>();

        static void Main(string[] args)
        {
            Constants constants = new Constants();
            List<Artist> Artists = constants.artists;
            List<Album> Albums = constants.albums;
            List<Song> Songs = Albums.SelectMany(album => album.playables.OfType<Song>()).ToList();
            users = new List<Person>()
            {
                new Person("Thomas"),
                new Person("Yiming"),
                new Person("Robert")
            };

            client = new Client(users, Albums, Songs);

            Messenger.SendMessage("Welcome to Spotivy! This is a simple app to play music, built with C#!");
      

            //var playOptions = new List<Option>
            //{
            //    new Option { Label = "Play", Action = () => client.CurrentlyPlaying?.Play() },
            //    new Option { Label = "Pause", Action = () => client.CurrentlyPlaying?.Pause() },
            //    new Option { Label = "Stop", Action = () => client.CurrentlyPlaying?.Stop() },
            //    new Option { Label = "Next Song", Action = () => client.NextSong() },
            //}.ToArray();



            //client.SelectAlbum(0);
            //client.Play();
            ShowLoginMenu();

        }

        static void ShowLoginMenu()
        {
            var loginOptions = users
                .Select(su => new Option { Label = su.Naam, Action = () => Login(su) })
                .ToList();

            loginOptions.Insert(0, new Option
            {
                Label = "Exit Application",
                Action = () =>
                {
                    Messenger.SendMessage("Exiting application...");
                    Environment.Exit(0);
                }
            });

            Messenger.OptionBox("Login", loginOptions.ToArray(), true);
        }

        public static void Login(Person user)
        {
            SuperUser superUser;

            if (userCache.TryGetValue(user.Naam, out superUser))
            {
                // Already cached
            }
            else
            {
                superUser = user is SuperUser existing ? existing : new SuperUser(user.Naam);
                superUser.Friends = user.Friends;
                superUser.Playlists = user.Playlists;
                userCache[user.Naam] = superUser;
            }

            loggedInName = superUser.Naam;
            client.SetActiveUser(superUser);
            Messenger.SendMessage($"Logged in as: {superUser.Naam}");
            superUser.ShowFriends();
            superUser.ShowPlaylists();
            ShowMainMenu();
        }

        static Person GetCachedUser(string name)
        {
            if (userCache.TryGetValue(name, out var su))
                return su;

            return client.AllUsers.FirstOrDefault(u => u.Naam == name);
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
                    Label = "Change name",
                    Action = () =>
                    {
                        Messenger.SendMessage("Enter a new name:");
                        string newName = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(newName))
                        {
                            // 修改原来的 Person 对象的名字（为了登录界面）
                            var originalPerson = client.AllUsers.FirstOrDefault(p => p.Naam == loggedInName);
                            if (originalPerson != null)
                            {
                                originalPerson.Naam = newName;
                            }

                            // 修改缓存键（userCache）
                            if (userCache.ContainsKey(loggedInName))
                            {
                                userCache.Remove(loggedInName);
                            }

                            superUser.Naam = newName;
                            userCache[newName] = superUser;

                            // 更新 loggedInName
                            loggedInName = newName;

                            Messenger.SendMessage($"Your name has been changed to {newName}.");
                        }
                        else
                        {
                            Messenger.SendMessage("Invalid name. Name not changed.");
                        }
                    }
                },


                new Option
                {
                    Label = "Send Friend Request",
                    Action = () =>
                    {
                        var others = client.AllUsers
                            .Where(u => u.Naam != superUser.Naam && !superUser.Friends.Any(f => f.Naam == u.Naam))
                            .ToList();

                        if (others.Count == 0)
                        {
                            Messenger.SendMessage("No users available to send request.");
                            return;
                        }

                        var sendOptions = others.Select(u => new Option
                        {
                            Label = u.Naam,
                            Action = () =>
                            {
                                if (!pendingFriendRequests.ContainsKey(u.Naam))
                                    pendingFriendRequests[u.Naam] = new List<string>();

                                if (!pendingFriendRequests[u.Naam].Contains(superUser.Naam))
                                {
                                    pendingFriendRequests[u.Naam].Add(superUser.Naam);
                                    Messenger.SendMessage($"Friend request sent to {u.Naam}.");
                                }
                                else
                                {
                                    Messenger.SendMessage("Request already sent.");
                                }
                            }
                        }).ToList();

                        sendOptions.Insert(0, new Option
                        {
                            Label = "Return to Main Menu",
                            Action = () => ShowMainMenu()
                        });

                        Messenger.OptionBox("Select user to send request:", sendOptions.ToArray(), false);
                    }
                },
                new Option
                {
                    Label = "View Friend Requests",
                    Action = () =>
                    {
                        if (!pendingFriendRequests.ContainsKey(superUser.Naam) || pendingFriendRequests[superUser.Naam].Count == 0)
                        {
                            Messenger.SendMessage("No pending requests.");
                            return;
                        }

                        var requests = pendingFriendRequests[superUser.Naam].ToList();
                        var acceptOptions = requests.Select(name => new Option
                        {
                            Label = $"Accept request from {name}",
                            Action = () =>
                            {
                                var requester = GetCachedUser(name);
                                if (requester == null)
                                {
                                    Messenger.SendMessage("Requester not found.");
                                    return;
                                }

                                if (!superUser.Friends.Any(f => f.Naam == name))
                                    superUser.Friends.Add(requester);

                                if (!requester.Friends.Any(f => f.Naam == superUser.Naam))
                                    requester.Friends.Add(superUser);

                                pendingFriendRequests[superUser.Naam].Remove(name);
                                Messenger.SendMessage($"You are now friends with {name}.");
                            }
                        }).ToList();

                        acceptOptions.Insert(0, new Option
                        {
                            Label = "Return to Main Menu",
                            Action = () => ShowMainMenu()
                        });

                        Messenger.OptionBox("Pending Friend Requests", acceptOptions.ToArray(), false);
                    }
                },

                new Option
                {
                    Label = "Remove Friends",
                    Action = () =>
                    {
                        if (superUser.Friends.Count == 0)
                        {
                            Messenger.SendMessage("No friends to remove.");
                            return;
                        }

                        var removeOptions = superUser.Friends.Select(f => new Option
                        {
                            Label = f.Naam,
                            Action = () =>
                            {
                                superUser.RemoveFriend(f);
                                f.Friends.Remove(superUser); // 双向删除
                                Messenger.SendMessage($"{f.Naam} removed.");
                            }
                        }).ToList();

                        removeOptions.Insert(0, new Option
                        {
                            Label = "Return to Main Menu",
                            Action = () => ShowMainMenu()
                        });

                        Messenger.OptionBox("Select friend to remove:", removeOptions.ToArray(), false);
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
                        ShowLoginMenu();
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
