namespace Personal.Algorithms.SearchSortGreedy.Models;

public class SortGenerator
{
    // ==================== Ineffective Algorithms ====================
    // Swap each next member of the array with the minimimum value of the rest of the array.
    // O(n2)
    public void SelectionSort(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            var numMin = int.MaxValue;
            var indexMin = i;

            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] < numMin)
                {
                    numMin = numbers[j];
                    indexMin = j;
                }
            }

            if (numMin < numbers[i])
            {
                numbers[indexMin] = numbers[i];
                numbers[i] = numMin;
            }
        }

        Print(numbers);
    }

    // Swap each 2 neighbor elements from left to right if left is greater than the 0.
    // O(n2)
    public void BubbleSort(int[] numbers)
    {
        for (int k = numbers.Length - 1; k > 0; k--)
        {
            for (int i = 0; i < k; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    Swap(numbers, i, i + 1);
                }
            }
        }

        Print(numbers);
    }

    // O(n2)
    public void InsertionSort(int[] numbers)
    {
        for (int i = 1; i < numbers.Length; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (numbers[j] >= numbers[j - 1])
                {
                    break;
                }

                Swap(numbers, j, j - 1);
            }
        }

        Print(numbers);
    }

    // ==================== Effective Algorithms ====================
    public void QuickSort(int[] numbers)
    {
        Print(numbers);
    }

    public void MergeSort(int[] numbers)
    {
        var result = MergeSortRecursively(numbers);

        Print(result);
    }

    private int[] MergeSortRecursively(int[] numbers)
    {
        if (numbers.Length <= 1)
        {
            return numbers;
        }

        var indexMiddle = numbers.Length / 2;
        var leftNumbers = numbers.Take(indexMiddle).ToArray();
        var rightNumbers = numbers.Skip(indexMiddle).ToArray();

        return MergeArrays(MergeSortRecursively(leftNumbers), MergeSortRecursively(rightNumbers));
    }

    private int[] MergeArrays(int[] left, int[] right)
    {
        var merged = new int[left.Length + right.Length];

        var mergedIndex = 0;
        var leftIndex = 0;
        var rightIndex = 0;

        while (leftIndex < left.Length && rightIndex < right.Length)
        {
            if (left[leftIndex] < right[rightIndex])
            {
                merged[mergedIndex++] = left[leftIndex++];
            }
            else
            {
                merged[mergedIndex++] = right[rightIndex++];
            }
        }

        while (leftIndex < left.Length)
        {
            merged[mergedIndex++] = left[leftIndex++];
        }

        while (rightIndex < right.Length)
        {
            merged[mergedIndex++] = right[rightIndex++];
        }

        return merged;
    }

    // ==================== Helper Methods ===================
    private static void Swap(int[] numbers, int pos1, int pos2)
    {
        // var temp = numbers[i];
        // numbers[i] = numbers[i + 1];
        // numbers[i + 1] = temp;

        (numbers[pos2], numbers[pos1]) = (numbers[pos1], numbers[pos2]);
    }

    private static void Print(int[] numbers)
    {
        Console.WriteLine(string.Join(" ", numbers));
    }
}
