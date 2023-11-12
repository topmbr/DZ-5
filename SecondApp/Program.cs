using System;
using System.IO;
using System.IO.Pipes;
using System.Drawing;
using System.Drawing.Imaging;

namespace SecondApp
{
    internal class Program
    {
        static void Main()
        {
            using (var pipe = new NamedPipeServerStream("GraphDataPipe", PipeDirection.In))
            {
                pipe.WaitForConnection();
                using (var reader = new StreamReader(pipe))
                {
                    string data = reader.ReadLine();

                    // Генерация примера графика
                    using (var chartBitmap = new Bitmap(800, 600))
                    {
                        using (var g = Graphics.FromImage(chartBitmap))
                        {
                            g.Clear(Color.White);
                            Pen pen = new Pen(Color.Blue, 2);
                            g.DrawLine(pen, 0, 300, 800, 300);
                        }

                        // Сохранение графика как изображения на жёсткий диск
                        chartBitmap.Save("graph_image.png", ImageFormat.Png);
                        Console.WriteLine("График сохранен на жёсткий диск.");
                    }
                }
            }
        }
    }
}