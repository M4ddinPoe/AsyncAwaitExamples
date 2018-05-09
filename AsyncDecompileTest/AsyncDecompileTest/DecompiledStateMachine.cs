namespace AsyncDecompileTest
{
  using System;
  using System.Diagnostics;
  using System.Runtime.CompilerServices;
  using System.Threading.Tasks;

  public class DecompiledStateMachine
  {
    public Task<int> MyMethodAsync(int parameter)
    {
      DecompiledStateMachine.MyMethodAsyncStateMachine d__ = new DecompiledStateMachine.MyMethodAsyncStateMachine();
      d__.__this = this;
      d__.parameter = parameter;
      d__.__builder = AsyncTaskMethodBuilder<int>.Create();
      d__.__state = -1;

      AsyncTaskMethodBuilder<int> t__builder = d__.__builder;

      t__builder.Start<DecompiledStateMachine.MyMethodAsyncStateMachine>(ref d__);
      return d__.__builder.Task;
    }

    private async Task<int> Delay(int parameter)
    {
      await Task.Delay(parameter);
      return parameter;
    }

    private sealed class MyMethodAsyncStateMachine : IAsyncStateMachine
    {
      public int __state;

      public AsyncTaskMethodBuilder<int> __builder;

      public int parameter;

      public DecompiledStateMachine __this;

      private int __result;

      private int __result2;

      private TaskAwaiter<int> __taskAwaiter;

      void IAsyncStateMachine.MoveNext()
      {
        int num = this.__state;
        int result2;
        try
        {
          TaskAwaiter<int> taskAwaiter;
          if (num != 0)
          {
            //taskAwaiter = Task.FromResult<int>(this.parameter + 1).GetAwaiter();
            taskAwaiter = this.__this.Delay(this.parameter).GetAwaiter();

            if (!taskAwaiter.IsCompleted)
            {
              this.__state = 0;
              this.__taskAwaiter = taskAwaiter;
              DecompiledStateMachine.MyMethodAsyncStateMachine d__ = this;
              this.__builder.AwaitUnsafeOnCompleted
                <TaskAwaiter<int>, DecompiledStateMachine.MyMethodAsyncStateMachine>(ref taskAwaiter, ref d__);
              return;
            }
          }
          else
          {
            taskAwaiter = this.__taskAwaiter;
            this.__taskAwaiter = default(TaskAwaiter<int>);
            this.__state = -1;
          }
          int result = taskAwaiter.GetResult();
          taskAwaiter = default(TaskAwaiter<int>);
          this.__result2 = result;
          this.__result = this.__state;
          result2 = this.__result;
        }
        catch (Exception exception)
        {
          this.__state = -2;
          this.__builder.SetException(exception);
          return;
        }
        this.__state = -2;
        this.__builder.SetResult(result2);
      }

      [DebuggerHidden]
      void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
      {
      }
    }
  }
}
