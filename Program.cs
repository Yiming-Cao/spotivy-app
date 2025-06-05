using spotivy_app.spotivy;

namespace spotivy_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Messenger Messanger = new Messenger();
            Messenger.SendMessage("Welcome to Spotivy! This is a simple app to play music, built with C#!");
            Messenger.FormatMessage("aaaaaaaaaaaaaaaaaaaaaaam                     f", 8, true);
            Messenger.OptionBox("Test", [new Option{ Label = "Hello", Action = Hello }, new Option{ Label = "House", Action = House }]);
        }

        private static void Hello()
        {
            Messenger.SendMessage("Hello");
        }
        private static void House()
        {
            Messenger.FormatMessage(
                "     ____    " +
                "    /    \\    " +
                "   |    |    " +
                "   |____|    ", 14, true);
        }
    }
}
