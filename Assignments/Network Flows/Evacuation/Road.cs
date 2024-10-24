namespace Evacuation;

internal class Road
{
    internal int StartPoint { get; private set; }
    internal int EndPoint { get; private set; }
    internal int HourlyCapacity{ get; private set; }

    internal Road(int startPoint, int endPoint, int hourlyCapacity)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
        HourlyCapacity = hourlyCapacity;
    }
}