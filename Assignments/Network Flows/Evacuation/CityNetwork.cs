namespace Evacuation;

internal class CityNetwork
{
    /// <summary>
    ///  Number of cities that are contained within the network 
    /// </summary>
    private int NumberOfCities { get; }
    
    /// <summary>
    ///  A collection of lists where each index represents a city in the network
    ///  and each list is made up of roads that connect the city to other cities 
    /// </summary>
    private IList<Road>[] AdjacencyList { get; }

    internal CityNetwork(int numberOfCities)
    {
        if (numberOfCities < 1) return;
        
        NumberOfCities = numberOfCities;
        AdjacencyList = new IList<Road>[NumberOfCities + 1];

        // Fill the adjacency list with the necessary amount of roads 
        for (var i = 0; i <= numberOfCities; i++)
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
    internal void InitialiseRoad(int startPoint, int endPoint, int hourlyCapacity)
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