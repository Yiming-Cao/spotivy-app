namespace spotivy_app.spotivy
{
    class Messanger
    {
        public static void SendMessage(string message)
        {
            MessageBorder(message.Length);
            Console.WriteLine("| " + message+ " |");
            MessageBorder(message.Length);
        }

        public static void Conversation(string[] messages, Option[][] options)
        {
            int LongestMessageLength = 0;
            foreach (var message in messages)
            {
                if (message.Length > LongestMessageLength) LongestMessageLength = message.Length;
            }
            MessageBorder(LongestMessageLength);
            for (int i = 0; i > messages.Length; i++)
            {
                Message(messages[i], LongestMessageLength);

            }

            MessageBorder(LongestMessageLength);
        }

        private static void MessageBorder(int length)
        {
            Console.Write("+-");
            for (int i = 0; i < length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("-+");
        }
        private static void Message(string message, int length)
        {
            Console.WriteLine("| " + message);
            for (int i = 0; i < length - message.Length; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(" |");
        }
    }
}
