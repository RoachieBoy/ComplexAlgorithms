namespace Evacuation;

internal class CityNetwork
{
    internal int NumberOfCities { get; set; }
    internal int NumberOfRoads { get; set; }
    private IList<Road> Roads { get; set; }

    internal CityNetwork(int numberOfCities, int numberOfRoads)
    {
        NumberOfCities = numberOfCities;
        NumberOfRoads = numberOfRoads; 
        Roads = new List<Road>();
    }

    internal void InitialiseRoad(int startPoint, int endPoint, int hourlyCapacity) 
            => Roads.Add(new Road(startPoint, endPoint, hourlyCapacity));
}