using Evacuation;

var roads = new List<(int StartPoint, int EndPoint, int HourlyCapacity)>
{
    (1, 2, 10),
    (2, 3, 15),
    (3, 4, 20),
    (4, 5, 25),
    (5, 1, 30)
};

var city = new CityNetwork(5, roads); 

// test code
Console.WriteLine(city);

