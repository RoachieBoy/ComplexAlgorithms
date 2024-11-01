namespace Evacuation.Utilities;

public static class MaxFlowUtilities
{
    public static int FindMaxFlow<T>(T source, T sink, Func<T, IEnumerable<T>> getNeighbors, 
        Func<T, T, int> getRemainingCapacity, Action<T, T, int> updateFlow, SearchAlgorithmType searchAlgorithmType) 
        where T : notnull
    {
        return searchAlgorithmType switch
        {
            SearchAlgorithmType.FordFulkerson => FordFulkerson(source, sink, getNeighbors, getRemainingCapacity, updateFlow),
            SearchAlgorithmType.EdmondKarp => default,
            _ => throw new ArgumentException("Invalid search type specified.")
        };
    }

    private static int FordFulkerson<T>(T source, T sink, Func<T, IEnumerable<T>> getNeighbors,
        Func<T, T, int> getRemainingCapacity, Action<T, T, int> updateFlow) where T : notnull
    {
        var maxFlow = 0;

        while (true)
        {
            // Use DFS to find an augmenting path
            var augmentedPathFound = SearchAlgorithmUtilities.Dfs(
                source,
                getNeighbors,
                node => EqualityComparer<T>.Default.Equals(node, sink),
                out var parentMap
            );

            // If no augmenting path is found, exit the loop
            if (!augmentedPathFound) break;

            // Determine the bottleneck capacity in the found path
            var pathFlow = int.MaxValue;
            
            for (var t = sink; !EqualityComparer<T>.Default.Equals(t, source); t = parentMap[t])
            {
                var s = parentMap[t];
                pathFlow = Math.Min(pathFlow, getRemainingCapacity(s, t));
            }

            // Update the flow values along the path
            for (var t = sink; !EqualityComparer<T>.Default.Equals(t, source); t = parentMap[t])
            {
                var s = parentMap[t];
                updateFlow(s, t, pathFlow);
                updateFlow(t, s, -pathFlow);
            }

            // Add the bottleneck capacity to the overall max flow
            maxFlow += pathFlow;
        }

        return maxFlow;
    }
}