using System;
using System.Collections.Generic;

namespace BlueBlueWorld
{
    /// <summary>
    /// 计算海平面升高后所剩岛屿数量
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 数字代表当前岛屿海拔
            int[][] sea =
            {
                new[] {0, 1, 0, 0, 0, 0},
                new[] {0, 2, 0, 0, 0, 0},
                new[] {2, 3, 2, 3, 0, 0},
                new[] {0, 0, 4, 0, 0, 0},
                new[] {0, 2, 1, 2, 3, 1},
                new[] {2, 2, 1, 1, 2, 1},
            };

            var solution = new Solution();
            var result = solution.CountIslands(sea,2);
            Console.WriteLine(result);
        }
    }

    class Solution
    {
        public int CountIslands(int[][] sea, int level)
        {
            int h = sea.Length, w = sea[0].Length;
            int[][] directions = { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };
            for (int r = 0; r < h; r++)
            {
                for (int c = 0; c < w; c++)
                {
                    sea[r][c] = sea[r][c] > level ? 1 : 0;
                }
            }

            int counter = 0;
            for (int r = 0; r < h; r++)
            {
                for (int c = 0; c < w; c++)
                {
                    if (sea[r][c] == 0) continue;
                    counter++;
                    var q = new Queue<int>();
                    sea[r][c] = 0;
                    q.Enqueue(r);
                    q.Enqueue(c);
                    while (q.Count > 0)
                    {
                        int cr = q.Dequeue(), cc = q.Dequeue();
                        foreach (var dir in directions)
                        {
                            int nr = cr + dir[0], nc = cc + dir[1];
                            if (nr >= 0 && nr < h && nc >= 0 && nc < w)
                            {
                                if (sea[nr][nc] == 1)
                                {
                                    sea[nr][nc] = 0;
                                    q.Enqueue(nr);
                                    q.Enqueue(nc);
                                }
                            }
                        }
                    }
                }
            }

            return counter;
        }
    }

    // 作业：深度优先和并查集
}
