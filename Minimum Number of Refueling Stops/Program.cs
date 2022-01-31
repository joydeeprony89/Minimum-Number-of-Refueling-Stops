using System;

namespace Minimum_Number_of_Refueling_Stops
{
  class Program
  {
    // https://leetcode.com/problems/minimum-number-of-refueling-stops/discuss/294025/Java-Simple-Code-Greedy
    // https://leetcode.com/problems/minimum-number-of-refueling-stops/discuss/149839/DP-O(N2)-and-Priority-Queue-O(NlogN)
    // https://www.youtube.com/watch?v=4RgqAQFr9WQ
    static void Main(string[] args)
    {
      Program p = new Program();
      int target = 80;
      int startFuel = 35;
      int[][] stations = new int[][] { new int[] { 10, 25 }, new int[] { 20, 12 }, new int[] { 30, 21 }, new int[] { 40, 5 }, new int[] { 50, 3 } };
      Console.WriteLine(p.MinRefuelStops(target, startFuel, stations));
    }

    public int MinRefuelStops(int target, int startFuel, int[][] stations)
    {
      int n = stations.Length;
      long[] dp = new long[n + 1];
      dp[0] = startFuel;

      for (int i = 0; i < n; i++)
      {
        for (int f = i; f >= 0 && dp[f] >= stations[i][0]; f--)
        {
          dp[f + 1] = Math.Max(dp[f + 1], stations[i][1] + dp[f]);
        }
      }

      for(int i = 0; i < dp.Length; i++)
      {
        if (dp[i] >= target) return i;
      }

      return -1;
    }
  }
}
