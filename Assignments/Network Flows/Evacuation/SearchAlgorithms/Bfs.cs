namespace Evacuation.SearchAlgorithms;

public class Bfs: ISearchAlgorithm
{
    public static void TraverseTree<T>(T startingNode, Func<T, IEnumerable<T>> children)
    {
        if (startingNode == null || !children(startingNode).Any()) return;
        
        var visitedNodes = new HashSet<T>();
        
        var queue = new Queue<T>();
        queue.Enqueue(startingNode);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();

            if (!visitedNodes.Add(currentNode)) continue;

            foreach (var node in children(currentNode))
            {
                queue.Enqueue(node);
            }
        }
    }
}