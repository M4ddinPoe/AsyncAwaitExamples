namespace AysncBlock
{
  using System;
  using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            // Start the delay.
            var delayTask = DelayAsync();
            // Wait for the delay to complete.
            delayTask.Wait();

            Console.WriteLine("Completed!");
            Console.ReadLine();
        }

        private static async Task DelayAsync()
        {
            await Task.Delay(1000);
        }
    }
}
