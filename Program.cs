using spotivy_app.spotivy;

namespace spotivy_app
{
    internal class Program
    {
        static Client client;
        static void Main(string[] args)
        {
            List<Person> users = new List<Person>();
            List<Album> albums = new List<Album>();
            List<Song> songs = new List<Song>();

            client = new Client(users, albums, songs);

            List<SuperUser> superUsers = [
                new SuperUser("SuperUser"),
                new SuperUser("Yiming"),
                new SuperUser("Thomas")
            ];

            users.AddRange(superUsers);
            client.SetActiveUser(superUsers[0]);
            
            Messenger.SendMessage("Welcome to Spotivy! This is a simple app to play music, built with C#!");
            var options = superUsers
                .Select(su => new Option { Label = su.Naam, Action = () => Login(su) })
                .ToArray();

            Messenger.OptionBox("Login", options);
        }


        public static void Login(Person user)
        {
            client.SetActiveUser(user);
            Messenger.SendMessage($"Already logged in as: {client.ActiveUser.Naam}");
            client.ActiveUser.ShowFriends();
            client.ActiveUser.ShowPlaylists();

            //Playlist selected = client.ActiveUser.SelectPlaylist(0);

            //if (selected != null)
            //{
            //    Messenger.SendMessage($"You selected playlist: {selected.Title}");
            //}
        }
    }
}
