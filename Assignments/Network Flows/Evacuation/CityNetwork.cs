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
        NumberOfCities = numberOfCities;
        AdjacencyList = new IList<Road>[NumberOfCities + 1];

        // Fill the adjacency list with the necessary amount of roads 
        for (var i = 0; i <= numberOfCities; i++)
        {
            AdjacencyList[i] = new List<Road>();
        }
    }

    internal void InitialiseRoad(int startPoint, int endPoint, int hourlyCapacity, IList<Road> roads)
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