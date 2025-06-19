using spotivy_app.spotivy;
using System.Threading.Tasks;
using static spotivy_app.spotivy.Constants;

namespace spotivy_app
{
    internal class Program
    {
        static Client client;
        static async Task Main(string[] args)
        {
            List<Person> users = new List<Person>() { { new Person("Thomas") }, { new Person("Yiming") }, { new Person("Robert") } };
            List<Album> albums = new List<Album>();
            List<Song> songs = new List<Song>();

            client = new Client(users, albums, songs);

            Messenger.SendMessage("Welcome to Spotivy! This is a simple app to play music, built with C#!");
            var options = users
                .Select(su => new Option { Label = su.Naam, Action = () => Login(su) })
                .ToArray();

            Messenger.OptionBox("Login", options, false);

            Song TestSong = new Song(
               "Test Song",
               new List<Artist>
               {
                        new Artist("Test Artist", new List<Album>())
               },
               Genre.Pop,
               120
            );
            //TestSong.Play();
            //await Task.Delay(11000);
            //TestSong.Pause();
            //await Task.Delay(6000);
            //TestSong.Continue();
            //await Task.Delay(4000);
            //TestSong.Stop();
            //await Task.Delay(4000);

            albums.Add(new Album
            (
               new List<Artist>
                  {
                  new Artist("noob", new List<Album>())
                      {
                          Songs = new List<Song>
                          {
                              new Song(
                                  "Test Song",
                                  new List<Artist>
                                  {
                                      new Artist("Test Artist", new List<Album>())
                                  },
                                  Genre.Pop,
                                  120
                              )
                          }
                      }
                  },
                  "Test Album",
                  new List<Song>
                  {
                      new Song(
                          "Test Song",
                          new List<Artist>
                          {
                              new Artist("Test Artist", new List<Album>())
                          },
                          Genre.Pop,
                          120
                      ),
                      new Song(
                          "Noob Song",
                          new List<Artist>
                          {
                              new Artist("Test Artist", new List<Album>())
                          },
                          Genre.Pop,
                          110
                      )
                  }
               ));
            albums[0].Play();

            await Task.Delay(10000);
            albums[0].Next();
            albums[0].Play();
            await Task.Delay(30000);
        }

        public static void Login(Person user)
        {
            SuperUser superUser = new SuperUser(user.Naam);
            client.SetActiveUser(superUser);
            Messenger.SendMessage($"Already logged in as: {client.ActiveUser.Naam}");
            client.ActiveUser.ShowFriends();
            client.ActiveUser.ShowPlaylists();
        }
    }
}
