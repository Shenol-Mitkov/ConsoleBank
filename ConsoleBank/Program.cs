namespace ConsoleBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till ConsoleBank TM");
            Console.WriteLine("Välj ditt konto och skriv in ditt lösenord ");
            Console.WriteLine();

            // Get accounts (Accounts only stores/returns the account array)
            string[] users = Accounts();

            // Show selection and read input
            Console.WriteLine("Välj ett konto genom att trycka nummer 1-{0}:", users.Length);
            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i]}");
            }

            var keyInfo = Console.ReadKey(true);
            char pressed = keyInfo.KeyChar;
            int index = -1;
            if (pressed >= '1' && pressed <= (char)('0' + users.Length))
            {
                index = pressed - '1';
            }

            if (index < 0)
            {
                Console.WriteLine("\nOgiltigt val. Starta om programmet och välj rätt nummer.");
                return;
            }

            // Check password with up to 3 attempts. If it fails, close program.
            bool authenticated = PasswordCheck(users[index], 3);
            if (!authenticated)
            {
                Console.WriteLine("Stänger programmet pga för många misslyckade försök.");
                Environment.Exit(0);
            }

            Console.WriteLine($"Åtkomst godkänd. Välkommen, {users[index]}!");
            Console.ReadKey();
        }

        // Accounts only creates and returns the array of users so it can be managed in one place
        static string[] Accounts()
        {
            string[] users = new string[5];
            users[0] = "Shenol Mitkov";
            users[1] = "Bertil Korggren";
            users[2] = "Felix Reztsel";
            users[3] = "Alexandra Nilsson";
            users[4] = "Anas Alhussein";

            return users;
        }

        // PasswordCheck handles prompting and validating password attempts
        static bool PasswordCheck(string user, int maxAttempts)
        {
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                Console.Write($"\nSkriv in lösenord för {user}: ");
                string password = Console.ReadLine() ?? string.Empty;
                if (password == "Admin")
                    return true;

                int remaining = maxAttempts - attempt;
                if (remaining > 0)
                    Console.WriteLine($"Fel lösenord. Försök igen. ({remaining} försök kvar)");
            }

            // failed after maxAttempts
            return false;
        }
    }
}
