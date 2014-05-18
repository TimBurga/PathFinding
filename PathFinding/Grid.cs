using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class Grid
    {
        public Grid(List<Node> nodes)
        {
            Process(nodes);
            Nodes = nodes;
        }

        public List<Node> Nodes { get; private set; }

        public void Render()
        {
            var allLines = Nodes
                .GroupBy(node => node.Y)
                .OrderBy(group => group.Key);

            foreach (var line in allLines)
            {
                foreach (var x in line.OrderBy(element => element.X))
                {
                    Console.Write("{0}{1} ", x.Y, x.X);
                }

                Console.Write(Environment.NewLine);
            }

            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);

            foreach (var node in Nodes)
            {
                Console.WriteLine("Node " + node.Name + " can reach " + node.Reachable.Count + " nodes.");
            }
        }

        private static void Process(List<Node> nodes)
        {
            foreach (var node in nodes)
            {
                var left = nodes.SingleOrDefault(n => n.Y == node.X && n.X == (node.X - 1));
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