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

            while (reachable.Any())
            {
                var workingNode = ChooseNode(reachable);

                if (workingNode.Equals(endNode))
                {
                    while (workingNode != null)
                    {
                        solution.Add(workingNode);
                        workingNode = workingNode.Previous;
                    }

                    return solution;
                }

                var nextReachables = workingNode.Reachable.Except(explored).ToList();
                
                while (nextReachables.Any())
                {
                    var nextNode = ChooseNode(nextReachables);

                    if (!reachable.Contains(nextNode))
                    {
                        nextNode.Previous = workingNode;
                        reachable.Add(nextNode);
                    }

                    nextReachables.Remove(nextNode);
                } 

                reachable.Remove(workingNode);
                explored.Add(workingNode);
            }

            return solution;
        }

        private static Node ChooseNode(List<Node> reachable)
        {
            var reachableCount = reachable.Count();
            if (reachableCount == 0)
                return null;

            var rand = new Random(DateTime.Now.Millisecond).Next(0, reachableCount - 1);
            return reachable[rand];
        }
    }
}