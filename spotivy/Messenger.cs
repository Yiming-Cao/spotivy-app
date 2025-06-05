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
