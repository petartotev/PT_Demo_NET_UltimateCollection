namespace Personal.Algorithms.Graphs.Models;

public class GraphManager
{
    private readonly Dictionary<string, List<string>> _graphStrings = new()
    {
        { "A", new List<string> { "B", "C" } },
        { "B", new List<string> { "A", "C", "D" } },
        { "C", new List<string> { "A", "B", "E" } },
        { "D", new List<string> { "B" } },
        { "E", new List<string> { "C" } }
    };

    private readonly Tree<string> _treeStrings = new(
        "A",
        new List<Tree<string>>
        {
            new Tree<string>(
                "B",
                 new List<Tree<string>>
                 {
                     new Tree<string>(
                         "D",
                         new List<Tree<string>>()),
                     new Tree<string>(
                         "E",
                         new List<Tree<string>>()),
                     new Tree<string>(
                         "F",
                         new List<Tree<string>>())
                 }),
             new Tree<string>(
                 "C",
                 new List<Tree<string>>
                 {
                     new Tree<string>(
                         "G",
                         new List<Tree<string>>
                         {
                             new Tree<string>(
                                 "I",
                                 new List<Tree<string>>())
                         }),
                     new Tree<string>(
                         "H",
                         new List<Tree<string>>())
                 })
        });

    public void TopologicalSortBySourceRemoval(Dictionary<int, List<int>> graph)
    {

    }

    public void PrintGraphDFS(Dictionary<int, List<int>> graph)
    {
        HashSet<int> visitedNodes = new();

        foreach (var node in graph.Keys)
        {
            DFS(node, graph, visitedNodes);
        }

        Console.WriteLine();
    }

    public void PrintGraphBFS(Dictionary<int, List<int>> graph)
    {
        HashSet<int> visitedNodes = new();

        foreach (var node in graph.Keys)
        {
            BFS(node, graph, visitedNodes);
        }

        Console.WriteLine();
    }

    private static void DFS(int node, Dictionary<int, List<int>> graph, HashSet<int> visited)
    {
        if (visited.Contains(node))
        {
            return;
        }

        visited.Add(node);

        foreach (var child in graph[node])
        {
            DFS(child, graph, visited);
        }

        Console.Write(node + " ");
    }

    private static void BFS(int node, Dictionary<int, List<int>> graph, HashSet<int> visited)
    {
        if (visited.Contains(node))
        {
            return;
        }

        var queue = new Queue<int>();
        queue.Enqueue(node);

        visited.Add(node);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            Console.Write(current + " ");

            foreach (var child in graph[node])
            {
                if (!visited.Contains(child))
                {
                    queue.Enqueue(child);
                    visited.Add(child);
                }
            }
        }
    }
}
