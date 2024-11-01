using System.Diagnostics;

namespace Evacuation;

internal class CityNetwork
{
    private int NumberOfCities { get; set; }
    private IList<Road>[] AdjacencyList { get; set; } = [];

    /// <summary>
    ///  Creates an instance of a CityNetwork that needs to be evacuated.
    /// </summary>
    /// <param name="numberOfCities"> The number of cities in the city network. </param>
    /// <param name="roads"> The roads in the city network. </param>
    internal CityNetwork(int numberOfCities, IList<(int start, int end, int capacity)> roads)
    {
        FillAdjacencyList(numberOfCities);
        InitialiseRoads(roads);
    }
    
    /// <summary>
    ///  Returns the neighbours of the current road where there is still capacity for flow left
    /// </summary>
    internal IEnumerable<int> GetNeighbours(int city)
    {
        return from road in AdjacencyList[city] where road.RemainingCapacity >= 0 select road.EndCity;
    }
    
    /// <summary>
    ///  Returns the remaining capacity of the current road 
    /// </summary>
    internal int GetRemainingCapacity(int startPoint, int endPoint)
    {
        return GetCurrentRoad(startPoint, endPoint).RemainingCapacity;
    }

    internal void UpdateFlow(int startPoint, int endPoint, int currentFlow)
    {
        var road = GetCurrentRoad(startPoint, endPoint);
        road.CurrentFlow += currentFlow;
        road.Reversed.CurrentFlow -= currentFlow;
    }
    
    private Road GetCurrentRoad(int startPoint, int endPoint)
    {
        return AdjacencyList[startPoint].FirstOrDefault(road => road.EndCity == endPoint) 
               ?? throw new InvalidOperationException("No road found");
    }

    private void InitialiseRoads(IList<(int start, int end, int capacity)> roads)
    {
        if (roads.Count < 1)
        {
            return;
        }

        foreach (var road in roads) 
        {
            CreateRoad(road.start, road.end, road.capacity);
        }
    }

    private void FillAdjacencyList(int numberOfCities)
    {
        if (numberOfCities < 1)
        {
            Debug.WriteLine($"{nameof(numberOfCities)} must be greater than 0");
            return; 
        }
        
        NumberOfCities = numberOfCities; 
        AdjacencyList = new IList<Road>[NumberOfCities + 1];
        
        for (var i = 1; i <= numberOfCities; i++)
        {
            AdjacencyList[i] = new List<Road>();
        }
    }

    /// <summary>
    ///  Initialises a new instance of a road and adds the forward and reversed
    ///  path of this road to the adjacency list 
    /// </summary>
    /// <param name="startPoint"> the starting location of the road </param>
    /// <param name="endPoint"> the location the road leads to </param>
    /// <param name="hourlyCapacity"> the maximum hourly capacity of the road </param>
    private void CreateRoad(int startPoint, int endPoint, int hourlyCapacity)
    {
        var forwardRoad = new Road(startPoint, endPoint, hourlyCapacity);
        // Capacity has a starting value of 0 because you can't go backwards before you have gone forwards 
        var backwardRoad = new Road(endPoint, startPoint, 0);
        
        forwardRoad.Reversed = backwardRoad;
        backwardRoad.Reversed = forwardRoad;
        
        // Represents the path forward from the starting city to the main city
        AdjacencyList[startPoint].Add(forwardRoad);
        // Represents the path reversed from the starting city to the main city
        AdjacencyList[endPoint].Add(backwardRoad);
    }
}