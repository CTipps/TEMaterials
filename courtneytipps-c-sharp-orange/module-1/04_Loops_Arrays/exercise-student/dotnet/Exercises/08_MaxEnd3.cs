namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given an array of ints length 3, figure out which is larger between the first and last elements
         in the array, and set all the other elements to be that value. Return the changed array.
         MaxEnd3([1, 2, 3]) → [3, 3, 3]
         MaxEnd3([11, 5, 9]) → [11, 11, 11]
         MaxEnd3([2, 11, 3]) → [3, 3, 3]
         */
        public int[] MaxEnd3(int[] nums)
        {
            int[] maxEnd = new int[3];
                if (nums[0] > nums[2])
                {
                    maxEnd[0] = nums[0];
                    maxEnd[1] = nums[0];
                    maxEnd[2] = nums[0];
                }
                if (nums[0] < nums[2])
                {
                    maxEnd[0] = nums[2];
                    maxEnd[1] = nums[2];
                    maxEnd[2] = nums[2];
                }
            return maxEnd;
        }
    }
}
