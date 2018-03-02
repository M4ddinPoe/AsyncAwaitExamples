namespace AsyncDecompileTest
{
  using System.Threading;
  using System.Threading.Tasks;

  public class MyClass
  {
    public int X;

    //public async Task<int> DoSomethingAsync(int parameter)
    //{
    //  Console.WriteLine($"Entered DoSomethingAsync with parameter: '{parameter}'");
    //  var result = await MyMethodAsync(parameter);

    //  Console.WriteLine($"result from parameter: '{parameter}' = {result}");
    //  return result;
    //}

    //public async Task ContinueWithTest()
    //{
    //  Console.WriteLine($"Entered ContinueWithTest on Thread: {Thread.CurrentThread.ManagedThreadId}");

    //  await this.DoSomethingAsync(123).ContinueWith(
    //    task =>
    //      {
    //        Console.WriteLine($"Entered ContinueWithTest.ContinueWith on Thread: {Thread.CurrentThread.ManagedThreadId}");
    //        Console.WriteLine(task.Status);

    //        throw new Exception("Got me?");
    //      });
    //}

    public async Task WaitForTaskWithoutAsync()
    {
      await this.PassAsyncStuffWithoutAsync();
    }

    public Task PassAsyncStuffWithoutAsync()
    {
      Thread.Sleep(5000);

      return this.DoAsyncStuffWithoutAsync();
    }

    public Task DoAsyncStuffWithoutAsync()
    {
      return Task.Run(() => Thread.Sleep(2000));
    }

    public void FireAndForget()
    {
      this.DoFireAndForgetAsync();
    }

    public async Task DoFireAndForgetAsync()
    {
      int x = 123;

      await Task.Delay(1000);

      this.X = x + x;
    }

    //public async Task<int> DoSomethingMoreAsync(int parameter)
    //{
    //  int x = parameter;
    //  x = x + 1;

    //  var result = await MyMethodAsync(parameter);

    //  x = x + 2;

    //  return result + x;
    //}

    //public static async Task<int> MyMethodAsync(int parameter)
    //{
    //  parameter = parameter + 1;
    //  var result = await Task.FromResult(parameter);

    //  Console.WriteLine($"result from parameter: '{parameter}' = {result}");

    //  return result;
    //}
  }
}
