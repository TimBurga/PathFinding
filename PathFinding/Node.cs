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
        }

        public int X { get; set; }
        public int Y { get; set; }
        public List<Node> Reachable { get; set; }
        public Node Previous { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}", Y, X);
        }

        public override bool Equals(object obj)
        {
            var other = (Node) obj;
            return (X == other.X && Y == other.Y);
        }

        //public static bool operator ==(Node left, Node right)
        //{
        //    if (left == null || right == null)
        //        return false;

        //    return (left.X == right.X && 
        //            left.Y == right.Y);
        //}

        //public static bool operator !=(Node left, Node right)
        //{
        //    return !(left == right);
        //}

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}