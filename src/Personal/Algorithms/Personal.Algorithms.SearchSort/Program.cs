using Personal.Algorithms.SearchSortGreedy.Models;

// Search
var mySearchGenerator = new SearchGenerator();

var arrayToSearchIn = new int[] { 1, 2, 5, 9, 13, 17, 19, 27, 37, 44, 55, 99, 103 };
var numToSearchFor = 55;

var resultLinear = mySearchGenerator.LinearSearch(arrayToSearchIn, numToSearchFor);
Console.WriteLine(resultLinear);

var resultBinary = mySearchGenerator.BinarySearch(arrayToSearchIn, numToSearchFor);
Console.WriteLine(resultBinary);

// Sort
var mySortGenerator = new SortGenerator();

var arrayToSort = new int[] { 15, 14, 7, 10, 3, 33, 66, 107, 27, 8 };
var arrayToSort2 = new int[] { 15, 14, 7, 10, 3, 33, 66, 107, 27, 8 };
var arrayToSort3 = new int[] { 15, 14, 7, 10, 3, 33, 66, 107, 27, 8 };
var arrayToSort4 = new int[] { 15, 14, 7, 10, 3, 33, 66, 107, 27, 8 };

mySortGenerator.SelectionSort(arrayToSort);

mySortGenerator.BubbleSort(arrayToSort2);

mySortGenerator.InsertionSort(arrayToSort3);

mySortGenerator.MergeSort(arrayToSort4);