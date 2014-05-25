using System.Collections.Generic;

namespace PathFinding
{
    public class NodeBuilder
    {
        private readonly int _width;
        private readonly int _height;

        public NodeBuilder(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public List<Node> Build()
        {
            var nodes = new List<Node>();
            for (var y = 1; y <= _height; y++)
            {
                for (var x = 1; x <= _width; x++)
                {
                    nodes.Add(new Node(x, y));
                }
            }
            return nodes;
        }
    }
}