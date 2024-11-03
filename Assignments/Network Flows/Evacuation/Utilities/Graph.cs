using System.Numerics;

namespace Evacuation.Utilities;

public class Graph<T>(int numberOfNodes) where T : INumber<T>
{
    private readonly T[,] _adjacencyMatrix = new T[numberOfNodes, numberOfNodes];

    public int NumberOfNodes => _adjacencyMatrix.GetLength(0);

    public void AddEdge(int startNode, int endNode, T capacity)
    {
        _adjacencyMatrix[startNode, endNode] = capacity;
    }

    public T[,] GetAdjacencyMatrix()
    {
        return _adjacencyMatrix;
    }
}