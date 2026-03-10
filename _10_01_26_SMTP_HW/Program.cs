namespace _10_01_26_SMTP_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string em;
            string pass;

            Console.WriteLine("Введіть пошту відправника: ");
            em = Console.ReadLine();
            Console.WriteLine("Введіть пароль додатка: ");
            pass = Console.ReadLine();



            EmailService emailService = new EmailService(em, pass);


            Console.Write("Введіть адрусу отримувача: ");
            string email = Console.ReadLine();
            Console.Write("Введіть тему листа: ");
            string subject = Console.ReadLine();
            Console.Write("Введіть шлях до текстового файлу: ");
            string filePath = Console.ReadLine();
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Введено не існуючий файл!");
                return;
            }

            List<string> attachments = new List<string>();
            bool isAddingAtt = true;
            while (isAddingAtt)
            {
                Console.Write("Бажаєте прикріпити файл? (y/n): ");
                ConsoleKey key = Console.ReadKey(true).Key;
                Console.WriteLine();
                switch (key)
                {
                    case ConsoleKey.Y:
                        Console.Write("Введіть шлях до файлу: ");
                        string att = Console.ReadLine();
                        if (File.Exists(att))
                        {
                            attachments.Add(att);
                        }
                        else
                        {
                            Console.WriteLine("Файлу не існує");
                        }
                        break;
                    case ConsoleKey.N:
                        isAddingAtt = false;
                        break;
                    default:
                        break;
                }
            }


            
            emailService.SendFileText(email, subject, filePath, attachments);
        }
    }
}
