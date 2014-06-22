using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinding
{
    public class Grid
    {
        public Grid(List<Node> nodes)
        {
            Nodes = nodes;
            Initialize(Nodes);
        }

        public List<Node> Nodes { get; private set; }

        public void Render()
        {
            Render(new List<Node>());
        }

        public void Render(List<Node> solution)
        {
            var allLines = Nodes
                .GroupBy(node => node.Y)
                .OrderBy(group => group.Key);

            Console.Write(Environment.NewLine);

            if (solution.Any())
            {
                Console.WriteLine(string.Format("Goal reached in {0} steps:", solution.Max(node => node.Cost) + 1));
            }

            foreach (var line in allLines)
            {
                foreach (var x in line.OrderBy(element => element.X))
                {
                    if (solution.Contains(x))
                        Console.Write((x.Cost + 1).ToString("00"));
                    else
                        Console.Write("..");
                }

                Console.Write(Environment.NewLine);
                Console.Write(Environment.NewLine);
            }
        }

        private static void Initialize(List<Node> nodes)
        {
            foreach (var node in nodes)
            {
                var left = nodes.SingleOrDefault(n => n.Y == node.Y && n.X == (node.X - 1));
                var right = nodes.SingleOrDefault(n => n.Y == node.Y && n.X == (node.X + 1));
                var up = nodes.SingleOrDefault(n => n.X == node.X && n.Y == (node.Y - 1));
                var down = nodes.SingleOrDefault(n => n.X == node.X && n.Y == (node.Y + 1));

                if (left != null) node.Reachable.Add(left);
                if (right != null) node.Reachable.Add(right);
                if (up != null) node.Reachable.Add(up);
                if (down != null) node.Reachable.Add(down);
            }
        }
    }
}