using Personal.Algorithms.Graphs.Models;

GraphManager myGraphManager = new();

Dictionary<int, List<int>> graphIntegers = new()
{
    { 1, new List<int> { 19, 21, 14 } },
    { 19, new List<int> { 7, 12, 31, 21 } },
    { 7, new List<int> { 1 } },
    { 12, new List<int>() },
    { 21, new List<int> { 14 } },
    { 31, new List<int> { 21 } },
    { 14, new List<int> { 23, 6 } },
    { 23, new List<int> { 21 } },
    { 6, new List<int>() },
};

myGraphManager.PrintGraphDFS(graphIntegers);
myGraphManager.PrintGraphBFS(graphIntegers);

DijkstraShortestPathFinder dijkstraShortestPathFinder = new();

int[,] graph = new int[,]
{
    //       A   B   C   D   E   F   G   H   I
    /*A*/ {  0,  4,  0,  0,  0,  0,  0,  8,  0 },
    /*B*/ {  4,  0,  8,  0,  0,  0,  0, 11,  0 },
    /*C*/ {  0,  8,  0,  7,  0,  4,  0,  0,  2 },
    /*D*/ {  0,  0,  7,  0,  9, 14,  0,  0,  0 },
    /*E*/ {  0,  0,  0,  9,  0, 10,  0,  0,  0 },
    /*F*/ {  0,  0,  4, 14, 10,  0,  2,  0,  0 },
    /*G*/ {  0,  0,  0,  0,  0,  2,  0,  1,  6 },
    /*H*/ {  8, 11,  0,  0,  0,  0,  1,  0,  7 },
    /*I*/ {  0,  0,  2,  0,  0,  0,  6,  7,  0 }
};

int[,] graph2 = new int[,]
{
    //       A   B   C   D   E   F
    /*A*/ {  0,  3,  2,  0,  0,  0 },
    /*B*/ {  3,  0,  4,  7,  6,  0 },
    /*C*/ {  2,  4,  0,  9,  0,  0 },
    /*D*/ {  0,  7,  9,  0,  3,  4 },
    /*E*/ {  0,  6,  0,  3,  0,  6 },
    /*F*/ {  0,  0,  0,  4,  6,  0 }
};

int[,] graph3 = new int[,]
{
    //       A   B   C   D   E   F
    /*A*/ {  0,  3,  4,  0,  0,  0 },
    /*B*/ {  3,  0,  8,  4,  5,  0 },
    /*C*/ {  4,  8,  0,  0,  2,  0 },
    /*D*/ {  0,  4,  0,  0,  3,  2 },
    /*E*/ {  0,  5,  2,  3,  0,  4 },
    /*F*/ {  0,  0,  0,  2,  4,  0 }
};

dijkstraShortestPathFinder.FindShortestPath(graph3);