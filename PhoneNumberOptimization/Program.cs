using System;
using System.Collections.Generic;
using System.IO;

namespace PhoneNumberOptimization
{
    /// <summary>
    /// 数字键字母组合，数字2到9分别对应26个英文字母
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var phoneNumber = "45683926";
            var solution = new Solution();
            var result = solution.Combinations(phoneNumber);
            File.WriteAllLines(@"C:\output.txt", result);
        }
    }

    public class Solution
    {
        public IList<string> Combinations(string digits)
        {
            string[] dict = {null, null, "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};

            var result = new List<string>();
            if (string.IsNullOrEmpty(digits)) return result;
            var q = new Queue<string>();
            q.Enqueue(string.Empty);
            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                if (cur.Length == digits.Length) result.Add(cur);
                else
                    foreach (var c in dict[digits[cur.Length] - '0'])// 字符转数字，'2'->2
                    {
                        q.Enqueue(cur + c);
                    }
            }

            return result;
        }
    }
}
