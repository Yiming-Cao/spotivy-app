using System.ComponentModel.DataAnnotations;

namespace spotivy_app.spotivy
{
    class Messenger
    {
        public static void SendMessage(string message)
        {
            FormatMessage(message, 116, true);
        }

        public static void OptionBox(string message, Option[] options)
        {
            int MaxMessageLength = message.Length;
            // find longest message and set maxMessageLength to it max is 116 (full length of console 1080p not fullscreen)
            foreach (var opt in options)
            {
                if (opt.Label.Length + 2 > MaxMessageLength) MaxMessageLength = opt.Label.Length + 5;
                if (MaxMessageLength > 116)
                {
                    MaxMessageLength = 116;
                    break;
                }
            }
            MessageBorder(MaxMessageLength);
            FormatMessage(message, MaxMessageLength, false);
            FormatMessage("To choose an option enter then number infront of an option.", MaxMessageLength, false);
            // show each option with it's number
            for (int i = 0; i < options.Length; i++)
            {
                FormatMessage((i + 1) + (i + 1 > 9 ? ".  " : ". ") + options[i].Label, MaxMessageLength, false);
            }
            MessageBorder(MaxMessageLength);
            // loop until user gives valid input, run the selected options function
            bool validInput = false;
            while (!validInput)
            {
                Console.Write("Option: ");
                if (int.TryParse(Console.ReadLine(), out int userInput))
                {
                    int input = userInput - 1;
                    if (input >= 0 && input < options.Length)
                    {
                        options[input].Action.Invoke();
                        validInput = true;
                    }
                    else Console.WriteLine("Invalid input, please enter a number within the range.");
                }
                else Console.WriteLine("Invalid input, please enter a number."); 
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
            if (length > 116) length = 116;
            if (border) MessageBorder(length);
            var lines = new List<string>();
            // split the messages at \n so that starts a new line
            var messages = message.Split('\n');
            foreach (var msg in messages)
            {
                // split the message to multiple strings of the max length
                if (msg.Length > length)
                {
                    lines.AddRange(SplitByLength(msg, length));
                }
                else lines.Add(msg);
            }

            foreach (var line in lines)
            {
                Console.WriteLine("| " + line + new string(' ', length - line.Length) + " |");
            }

            if (border) MessageBorder(length);
        }

        public static List<string> SplitByLength(string input, int length)
        {
            var strings = new List<string>();
            for (int i = 0; i < input.Length; i += length)
            {
                strings.Add(input.Substring(i, Math.Min(length, input.Length - i)));
            }
            return strings;
        }

    }
}
