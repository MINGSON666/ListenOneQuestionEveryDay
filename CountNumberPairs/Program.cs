using System;
using System.Collections.Generic;

namespace CountNumberPairs
{
    /// <summary>
    /// 统计数组中多少对数字加起来等于520，每个数字使用一次
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {20, 260, 20, 260, 500, 500};
            var count = Count(nums);
            Console.WriteLine(count);
        }

        static int Count(int[] nums)
        {
            if (nums == null)
            {
                return 0;
            }
            var counter = 0;
            var dict = new int[521];
            foreach (var n in nums)
            {
                var diff = 520 - n;
                if (dict[diff] > 0)
                {
                    counter++;
                    dict[diff]--;
                }
                else
                {
                    dict[n]++;
                }
            }

            return counter;
        }
        
        //static int Count(int[] nums)
        //{
        //    if (nums == null)
        //    {
        //        return 0;
        //    }
        //    var counter = 0;
        //    var dict = new Dictionary<int, int>();
        //    foreach (var n in nums)
        //    {
        //        var diff = 520 - n;
        //        if (dict.ContainsKey(diff))
        //        {
        //            counter++;
        //            //dict[diff]--;
        //            //if (dict[diff] == 0)
        //            if (--dict[diff] == 0)
        //            {
        //                dict.Remove(diff);
        //            }
        //        }
        //        else
        //        {
        //            if (!dict.ContainsKey(n))
        //            {
        //                dict[n] = 0;
        //            }

        //            dict[n]++;
        //        }
        //    }

        //    return counter;
        //}
    }
}
