using System.Diagnostics;
using NetworkFlowsUtilities;

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

stopwatch.Reset();
stopwatch.Start();

var testGraph2 = new Graph<int>(4);
testGraph2.AddEdge(0, 1, 10000);
testGraph2.AddEdge(0, 2, 10000);
testGraph2.AddEdge(1, 2, 1);
testGraph2.AddEdge(1, 3, 10000);
testGraph2.AddEdge(2, 3, 10000);

var maxFlow2 = MaxFlowUtilities.FindMaxFlow(testGraph2, 0, 3, MaxFlowAlgorithmTypes.EdmondKarp);

Console.WriteLine(maxFlow2);
Console.WriteLine($"Time taken second test: {stopwatch.ElapsedMilliseconds} ms");


