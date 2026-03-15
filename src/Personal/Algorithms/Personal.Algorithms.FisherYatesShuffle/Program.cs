namespace Personal.Algorithms.FisherYatesShuffle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PlayWithFisherYatesShuffle();
        }

        /// <summary>
        /// Implementation of the Fisher–Yates shuffle (also called the Knuth shuffle).
        /// </summary>
        private static void PlayWithFisherYatesShuffle()
        {
            var random = Random.Shared;

            var myNums = new int[] { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine(string.Join(", ", myNums));

            // Start from the last position of the array and move left with each loop.
            for (int i = myNums.Length - 1; i > 0; i--)
            {
                // Choose an index from 0 to the current position within the array.
                var index = random.Next(0, i + 1);

                // SWAP OPTION 1:
                var temp = myNums[i];
                // Swap the value of the current position with the randomly chosen position from 0 to the current one.
                myNums[i] = myNums[index];
                myNums[index] = temp;

                // SWAP OPTION 2, MORE MODERN:
                // (myNums[i], myNums[index]) = (myNums[index], myNums[i]);
            }

            Console.WriteLine(string.Join(", ", myNums));
        }
    }
}
