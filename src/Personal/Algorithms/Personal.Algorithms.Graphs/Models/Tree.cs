namespace Personal.Algorithms.Graphs.Models;

public class Tree<T>
{
    public Tree(T value, List<Tree<T>> children)
    {
        Value = value;
        Children = children;
    }

    public T Value { get; private set; }

    public List<Tree<T>> Children { get; private set; }

    public IEnumerable<T> GetDFS()
    {
        List<T> orderDFS = new();

        DFS(this, orderDFS);

        return orderDFS;
    }

    public IEnumerable<T> GetBFS()
    {
        List<T> orderBFS = new();

        orderBFS.Add(Value);

        BFS(this, orderBFS);

        return orderBFS;
    }

    private void DFS(Tree<T> tree, List<T> orderDFS)
    {
        foreach (var child in tree.Children)
        {
            DFS(child, orderDFS);
        }

        orderDFS.Add(tree.Value);
    }

    private void BFS(Tree<T> tree, List<T> orderBFS)
    {
        foreach (var child in tree.Children)
        {
            orderBFS.Add(child.Value);
        }

        foreach (var child in tree.Children)
        {
            BFS(child, orderBFS);
        }
    }
}
