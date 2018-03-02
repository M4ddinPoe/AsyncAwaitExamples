namespace AsyncVoidException
{
  using System;

  class Program
  {
    static void Main(string[] args)
    {
      DoSomething();

      Console.WriteLine("Completed!");
      Console.ReadLine();
    }

    static async void DoSomething()
    {
      try
      {
        ThrowException();
      }
      catch (Exception exception)
      {
        // The exception is never caught here!
        Console.WriteLine(exception);
      }
    }

    static async void ThrowException()
    {
      throw new Exception("Got me!!!");
    }
  }
}
