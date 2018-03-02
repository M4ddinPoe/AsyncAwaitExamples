namespace AsyncDecompileTest
{
  using System;
  using System.Threading;

  class Program
  {
    static void Main(string[] args)
    {
      MyClass myClass = new MyClass();
      //var taskAwaiter = myClass.DoSomethingAsync(50000).GetAwaiter();

      //Console.WriteLine(taskAwaiter.GetResult());

      //Console.WriteLine($"Start on Thread: {Thread.CurrentThread.ManagedThreadId}");
      //myClass.ContinueWithTest().GetAwaiter();

      var task = myClass.WaitForTaskWithoutAsync();

      task.GetAwaiter();

      Console.ReadLine();
    }

    static void DebugDecompiledStateMachine()
    {
      var decompiledStateMachine = new DecompiledStateMachine();
      var result = decompiledStateMachine.MyMethodAsync(1).GetAwaiter().GetResult();

      Console.WriteLine($"Result: {result}");
    }
  }
}
