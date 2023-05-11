namespace UncrossedLines
{
    internal class Program
    {
        public class UncrossedLines
        {
            #region DP Solution with optimized
            public int MaxUncrossedLinesDPOptimized(int[] nums1, int[] nums2)
            {
                int n = nums1.Length;
                int m = nums2.Length;
                int[] prev = new int[m + 1];
                for (int i = 0; i < n; ++i)
                {
                    int[] dp = new int[m + 1];
                    for (int j = 0; j < m; ++j)
                    {
                        if (nums1[i] == nums2[j])
                        {
                            dp[j + 1] = 1 + prev[j];
                        }
                        else
                        {
                            dp[j + 1] = Math.Max(dp[j], prev[j + 1]);
                        }
                    }
                    prev = dp;
                }
                return prev[m];
            }
            #endregion

            #region DP Solution
            public int MaxUncrossedLinesDP(int[] nums1, int[] nums2)
            {
                int n = nums1.Length;
                int m = nums2.Length;
                int[,] dp = new int[n + 1, m + 1];
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j)
                    {
                        if (nums1[i] == nums2[j])
                        {
                            dp[i + 1, j + 1] = 1 + dp[i, j];
                        }
                        else
                        {
                            dp[i + 1, j + 1] = Math.Max(dp[i + 1, j], dp[i, j + 1]);
                        }
                    }
                }
                return dp[n, m];
            }
            #endregion

            #region Recursion Solution with Memoization
            private int DFS(int[,] memoized, int[] nums1, int[] nums2, int i, int j)
            {
                if (i == nums1.Length || j == nums2.Length)
                {
                    return 0;
                }
                if (memoized[i, j] != -1)
                {
                    return memoized[i, j];
                }
                if (nums1[i] == nums2[j])
                {
                    memoized[i, j] = 1 + DFS(memoized, nums1, nums2, i + 1, j + 1);
                }
                else
                {
                    memoized[i, j] = Math.Max(DFS(memoized, nums1, nums2, i + 1, j), DFS(memoized, nums1, nums2, i, j + 1));
                }
                return memoized[i, j];
            }
            public int MaxUncrossedLinesRecursionWithMemoization(int[] nums1, int[] nums2)
            {
                int n = nums1.Length;
                int m = nums2.Length;
                int[,] memoized = new int[n, m];
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j)
                    {
                        memoized[i, j] = -1;
                    }
                }
                return DFS(memoized, nums1, nums2, 0, 0);
            }
            #endregion
        }

        static void Main(string[] args)
        {
            // Recursion With Memoization
            UncrossedLines uncrossedLines1 = new();
            Console.WriteLine(uncrossedLines1.MaxUncrossedLinesRecursionWithMemoization(new int[] { 1, 4, 2 }, new int[] { 1, 2, 4 }));
            Console.WriteLine(uncrossedLines1.MaxUncrossedLinesRecursionWithMemoization(new int[] { 2, 5, 1, 2, 5 }, new int[] { 10, 5, 2, 1, 5, 2 }));
            Console.WriteLine(uncrossedLines1.MaxUncrossedLinesRecursionWithMemoization(new int[] { 1, 3, 7, 1, 7, 5 }, new int[] { 1, 9, 2, 5, 1 }));
            // DP Solution
            UncrossedLines uncrossedLines2 = new();
            Console.WriteLine(uncrossedLines2.MaxUncrossedLinesDP(new int[] { 1, 4, 2 }, new int[] { 1, 2, 4 }));
            Console.WriteLine(uncrossedLines2.MaxUncrossedLinesDP(new int[] { 2, 5, 1, 2, 5 }, new int[] { 10, 5, 2, 1, 5, 2 }));
            Console.WriteLine(uncrossedLines2.MaxUncrossedLinesDP(new int[] { 1, 3, 7, 1, 7, 5 }, new int[] { 1, 9, 2, 5, 1 }));
            // DP Optimized Solution
            UncrossedLines uncrossedLines3 = new();
            Console.WriteLine(uncrossedLines3.MaxUncrossedLinesDPOptimized(new int[] { 1, 4, 2 }, new int[] { 1, 2, 4 }));
            Console.WriteLine(uncrossedLines3.MaxUncrossedLinesDPOptimized(new int[] { 2, 5, 1, 2, 5 }, new int[] { 10, 5, 2, 1, 5, 2 }));
            Console.WriteLine(uncrossedLines3.MaxUncrossedLinesDPOptimized(new int[] { 1, 3, 7, 1, 7, 5 }, new int[] { 1, 9, 2, 5, 1 }));
        }
    }
}