namespace Personal.Algorithms.Graphs.Models;

public class DijkstraShortestPathFinder
{
    public void FindShortestPath(int[,] network)
    {
        if (network.GetLength(0) != network.GetLength(1))
        {
            throw new ArgumentException("Graph represented as matrix must have equal number of rows and cols.");
        }

        int networkLength = network.GetLength(0);

        int[] distances = new int[networkLength];

        for (int i = 1; i < networkLength; i++)
        {
            distances[i] = int.MaxValue;
        }

        bool[] isShortestPathFound = new bool[networkLength];

        for (int count = 0; count < networkLength - 1; count++)
        {
            int minDistanceIndex = FindMinDistanceIndex(distances, isShortestPathFound);

            isShortestPathFound[minDistanceIndex] = true;

            for (int i = 0; i < networkLength; i++)
            {
                if (!isShortestPathFound[i] &&
                    network[minDistanceIndex, i] != 0 &&
                    distances[minDistanceIndex] != int.MaxValue &&
                    distances[minDistanceIndex] + network[minDistanceIndex, i] < distances[i])
                {
                    distances[i] = distances[minDistanceIndex] + network[minDistanceIndex, i];
                }
            }
        }

        Print(distances);
    }

    private static int FindMinDistanceIndex(int[] distances, bool[] isShortestFound)
    {
        int minIndex = -1;
        int minValue = int.MaxValue;

        for (int i = 0; i < distances.GetLength(0); i++)
        {
            if (!isShortestFound[i] && distances[i] <= minValue)
            {
                minValue = distances[i];
                minIndex = i;
            }
        }

        return minIndex;
    }

    private static void Print(int[] distances)
    {
        Console.Write("Node\tDistance\n");

        for (int i = 0; i < distances.GetLength(0); i++)
        {
            Console.Write($"{i}\t{distances[i]}\n");
        }
    }
}
