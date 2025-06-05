using spotivy_app.spotivy;

namespace spotivy_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Messanger Messanger = new Messanger();
            Messanger.SendMessage("Welcome to Spotivy! This is a simple app to play music, built with C#!");
            Messanger.FormatMessage("aaaaaaaaaaaaaaaaaaaaaaam                     f", 8, true);
            Messanger.Conversation("Test", ["bruh", "uhm"], [ [new Option{ Label = "Hello", Action = Hello }, new Option{ Label = "House", Action = House }], [new Option { Label = "House", Action = House }, new Option { Label = "Hello", Action = Hello }] ]);
        }

        private static void Hello()
        {
            Messanger.SendMessage("Hello");
        }
        private static void House()
        {
            Messanger.FormatMessage(
                "     ____    " +
                "    /    \\    " +
                "   |    |    " +
                "   |____|    ", 14, true);
        }
    }
}
