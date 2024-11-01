namespace Evacuation.Utilities;

public static class SearchAlgorithmUtilities
{
    public static bool Dfs<T>(T source, Func<T, IEnumerable<T>> getChildren, Func<T, bool> isSinkNode, 
        out Dictionary<T, T> parentMap) where T : notnull
    {
        parentMap = new Dictionary<T, T>();
        var visitedNodes = new HashSet<T>();
        var stack = new Stack<T>(); 
        
        stack.Push(source);
        visitedNodes.Add(source);
        parentMap[source] = default; 

        while (stack.Count > 0)
        {
            var currentNode = stack.Pop();
            
            if (isSinkNode(currentNode)) return true;

            foreach (var child in getChildren(currentNode))
            {
                if (visitedNodes.Contains(child)) continue;
                
                stack.Push(child);
                visitedNodes.Add(child);
                parentMap[child] = currentNode;
            }
        }

        return false; 
    }
    
    public static void Bfs<T>(T rootNode, Func<T, IEnumerable<T>> getChildren)
    {
        if (rootNode == null || getChildren == null || !getChildren(rootNode).Any()) return;
        
        var visitedNodes = new HashSet<T>();
        var queue = new Queue<T>();
        
        queue.Enqueue(rootNode);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();

            if (!visitedNodes.Add(currentNode)) continue;

            foreach (var node in getChildren(currentNode))
            {
                if (!visitedNodes.Contains(node)) 
                {
                    queue.Enqueue(node);
                } 
            }
        }
    }
}