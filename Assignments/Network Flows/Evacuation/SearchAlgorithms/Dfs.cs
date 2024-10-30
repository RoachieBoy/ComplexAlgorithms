namespace Evacuation.SearchAlgorithms;

public class Dfs: ISearchAlgorithm
{
    public static void TraverseTree<T>(T startingNode, Func<T, IEnumerable<T>> children)
    {
        if (startingNode == null || !children(startingNode).Any()) return;
        
        // using a hash set ensures no duplicate values are allowed
        var visitedNodes = new HashSet<T>();

        var stack = new Stack<T>(); 
        stack.Push(startingNode);

        while (stack.Count > 0)
        {
            var currentNode = stack.Pop();
            
            // If this node has already been visited then skip it 
            // Otherwise add it to the visited nodes collection
            if (!visitedNodes.Add(currentNode)) continue;

            foreach (var child in children(currentNode))
            {
                if (!visitedNodes.Contains(child)) stack.Push(child);
            }
        }
    }
}