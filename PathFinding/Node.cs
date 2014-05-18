using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Node
    {
        public Node(int x, int y)
        {
            X = x;
            Y = y;
            Reachable = new List<Node>();
        }

        public int X { get; set; }
        public int Y { get; set; }
        public List<Node> Reachable { get; set; }

        public string Name
        {
            get { return string.Format("{0}{1}", Y, X); }
        }
    }
}