using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using NetworkFlowsUtilities;

namespace Evacuation;

[MemoryDiagnoser]
public class CalculateMaxFlow
{
    [Benchmark]
    public int CreateTestDataSampleOne()
    {
        var testGraph = new Graph<int>(5);
        testGraph.AddEdge(0, 1, 2);
        testGraph.AddEdge(0, 2, 6);
        testGraph.AddEdge(1, 3, 1);
        testGraph.AddEdge(1, 4, 5);
        testGraph.AddEdge(2, 1, 3);
        testGraph.AddEdge(2, 3, 2);
        testGraph.AddEdge(3, 4, 1);
        
        return MaxFlowUtilities.FindMaxFlow(testGraph, 0, 4, MaxFlowAlgorithmTypes.FordFulkerson);
    }

    [Benchmark]
    public int CreateTestDataSampleTwo()
    {
        var testGraph2 = new Graph<int>(4);
        testGraph2.AddEdge(0, 1, 10000);
        testGraph2.AddEdge(0, 2, 10000);
        testGraph2.AddEdge(1, 2, 1);
        testGraph2.AddEdge(1, 3, 10000);
        testGraph2.AddEdge(2, 3, 10000);

        return MaxFlowUtilities.FindMaxFlow(testGraph2, 0, 3, MaxFlowAlgorithmTypes.EdmondKarp);
    }
}

internal static class Program
{ 
    private static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<CalculateMaxFlow>();
        Console.WriteLine(summary);
        
        var maxFlowCalculator = new CalculateMaxFlow(); 
        var sampleOne = maxFlowCalculator.CreateTestDataSampleOne();
        var sampleTwo = maxFlowCalculator.CreateTestDataSampleTwo();
        
        Console.WriteLine($"\n{sampleOne}");
        Console.WriteLine(sampleTwo);
    }
}