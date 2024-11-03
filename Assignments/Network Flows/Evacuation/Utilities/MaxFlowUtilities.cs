using System.Numerics;

namespace Evacuation.Utilities;

public static class MaxFlowUtilities
{
    /// <summary>
    ///     Find the max flow for a given graph/network.
    /// </summary>
    /// <param name="graph"> The graph to analyse. </param>
    /// <param name="source"> The source node of the graph. </param>
    /// <param name="sink"> The end node of the graph. </param>
    /// <param name="maxFlowAlgorithmTypes"> Which type of max flow algorithm to implement to calculate the max flow. </param>
    /// <returns> An int representing the max flow of the graph. </returns>
    public static T FindMaxFlow<T>(
        Graph<T> graph,
        int source,
        int sink,
        MaxFlowAlgorithmTypes maxFlowAlgorithmTypes)
        where T : INumber<T>
    {
        var residualGraph = GenerateResidualGraph(graph);
        var parent = new int[graph.NumberOfNodes];
        var maxFlow = T.Zero;
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
                        graph.NumberOfNodes
                    ),
                MaxFlowAlgorithmTypes.EdmondKarp =>
                    SearchAlgorithmUtilities.HasFoundAugmentedPathWithBfs(
                        residualGraph,
                        source,
                        sink,
                        parent,
                        graph.NumberOfNodes
                    ),
                _ => throw new InvalidOperationException("Invalid algorithm provided")
            };

            if (!hasAugmentedPath) continue;
            maxFlow += CalculatePathFlow(source, sink, parent, residualGraph);
        } while (hasAugmentedPath);

        return maxFlow;
    }

    private static T CalculatePathFlow<T>(
        int source,
        int sink,
        int[] parent,
        T[,] residualGraph)
        where T : INumber<T>
    {
        var pathFlow = NumericalUtilities.MaxValue<T>();
        int v, u;

        for (v = sink; v != source; v = parent[v])
        {
            u = parent[v];
            pathFlow = T.Min(pathFlow, residualGraph[u, v]);
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

    private static T[,] GenerateResidualGraph<T>(Graph<T> graph) where T : INumber<T>
    {
        int u;
        var vertexCount = graph.NumberOfNodes;
        var residualGraph = new T[vertexCount, vertexCount];

        for (u = 0; u < vertexCount; u++)
        {
            int v;
            for (v = 0; v < vertexCount; v++) residualGraph[u, v] = graph.GetAdjacencyMatrix()[u, v];
        }

        return residualGraph;
    }
}