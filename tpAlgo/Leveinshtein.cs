using System;

namespace Levenshtein
{
    public class LevenshteinDP
    {
        public LevenshteinDP()
        {
        }

        public static int ComputeLevenshteinDistanceDP(string str1, string str2)
        {
            int[,] dp = new int[str1.Length + 1, str2.Length + 1];

            int i, j;
            for (i = 0; i <= str1.Length; ++i)
            {
                for (j = 0; j <= str2.Length; ++j)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = i;
                    }
                    else
                    {
                        dp[i, j] = Mini(dp[i - 1, j - 1] + Cost(str1[i - 1], str2[j - 1]), dp[i - 1, j] + 1, dp[i, j - 1] + 1);
                    }
                }
            }

            Console.Write("\t\t");

            for (i = 0; i < str2.Length; ++i)
            {
                Console.Write(str2[i] + "\t");
            }

            Console.WriteLine("");

            for (i = 0; i <= str1.Length; ++i)
            {
                if (i >= 1)
                {
                    Console.Write(str1[i - 1]);
                }

                Console.Write("\t");

                for (j = 0; j <= str2.Length; ++j)
                {
                    Console.Write(dp[i, j] + "\t");
                }

                Console.WriteLine();
            }

            return dp[str1.Length, str2.Length];
        }

        public static int Cost(char c1, char c2)
        {
            return c1 == c2 ? 0 : 1;
        }

        public static int Mini(params int[] nums)
        {
            return nums.Min();
        }

    }
}
