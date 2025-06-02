using spotivy_app.spotivy;

namespace spotivy_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Messanger Messanger = new Messanger();
            Messanger.SendMessage("Welcome to Spotivy! This is a simple Spotify client for Linux, built with C#. Enjoy your music experience!");
        }
    }
}
