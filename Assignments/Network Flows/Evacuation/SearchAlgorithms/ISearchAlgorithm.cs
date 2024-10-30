namespace Evacuation.SearchAlgorithms;

internal interface ISearchAlgorithm
{
    /// <summary>
    ///  Traverses a tree using the implementation of a given search algorithm 
    /// </summary>
    /// <param name="startingNode"> Node to begin the path from. </param>
    /// <param name="children"> Children closest to said node. </param>
    /// <typeparam name="T">Type that represents a node in the graph. </typeparam>
    public static abstract void TraverseTree<T>(T startingNode, Func<T, IEnumerable<T>> children);
}