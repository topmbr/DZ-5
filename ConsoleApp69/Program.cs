using System.Diagnostics;

namespace ConsoleApp69
{
    internal class Program
    {
        static void Main()
        {
            ProcessStartInfo inputApp = new ProcessStartInfo
            {
                FileName = "FirstApp.cs", // Замените на путь к исполняемому файлу первого приложения
            };

            ProcessStartInfo graphApp = new ProcessStartInfo
            {
                FileName = "SecondApp.cs", // Замените на путь к исполняемому файлу второго приложения
            };

            Process.Start(inputApp);
            Process.Start(graphApp);
        }
    }
}