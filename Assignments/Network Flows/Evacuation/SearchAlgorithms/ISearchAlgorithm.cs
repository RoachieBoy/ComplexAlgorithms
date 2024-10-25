namespace Evacuation.SearchAlgorithms;

internal interface ISearchAlgorithm
{
    /// <summary>
    ///  Traverses a tree using the implementation of the search algorithm 
    /// </summary>
    /// <param name="startingNode"> node to begin the path from </param>
    /// <param name="children"> children closest to said node </param>
    /// <param name="process"> process the node once it has been visited </param>
    /// <typeparam name="T">Type that the node is </typeparam>
    public static abstract void TraverseTree<T>(T startingNode, Func<T, IEnumerable<T>> children);
}