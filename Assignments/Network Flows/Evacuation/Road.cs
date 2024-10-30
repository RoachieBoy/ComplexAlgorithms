namespace Evacuation;

internal class Road
{
    /// <summary>
    ///  The point on the graph from which the road begins
    /// </summary>
    private int StartPoint { get; set; }
    
    /// <summary>
    ///  The point on the graph where the road ends
    /// </summary>
    private int EndPoint { get; set; }
    
    /// <summary>
    ///  The maximum capacity a road can handle at any given hour 
    /// </summary>
    private int HourlyCapacity{ get; }
    
    /// <summary>
    ///  The current flow of people on the road 
    /// </summary>
    internal int CurrentFlow { get; set; }

    /// <summary>
    ///  The remaining capacity still left on the road 
    /// </summary>
    internal int RemainingCapacity => HourlyCapacity - CurrentFlow;
    
    internal Road(int startPoint, int endPoint, int hourlyCapacity)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
        HourlyCapacity = hourlyCapacity;
    }
}