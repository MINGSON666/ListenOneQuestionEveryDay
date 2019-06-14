using System;

namespace ApplePeeler
{
    /// <summary>
    /// 将二维数组螺旋展开为一维数组
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[][] m = new[]
            {
                new[] {1, 2, 3, 4},
                new[] {10, 11, 12, 5},
                new[] {9, 8, 7, 6}
            };
            var result = ApplePeeler.Peel(m);
            Console.WriteLine(string.Join("->",result));
        }
    }

    public class ApplePeeler
    {
        public static int[] Peel(int[][] m)
        {
            if (m == null) return new int[0];
            int sr = 0, sc = 0, h = m.Length, w = m[0].Length, p = 0;
            int[] result = new int[h * w];
            while (true)
            {
                if (h == 0 || w == 0) break;
                for (int c = sc; c < sc+w; c++)
                    result[p++] = m[sr][c];
                sr += 1;
                h -= 1;
                if (h == 0 || w == 0) break;
                for (int r = sr; r < sr + h; r++)
                    result[p++] = m[r][sc+w-1];
                w -= 1;
                if (h == 0 || w == 0) break;
                for (int c = sc + w - 1; c >= sc; c--)
                    result[p++] = m[sr + h - 1][c];
                h -= 1;
                if (h == 0 || w == 0) break;
                for (int r = sr + h - 1; r >= sr; r--)
                    result[p++] = m[r][sc];
                sc += 1;
                w -= 1;
            }

            return result;
        }
    }
}
