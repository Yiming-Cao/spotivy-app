using System.ComponentModel.DataAnnotations;

namespace spotivy_app.spotivy
{
    class Messanger
    {
        public static void SendMessage(string message)
        {
            FormatMessage(message, 116, true);
        }

        public static void Conversation(string message, string[] messages, Option[][] options)
        {
            int LongestMessageLength = message.Length;
            // messages and options has to be the same length
            for (int i = 0; i < messages.Length; i++)
            {
                if (messages[i].Length > LongestMessageLength) LongestMessageLength = messages[i].Length;

                if (LongestMessageLength > 116)
                {
                    LongestMessageLength = 116;
                    break;
                }
                foreach (var opt in options[i])
                {
                    if (opt.Label.Length + 2 > LongestMessageLength) LongestMessageLength = opt.Label.Length + 5;
                    if (LongestMessageLength > 116) 
                    {
                        LongestMessageLength = 116;
                        break;
                    }
                }
            }

            for (int i = 0; i < messages.Length; i++) 
            {
                MessageBorder(LongestMessageLength);
                FormatMessage(message, LongestMessageLength, false);
                FormatMessage(messages[i], LongestMessageLength, false);
                FormatMessage("To choose an option enter then number infront of an option.", LongestMessageLength, false);
                // show each option with it's number
                for (int o = 0; o < options[i].Length; o++) 
                {
                    var label = options[i][o].Label;
                    FormatMessage((o + 1) + (o + 1 > 9 ? ".  " : ". ") + label, LongestMessageLength, false);
                }
                MessageBorder(LongestMessageLength);
                // loop until user gives valid input, run the selected options function
                bool validInput = false;
                while (!validInput)
                {
                    Console.Write("Option: ");
                    if (int.TryParse(Console.ReadLine(), out int userInput))
                    {
                        int input = userInput - 1;
                        if (input >= 0 && input < options[i].Length)
                        {
                            options[i][input].Action.Invoke();
                            validInput = true;
                        } else { Console.WriteLine("Invalid input, please enter a number within the range."); }
                    } else { Console.WriteLine("Invalid input, please enter a number."); }
                }
            }
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

        public static void FormatMessage(string message, int length, bool border)
        {
            if (border == true) MessageBorder(length);
            for (int s = 0; s < message.Length;)
            {
                int remaining = message.Length - s;
                int lineLength = remaining > length ? length : remaining;
                int end = s + lineLength;

                if (remaining > length)
                {
                    int lastSpace = message.LastIndexOf(' ', end - 1, lineLength);
                    if (lastSpace > s) end = lastSpace;
                }

                string line = message.Substring(s, end - s);
                Console.Write("| " + line);
                for (int i = 0; i < length - line.Length; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(" |");

                s = end;
            }
            if (border == true) MessageBorder(length);
        }
    }
}
