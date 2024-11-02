namespace Evacuation.Utilities;

public static class MaxFlowUtilities
{
    /// <summary>
    ///  Find the max flow for a given graph/network.
    /// </summary>
    /// <param name="graph"> The graph to analyse. </param>
    /// <param name="source"> The source node of the graph. </param>
    /// <param name="sink"> The end node of the graph. </param>
    /// <param name="vertexCount"> The number of vertices in the graph </param>
    /// <param name="maxFlowAlgorithmTypes"> Which type of max flow algorithm to implement to calculate the max flow. </param>
    /// <returns> An int representing the max flow of the graph. </returns>
    public static int FindMaxFlow(
        int[,] graph, 
        int source, 
        int sink, 
        int vertexCount,
        MaxFlowAlgorithmTypes maxFlowAlgorithmTypes)
    {
        var residualGraph = GenerateResidualGraph(graph, vertexCount);
        var parent = new int[vertexCount];
        var maxFlow = 0;
        bool hasAugmentedPath;

        do
        {
            hasAugmentedPath = maxFlowAlgorithmTypes switch
            {
                MaxFlowAlgorithmTypes.FordFulkerson =>
                    SearchAlgorithmUtilities.HasFoundAugmentedPathWithDfs(
                        residualGraph,
                        source,
                        sink,
                        parent,
                        vertexCount
                    ),
                MaxFlowAlgorithmTypes.EdmondKarp =>
                    SearchAlgorithmUtilities.HasFoundAugmentedPathWithBfs(
                        residualGraph,
                        source,
                        sink,
                        parent,
                        vertexCount
                    ),
                _ => throw new InvalidOperationException("Invalid algorithm provided")
            };

            if (!hasAugmentedPath) continue;
            maxFlow += CalculatePathFlow(source, sink, parent, residualGraph);
        } while (hasAugmentedPath);

        return maxFlow;
    }

    private static int CalculatePathFlow(int source, int sink, int[] parent, int[,] residualGraph)
    {
        var pathFlow = int.MaxValue;
        int v, u;
        
        for (v = sink; v != source; v = parent[v])
        {
            u = parent[v];
            pathFlow = Math.Min(pathFlow, residualGraph[u, v]);
        }

        // Update residual capacities of the edges and reverse edges
        for (v = sink; v != source; v = parent[v])
        {
            u = parent[v];
            residualGraph[u, v] -= pathFlow;
            residualGraph[v, u] += pathFlow;
        }

        return pathFlow;
    }
    
    private static int[,] GenerateResidualGraph(int[,] graph, int vertexCount)
    {
        int u;
        var residualGraph = new int[vertexCount, vertexCount];

        for (u = 0; u < vertexCount; u++)
        {
            int v;
            for (v = 0; v < vertexCount; v++) residualGraph[u, v] = graph[u, v];
        }

        return residualGraph;
    }
}