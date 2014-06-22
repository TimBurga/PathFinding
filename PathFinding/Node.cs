using System.Collections.Generic;

namespace PathFinding
{
    public class Node
    {
        public Node(int x, int y)
        {
            X = x;
            Y = y;
            Reachable = new List<Node>();
            Cost = 10000000;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public List<Node> Reachable { get; set; }
        public Node Previous { get; set; }
        public int Cost { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}", Y % 10, X % 10);
        }

        public override bool Equals(object obj)
        {
            var other = (Node) obj;
            return (X == other.X && Y == other.Y);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}