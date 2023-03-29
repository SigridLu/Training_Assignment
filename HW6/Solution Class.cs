using System;
namespace HW6
{
    public class Q15
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var res = new List<IList<int>>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int low = i + 1, high = nums.Length - 1;
                while (low < high)
                {
                    if (nums[i] + nums[low] + nums[high] < 0)
                        low++;
                    else if (nums[i] + nums[low] + nums[high] > 0)
                        high--;
                    else
                    {
                        var ans_set = new List<int>() { nums[i], nums[low], nums[high] };
                        res.Add(ans_set);
                        low++;
                        high--;
                        while (low < high && nums[low] == nums[low - 1]) low++;
                        while (low < high && nums[high] == nums[high + 1]) high--;
                    }
                }
            }

            return res;
        }
    };
}

