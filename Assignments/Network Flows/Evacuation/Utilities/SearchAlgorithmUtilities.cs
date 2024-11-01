namespace Evacuation.Utilities;

public static class SearchAlgorithmUtilities
{
    public static bool LocatedAugmentedPathWithDfs(int[,] residualGraph, int source, int sink, int[] parent, int numVertices)
    {
        // Keep track of whether a vertex has been visited or not 
        var visited = new bool[numVertices];
        var stack = new Stack<int>();

        stack.Push(source);
        visited[source] = true;
        // Set to -1 because source node has no parent 
        parent[source] = -1;

        while (stack.Count > 0)
        {
            var u = stack.Pop();

            for (var v = 0; v < numVertices; v++)
            {
                if (visited[v] || residualGraph[u, v] <= 0) continue;
                
                stack.Push(v);
                parent[v] = u;
                visited[v] = true;

                // The augmented path has been found once we reach target node 
                if (v == sink) return true;
            }
        }
        return false;
    }

    public static bool LocatedAugmentedPathWithBfs(int[,] residualGraph, int source, int sink, int[] parent, int numVertices)
    {
        // Keep track of whether a vertex has been visited or not 
        var visited = new bool[numVertices];
        var queue = new Queue<int>();
        
        queue.Enqueue(source);
        visited[source] = true;
        parent[source] = -1;

        while (queue.Count > 0)
        {
            var u = queue.Dequeue();

            for (var v = 0; v < numVertices; v++)
            {
                if (visited[v] || residualGraph[u, v] <= 0) continue;
                
                queue.Enqueue(v);
                parent[v] = u;
                visited[v] = true;
                
                // The augmented path has been found once we reach target node 
                if (v == sink) return true;
            }
        }
        return false;
    }
}