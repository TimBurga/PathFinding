using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinding
{
    public class SimpleSolver
    {
        public List<Node> Solve(Node startNode, Node endNode)
        {
            var explored = new List<Node>();
            var reachable = new List<Node> { startNode };
            var solution = new List<Node>();

            startNode.Cost = 0;

            while (reachable.Any())
            {
                var here = ChooseNode(reachable);

                if (here.Equals(endNode))
                {
                    while (here != null)
                    {
                        solution.Add(here);
                        here = here.Previous;
                    }

                    return solution;
                }

                var candidates = here.Reachable.Except(explored).ToList();
                
                while (candidates.Any())
                {
                    var nextNode = ChooseNode(candidates);

                    if (!reachable.Contains(nextNode))
                    {
                        reachable.Add(nextNode);
                    }

                    if (here.Cost + 1 < nextNode.Cost)
                    {
                        nextNode.Previous = here;
                        nextNode.Cost = here.Cost + 1;
                    }

                    candidates.Remove(nextNode);
                } 

                reachable.Remove(here);
                explored.Add(here);
            }

            return solution;
        }

        private static Node ChooseNode(List<Node> reachable)
        {
            if (!reachable.Any()) 
                return null;

            var rand = new Random(DateTime.Now.Millisecond).Next(0, reachable.Count() - 1);
            Node best = reachable[rand];

            //var aggd = reachable.Aggregate((node, best) => best == null || node.Cost + 1 < best.Cost ? node : best);
           // return aggd;

            foreach (var node in reachable)
            {
                if (best.Cost > node.Cost)
                {
                    best = node;
                }
            }

            return best;
        }
    }
}