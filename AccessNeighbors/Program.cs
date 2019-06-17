using System;

namespace AccessNeighbors
{
    class Program
    {
        /// <summary>
        /// 访问二维数组四邻
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[][] m =
            {
                new[] {1, 2, 3, 4},
                new[] {5, 6, 7, 8},
                new[] {9, 10, 11, 12}
            };

            var solution = new Solution();
            solution.AccessNeighbors(m);
        }
    }

    //class Solution
    //{
    //    public void AccessNeighbors(int[][] m)
    //    {
    //        int h = m.Length, w = m[0].Length;
    //        for (int r = 0; r < h; r++)
    //        {
    //            for (int c = 0; c < w; c++)
    //            {
    //                Console.Write($"Home:{m[r][c]}\t");
    //                if (r - 1 >= 0) Console.Write($"{m[r - 1][c]}\t");
    //                if (r + 1 < h) Console.Write($"{m[r + 1][c]}\t");
    //                if (c - 1 >= 0) Console.Write($"{m[r][c - 1]}\t");
    //                if (c + 1 < w) Console.Write($"{m[r][c + 1]}");
    //                Console.WriteLine();
    //            }
    //        }
    //    }
    //}
    class Solution
    {
        public void AccessNeighbors(int[][] m)
        {
            int h = m.Length, w = m[0].Length;
            int[][] directions = {new[] {-1, 0}, new[] {1, 0}, new[] {0, -1}, new[] {0, 1}};
            for (int r = 0; r < h; r++)
            {
                for (int c = 0; c < w; c++)
                {
                    Console.Write($"Home:{m[r][c]}\t");
                    foreach (var dir in directions)
                    {
                        int nr = r + dir[0], nc = c + dir[1];
                        if(nr>=0 && nr<h && nc>=0 && nc<w)
                            Console.Write($"{m[nr][nc]}\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }

    //作业：访问八家邻居
}
