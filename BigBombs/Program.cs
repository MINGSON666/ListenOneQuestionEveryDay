using System;
using System.Collections.Generic;

namespace BigBombs
{
    /// <summary>
    /// 连环引爆炸弹，每次引爆一个炸弹会连锁引爆上下左右四颗炸弹
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 1代表炸弹
            int[][] field =
            {
                new[] {0, 1, 0, 0, 0, 0,},
                new[] {0, 1, 0, 0, 0, 0,},
                new[] {1, 1, 1, 1, 0, 0,},
                new[] {0, 0, 1, 0, 0, 0,},
                new[] {0, 1, 1, 1, 1, 1,},
                new[] {1, 1, 1, 1, 1, 1,},
            };

            View(field);
            var solution = new Solution();
            var result = solution.DetonateBombs(field, 0, 2);
            View(field);
        }

        static void View(int[][] field)
        {
            foreach (var r in field)
            {
                Console.WriteLine(string.Join(' ', r));
            }
        }
    }

    class Solution
    {
        /// <summary>
        /// 引爆炸弹
        /// </summary>
        /// <param name="field"></param>
        /// <param name="row">引爆炸弹的行</param>
        /// <param name="col">引爆炸弹的列</param>
        /// <returns>剩余炸弹数</returns>
        public int DetonateBombs(int[][] field, int row, int col)
        {
            int h = field.Length, w = field[0].Length;
            int[][] directions = { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };
            field[row][col] = 0;
            var q = new Queue<int>();
            q.Enqueue(row);
            q.Enqueue(col);
            while (q.Count > 0)
            {
                int cr = q.Dequeue(), cc = q.Dequeue();
                foreach (var dir in directions)
                {
                    int nr = cr + dir[0], nc = cc + dir[1];
                    if (nr >= 0 && nr < h && nc >= 0 && nc < w)
                    {
                        if (field[nr][nc] == 1)
                        {
                            field[nr][nc] = 0;
                            q.Enqueue(nr);
                            q.Enqueue(nc);
                        }
                    }
                }
            }

            int counter = 0;

            for (int r = 0; r < h; r++)
            {
                for (int c = 0; c < w; c++)
                {
                    counter += field[r][c];
                }
            }

            return counter;
        }
    }

    //作业：深度优先解法
}
