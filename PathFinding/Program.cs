using System;

namespace ConsoleApplication1
{
    class Program
    {
        const int Width = 5;
        const int Height = 5;

        static void Main()
        {
            var builder = new NodeBuilder(Width, Height);
            var grid = new Grid(builder.Build());

            grid.Render();

            Console.Read();
        }
    }
}
