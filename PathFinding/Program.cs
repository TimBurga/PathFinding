using System;
using System.Linq;

namespace PathFinding
{
    class Program
    {
        const int Width = 10;
        const int Height = 5;

        static void Main()
        {
            var builder = new NodeBuilder(Width, Height);
            var solver = new SimpleSolver();
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();

            while (pressedKey.Key != ConsoleKey.X)
            {
                var grid = new Grid(builder.Build());

                grid.Render();

                var start = grid.Nodes.SingleOrDefault(node => node.X == 1 && node.Y == 1);
                var end = grid.Nodes.SingleOrDefault(node => node.X == Width && node.Y == Height);

                var solution = solver.Solve(start, end);

                grid.Render(solution);

                Console.WriteLine("Press X to exit");
                pressedKey = Console.ReadKey();
            }
        }
    }
}
