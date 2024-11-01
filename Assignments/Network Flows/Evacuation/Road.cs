namespace Evacuation;

internal class Road
{
    /// <summary>
    ///  The point on the graph where the road ends 
    /// </summary>
    internal int EndCity { get; }
    /// <summary>
    ///  The current flow of people on the road 
    /// </summary>
    internal int CurrentFlow { get; set; }
    /// <summary>
    ///  Represents the road in its reversed trajectory 
    /// </summary>
    internal Road Reversed { get; set; }
    private int HourlyCapacity{ get; }
    private int StartCity { get; set; }
    
    /// <summary>
    ///  The remaining capacity still left on the road 
    /// </summary>
    internal int RemainingCapacity => HourlyCapacity - CurrentFlow;
    
    internal Road(int startCity, int endCity, int hourlyCapacity)
    {
        StartCity = startCity;
        EndCity = endCity;
        HourlyCapacity = hourlyCapacity;
    }
}