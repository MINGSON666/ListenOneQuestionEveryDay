using System;
using System.Collections.Generic;
using System.IO;

namespace PhoneNumber
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
            File.WriteAllLines(@"C:\output.txt",result);
        }
    }

    public class Solution
    {
        public IList<string> Combinations(string digits)
        {
            var dict = new Dictionary<char, char[]>
            {
                {'2',new []{'a','b','c'} },
                {'3',new []{'d','e','f'} },
                {'4',new []{'g','h','i'} },
                {'5',new []{'j','k','l'} },
                {'6',new []{'m','n','o'} },
                {'7',new []{'p','q','r','s'} },
                {'8',new []{'t','u','v'} },
                {'9',new []{'w','x','y','z'} }
            };

            var result = new List<string>();
            if (string.IsNullOrEmpty(digits)) return result;
            var q = new Queue<string>();
            q.Enqueue(string.Empty);
            while (q.Count > 0)
            {
                var cur = q.Dequeue();
                if(cur.Length == digits.Length) result.Add(cur);
                else
                    foreach (var c in dict[digits[cur.Length]])// 长度对应电话号码索引，长度为0对应第一个电话号码
                    {
                        q.Enqueue(cur + c); 
                    }
            }

            return result;
        }
    }
}
