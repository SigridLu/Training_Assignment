using System;
namespace HW5
{
    public class Q1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int[] res = new int[2];
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = nums.Length - 1; j > i; j--)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        res[0] = i;
                        res[1] = j;
                    }
                }
            }
            return res; ;
        }
    };

    public class Q9
    {
        public bool IsPalindrome(int x)
        {
            string s = Convert.ToString(x);
            int front = 0, back = s.Length - 1;

            while (front <= back)
            {
                if (s[front] != s[back])
                    return false;
                front++;
                back--;
            }
            return true;
        }
    };

    public class Q217
    {
        public bool ContainsDuplicate(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
                if (nums[i] == nums[i + 1])
                    return true;
            return false;
        }
    };

    public class Q412
    {
        public IList<string> FizzBuzz(int n)
        {
            IList<string> res = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 15 == 0)
                    res.Add("FizzBuzz");
                else if (i % 3 == 0)
                    res.Add("Fizz");
                else if (i % 5 == 0)
                    res.Add("Buzz");
                else
                    res.Add(Convert.ToString(i));
            }
            return res;
        }
    };
}

