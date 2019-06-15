using System;
using System.Collections.Generic;

namespace FlowerAndMoon
{
    /// <summary>
    /// 花好=Flower=F，月圆=Moon=M
    /// n = 3 -> "FFFMMM"..."MMMFFF","FMFMFM"
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var result = solution.Permute(3);
            foreach (var str in result)
            {
                Console.WriteLine(str);
            }
        }
    }

    class Solution
    {
        //private IList<string> result;

        //public IList<string> Permute(int n)
        //{
        //    result = new List<string>();
        //    DFS(n, 1, 0, "F");
        //    DFS(n, 0, 1, "M");
        //    return result;
        //}

        //private void DFS(int n, int fc, int mc, string solution)
        //{
        //    if(fc == n && mc == n)
        //    {
        //        result.Add(solution);
        //        return;
        //    }

        //    if (fc < n) DFS(n, fc + 1, mc, solution + "F");
        //    if (mc < n) DFS(n, fc, mc + 1, solution + "M");
        //}

        private IList<string> result;

        public IList<string> Permute(int n)
        {
            result = new List<string>();
            DFS(n, 1, 0, "(");// 女士优先
            return result;
        }

        private void DFS(int n, int fc, int mc, string solution)
        {
            if (fc == n && mc == n)
            {
                result.Add(solution);
                return;
            }

            if (fc < n) DFS(n, fc + 1, mc, solution + "(");
            if (mc < fc) DFS(n, fc, mc + 1, solution + ")");
        }
    }
}
