using System;
using System.Collections.Generic;
using System.IO;

class HistorianHysteria
{
    static void Main(string[] args)
    {
        string filePath = "input.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"The file doesn't exist in the path: {filePath}");
            return;
        }

        // Lists for the two columns of numbers
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();

        try
        {
            foreach (string line in File.ReadLines(filePath))
            {
                var numbers = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (numbers.Length == 2)
                {
                    leftList.Add(int.Parse(numbers[0]));
                    rightList.Add(int.Parse(numbers[1]));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al procesar el archivo: {ex.Message}");
            return;
        }

        // Part 1: Calculate the total distance between the lists
        if (leftList.Count != rightList.Count)
        {
            Console.WriteLine("The lists have different numbers of elements");
            return;
        }

        leftList.Sort();
        rightList.Sort();

        int totalDistance = 0;
        for (int i = 0; i < leftList.Count; i++)
        {
            totalDistance += Math.Abs(leftList[i] - rightList[i]);
        }

        Console.WriteLine($"The total distance between the lists is: {totalDistance}");

        // Part 2: Calculate the similarity score between the lists
        Dictionary<int, int> rightCounts = new Dictionary<int, int>();
        foreach (int num in rightList)
        {
            if (rightCounts.ContainsKey(num))
            {
                rightCounts[num]++;
            }
            else
            {
                rightCounts[num] = 1;
            }
        }

        long similarityScore = 0;
        foreach (int num in leftList)
        {
            if (rightCounts.ContainsKey(num))
            {
                similarityScore += num * rightCounts[num];
            }
        }

        Console.WriteLine($"The similarity score between the lists is: {similarityScore}");
    }
}
