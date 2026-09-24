namespace ConsoleBank
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Välkommen till ConsoleBank TM");
            Console.WriteLine("Välj ditt konto och skriv in ditt lösenord ");
            Console.WriteLine(" ");
            Accounts();



            Console.ReadKey();
        }

        static void Accounts()
        {
            string[] User = new string[5];
            User[0] = "1: Shenol Mitkov";
            User[1] = "2: Bertil Korggren";
            User[2] = "3: Felix Reztsel";
            User[3] = "4: Alexandra Nilsson";
            User[4] = "5: Anas Alhussein";

            Console.WriteLine(string.Join(Environment.NewLine, User));

        }
    }
}
