using System.Diagnostics;

namespace Evacuation;

internal class CityNetwork
{
    /// <summary>
    ///  Number of cities that are contained within the network 
    /// </summary>
    private int NumberOfCities { get; set; }

    /// <summary>
    ///  A collection of lists where each index represents a city in the network
    ///  and each list is made up of roads that connect the city to other cities 
    /// </summary>
    private IList<Road>[] AdjacencyList { get; set; }

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

    private void InitialiseRoads(IList<(int start, int end, int capacity)> roads)
    {
        if (roads.Count > 1)
        {
            Debug.WriteLine($"{nameof(roads)} is empty, but a ciy network must contain at least one road.");
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
        
        // Represents the path forward from the starting city to the main city
        AdjacencyList[startPoint].Add(forwardRoad);
        // Represents the path reversed from the starting city to the main city
        AdjacencyList[endPoint].Add(backwardRoad);
    }
}