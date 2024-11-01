using System.Diagnostics;
using Evacuation.Utilities;

var stopwatch = Stopwatch.StartNew();

// sample one from assignment 
var graph = new[,]
{
    { 0, 2, 6, 0, 0 },
    { 0, 0, 0, 1, 5 },
    { 0, 3, 0, 2, 0 },
    { 0, 0, 0, 0, 1 },
    { 0, 0, 0, 0, 0 }
};

// sample 2 from assignment 
var graph2 = new[,]
{
    { 0, 10000, 10000, 0 },
    { 0, 0, 1, 10000 },
    { 0, 0, 0, 10000 },
    { 0, 0, 0, 0 }
};

var maxFlow = MaxFlowUtilities.FindMaxFlow(graph, 0, 4, 5, MaxFlowAlgorithmTypes.EdmondKarp);
var maxFlowFulkerson = MaxFlowUtilities.FindMaxFlow(graph2, 0, 3, 4, MaxFlowAlgorithmTypes.FordFulkerson);

stopwatch.Stop();

Console.WriteLine(maxFlow); 
Console.WriteLine(maxFlowFulkerson);
Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms"); 



