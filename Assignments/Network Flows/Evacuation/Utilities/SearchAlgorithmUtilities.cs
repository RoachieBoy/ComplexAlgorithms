using System.Numerics;

namespace Evacuation.Utilities;

public static class SearchAlgorithmUtilities
{
    /// <summary>
    ///     Determines if there is an augmented path from the source node to the sink node
    ///     in the residual graph using Depth-First Search (DFS).
    /// </summary>
    /// <param name="residualGraph">A 2D array representing the residual capacities of the graph edges.</param>
    /// <param name="source">The source node where the search starts.</param>
    /// <param name="sink">The sink node where the search is aimed to reach.</param>
    /// <param name="parent">
    ///     An array to store the path from source to sink;
    ///     each index represents the parent of that node in the path.
    /// </param>
    /// <param name="numVertices">The number of vertices in the graph.</param>
    /// <returns>
    ///     Returns <c>true</c> if an augmented path from source to sink exists; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasFoundAugmentedPathWithDfs<T>(
        T[,] residualGraph,
        int source,
        int sink,
        int[] parent,
        int numVertices)
        where T : INumber<T>
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
                if (visited[v] || residualGraph[u, v] <= T.Zero) continue;

                stack.Push(v);
                parent[v] = u;
                visited[v] = true;

                // The augmented path has been found once we reach target node                                           
                if (v == sink) return true;
            }
        }

        return false;
    }

    /// <summary>
    ///     Determines if there is an augmented path from the source node to the sink node
    ///     in the residual graph using Breadth-First Search (BFS).
    /// </summary>
    /// <param name="residualGraph">A 2D array representing the residual capacities of the graph edges.</param>
    /// <param name="source">The source node where the search begins.</param>
    /// <param name="sink">The sink node where the search is aimed to reach.</param>
    /// <param name="parent">
    ///     An array to store the path from source to sink;
    ///     each index represents the parent of that node in the path.
    /// </param>
    /// <param name="numVertices">The number of vertices in the graph.</param>
    /// <returns>
    ///     Returns <c>true</c> if an augmented path from source to sink exists; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasFoundAugmentedPathWithBfs<T>(
        T[,] residualGraph,
        int source,
        int sink,
        int[] parent,
        int numVertices)
        where T : INumber<T>
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
                if (visited[v] || residualGraph[u, v] <= T.Zero) continue;

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