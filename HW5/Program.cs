using System;
using System.Numerics;

namespace HW5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Q1 Input
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            Q1 q1 = new Q1();
            int[] res1 = q1.TwoSum(nums, target);

            // Q1 Output
            Console.WriteLine("Q1 Result:");
            foreach (int i in res1)
                Console.WriteLine(i);

            /********************************/

            // Q9 Input
            int x = 121;

            Q9 q9 = new Q9();

            // Q9 Output
            Console.WriteLine($"Q9 Result: {q9.IsPalindrome(x)}");

            /********************************/

            // Q217 Input
            int[] nums2 = { 1, 2, 3, 1 };

            Q217 q217 = new Q217();

            // Q217 Output
            Console.WriteLine($"Q217 Result: {q217.ContainsDuplicate(nums2)}");

            /********************************/

            // Q412 Input
            int n = 5;

            IList<string> res412 = new List<string>();
            Q412 q412 = new Q412();
            res412 = q412.FizzBuzz(n);

            // Q412 Output
            Console.WriteLine("Q412 Result:");
            foreach (string s in res412)
                Console.Write(s + ", ");

            Console.ReadLine();
        }
    }
}