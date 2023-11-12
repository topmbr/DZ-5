using System.IO.Pipes;

namespace FirstApp
{
    internal class Program
    {
        static void Main()
        {
            using (var pipe = new NamedPipeClientStream(".", "GraphDataPipe", PipeDirection.Out))
            {
                pipe.Connect();
                using (var writer = new StreamWriter(pipe))
                {
                    Console.WriteLine("Введите данные для графика (например, температуру):");
                    string inputData = Console.ReadLine();
                    writer.WriteLine(inputData);
                }
            }
        }
    }
}