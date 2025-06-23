using spotivy_app.spotivy;

namespace spotivy_app
{
    internal class Program
    {
        static Client client;
        static void Main(string[] args)
        {
            List<Person> users = new List<Person>() { { new Person("Thomas") }, { new Person("Yiming") }, { new Person("Robert") } };
            List<Album> albums = new List<Album>();
            List<Song> songs = new List<Song>();

            client = new Client(users, albums, songs);

            Messenger.SendMessage("Welcome to Spotivy! This is a simple app to play music, built with C#!");
            var options = users
                .Select(su => new Option { Label = su.Naam, Action = () => Login(su) })
                .ToArray();

            Messenger.OptionBox("Login", options);
            
        }

        public static void Login(Person user)
        {
            SuperUser superUser = new SuperUser(user.Naam);
            client.SetActiveUser(superUser);
            Messenger.SendMessage($"Already logged in as: {client.ActiveUser.Naam}");
            client.ActiveUser.ShowFriends();
            client.ActiveUser.ShowPlaylists();
            ShowMainMenu();
        }

        static void ShowMainMenu()
        {
            while (true)
            {
                Messenger.SendMessage(
                    "Option:\n" +
                    "1. Add friends\n" +
                    "2. Remove friends\n" +
                    "3. Create playlist\n" +
                    "4. Remove playlist\n" +
                    "5. Add music to playlist\n" +
                    "6. Remove music from playlist\n" +
                    "0. quit"
                );
                string input = Console.ReadLine();

                if (input == "0") break;

                var superUser = client.ActiveUser as SuperUser;
                if (superUser == null)
                {
                    Messenger.SendMessage("You are not superuser");
                    return;
                }

                switch (input)
                {
                    case "1":
                        // 添加好友
                        client.ShowAllUsers();
                        Messenger.SendMessage("Write the number of friend that you want add");
                        if (int.TryParse(Console.ReadLine(), out int friendIndex))
                        {
                            if (friendIndex >= 0 && friendIndex < client.AllUsers.Count)
                                superUser.AddFriend(client.AllUsers[friendIndex]);
                        }
                        break;
                    case "2":
                        // 移除好友
                        client.ShowFriends();
                        Messenger.SendMessage("Write the number of friend that you want remove：");
                        if (int.TryParse(Console.ReadLine(), out int removeIndex))
                        {
                            if (removeIndex >= 0 && removeIndex < superUser.Friends.Count)
                                superUser.RemoveFriend(superUser.Friends[removeIndex]);
                        }
                        break;
                    case "3":
                        // 创建歌单
                        Messenger.SendMessage("Write the name of playlist that you want create：");
                        string title = Console.ReadLine();
                        superUser.CreatePlaylist(title);
                        break;
                    case "4":
                        // 移除歌单
                        superUser.ShowPlaylists();
                        Messenger.SendMessage("Write the name of playlist that you want remove：");
                        if (int.TryParse(Console.ReadLine(), out int playlistIndex))
                        {
                            superUser.RemovePlaylist(playlistIndex);
                        }
                        break;
                    case "5":
                        // 添加歌曲到歌单
                        superUser.ShowPlaylists();
                        Messenger.SendMessage("Write the number of playlist：");
                        if (int.TryParse(Console.ReadLine(), out int plIndex))
                        {
                            client.ShowAllSongs();
                            Messenger.SendMessage("Write the number of song：");
                            if (int.TryParse(Console.ReadLine(), out int songIndex))
                            {
                                if (plIndex >= 0 && plIndex < superUser.Playlists.Count &&
                                    songIndex >= 0 && songIndex < client.AllSongs.Count)
                                {
                                    superUser.Playlists[plIndex].Add(client.AllSongs[songIndex]);
                                }
                            }
                        }
                        break;
                    case "6":
                        // 从歌单移除歌曲
                        superUser.ShowPlaylists();
                        Messenger.SendMessage("Write the number of playlist：");
                        if (int.TryParse(Console.ReadLine(), out int plIdx))
                        {
                            if (plIdx >= 0 && plIdx < superUser.Playlists.Count)
                            {
                                var playlist = superUser.Playlists[plIdx];
                                var playables = playlist.ShowPlayables();
                                Messenger.SendMessage("Write the number of song that you want remove：");
                                if (int.TryParse(Console.ReadLine(), out int songIdx))
                                {
                                    if (songIdx >= 0 && songIdx < playables.Count)
                                        playlist.Remove(playables[songIdx]);
                                }
                            }
                        }
                        break;
                    default:
                        Messenger.SendMessage("Wrong Chose, try again");
                        break;
                }
            }
        }



    }
}
