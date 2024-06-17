namespace Personal.General.Hash;

public class SimpleHashTable<TKey, TValue>
{
    private const int Size = 100;
    private readonly LinkedList<KeyValuePair<TKey, TValue>>[] items;

    public SimpleHashTable()
    {
        items = new LinkedList<KeyValuePair<TKey, TValue>>[Size];

        for (int i = 0; i < Size; i++)
        {
            items[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
        }
    }

    public void Add(TKey key, TValue value)
    {
        var position = GetArrayPosition(key);

        LinkedList<KeyValuePair<TKey, TValue>> linkedList = items[position];
        
        var item = new KeyValuePair<TKey, TValue>(key, value);
        
        linkedList.AddLast(item);
    }

    public TValue Get(TKey key)
    {
        var position = GetArrayPosition(key);

        LinkedList<KeyValuePair<TKey, TValue>> linkedList = items[position];

        foreach (KeyValuePair<TKey, TValue> pair in linkedList)
        {
            if (pair.Key.Equals(key))
            {
                return pair.Value;
            }
        }

        return default(TValue);
    }

    private static int GetArrayPosition(TKey key)
    {
        int hash = key.GetHashCode();
        int position = hash % Size;
        return Math.Abs(position);
    }
}
