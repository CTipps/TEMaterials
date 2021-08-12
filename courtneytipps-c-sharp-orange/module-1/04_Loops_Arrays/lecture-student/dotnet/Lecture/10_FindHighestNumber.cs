namespace Lecture
{
    public partial class LectureProblem
    {
        /*
        10. What code do we need to write so that we can find the highest
             number in the array randomNumbers?
             TOPIC: Looping Through Arrays
        */
        public int FindTheHighestNumber(int[] randomNumbers)

        {
            int max = 0;
            for (int i = 1; i < randomNumbers.Length - 1; i++)
            {
                if (randomNumbers[i] > randomNumbers[i + 1] && randomNumbers[i] > randomNumbers[i - 1])
                {
                    max = randomNumbers[i];
                }
            }
            return max;
        }
    }
}
