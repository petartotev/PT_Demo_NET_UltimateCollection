namespace Personal.Algorithms.SearchSortGreedy.Models;

public class SearchGenerator
{
    public int LinearSearch(int[] array, int numToFind)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == numToFind)
            {
                return i;
            }
        }

        return -1;
    }

    public int BinarySearch(int[] array, int numToFind)
    {
        int start = 0;
        int end = array.Length - 1;

        while (start <= end)
        {
            int middle = (start + end) / 2;

            if (array[middle] == numToFind)
            {
                return middle;
            }
            else if (array[middle] < numToFind)
            {
                start = middle + 1;
            }
            else
            {
                end = middle - 1;
            }
        }

        return -1;
    }
}
