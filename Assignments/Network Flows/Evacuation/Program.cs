using Evacuation;
using Evacuation.Utilities;

var roads = new List<(int start, int end, int capacity)>
{
    (1, 2, 2), 
    (2, 5, 5), 
    (1, 3, 6), 
    (3, 4, 2), 
    (4, 5, 1), 
    (3, 2, 3),  
    (2, 4, 1)   
};

var cityNetwork = new CityNetwork(5, roads); 
var maxFlow = MaxFlowUtilities.FindMaxFlow(1, 5, cityNetwork.GetNeighbours, 
    cityNetwork.GetRemainingCapacity, cityNetwork.UpdateFlow, SearchAlgorithmType.FordFulkerson);

Console.WriteLine(maxFlow);

