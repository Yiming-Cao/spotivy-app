using System.ComponentModel.DataAnnotations;

namespace spotivy_app.spotivy
{
    class Messanger
    {
        public static void SendMessage(string message)
        {
            MessageBorder(message.Length);
            Console.WriteLine("| " + message + " |");
            MessageBorder(message.Length);
        }

        public static void Conversation(string[] messages, Option[][] options)
        {
            int LongestMessageLength = 0;
            // messages and options has to be the same length
            for (int i = 0; i < messages.Length; i++)
            {
                if (messages[i].Length > LongestMessageLength) LongestMessageLength = messages[i].Length;

                foreach (var opt in options[i])
                {
                    if (opt.Label.Length + 2 > LongestMessageLength) LongestMessageLength = opt.Label.Length + 5;
                }
            }

            for (int i = 0; i < messages.Length; i++) 
            {
                MessageBorder(LongestMessageLength);
                Message(messages[i], LongestMessageLength);
                Message("To choose an option enter then number infront of an option.", LongestMessageLength);
                // show each option with it's number
                for (int o = 0; o < options[i].Length; o++) 
                {
                    var label = options[i][o].Label;
                    Message(label + " " + (o > 9 ? ".  " : ". "), LongestMessageLength);
                }
                // loop until user gives valid input, run the selected options function
                bool validInput = false;
                while (!validInput)
                {
                    if (int.TryParse(Console.ReadLine(), out int userInput))
                    {
                        if (userInput >= 0 && userInput < options[i].Length)
                        {
                            options[i][userInput].Action.Invoke();
                            validInput = true;
                        }
                    }
                }
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
            Console.Write("| " + message);
            for (int i = 0; i < length - message.Length; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(" |");
        }
    }
}
