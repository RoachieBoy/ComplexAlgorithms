using System.Diagnostics;
using Evacuation;
using Evacuation.Utilities;

var stopwatch = Stopwatch.StartNew();

var testGraph = new Graph<int>(5);
testGraph.AddEdge(0, 1, 2);
testGraph.AddEdge(0, 2, 6);
testGraph.AddEdge(1, 3, 1);
testGraph.AddEdge(1, 4, 5);
testGraph.AddEdge(2, 1, 3);
testGraph.AddEdge(2, 3, 2);
testGraph.AddEdge(3, 4, 1);


var maxFlow = MaxFlowUtilities.FindMaxFlow(testGraph, 0, 4, MaxFlowAlgorithmTypes.FordFulkerson);

stopwatch.Stop();

Console.WriteLine(maxFlow);
Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");