namespace AsyncPresentation.Code
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class MySimpleAsyncDecompiled
    {
        [DebuggerStepThrough]
        [AsyncStateMachine(typeof(DoSomethingAsyncStateMachine))]
        public Task<int> DoSomethingAsync(int parameter)
        {
            DoSomethingAsyncStateMachine methodAsyncStateMachine = new DoSomethingAsyncStateMachine()
            {
                __parameter = parameter,
                __this = this,
                __builder = AsyncTaskMethodBuilder<int>.Create(),
                __state = -1
            };

            methodAsyncStateMachine.__builder.Start(ref methodAsyncStateMachine);
            return methodAsyncStateMachine.__builder.Task;
        }

        private async Task<int> MyMethodAsync(int parameter)
        {
            return await Task.FromResult(parameter + 1);
        }

        private int SomeSynchronousMethod(int parameter)
        {
            return parameter + 1;
        }

        public sealed class DoSomethingAsyncStateMachine : IAsyncStateMachine
        {
            public AsyncTaskMethodBuilder<int> __builder;
            public int __state;
            public MySimpleAsyncDecompiled __this;
            public int __parameter;
            private TaskAwaiter<int> __taskAwaiter;
            private int __result;

            void IAsyncStateMachine.MoveNext()
            {
                try
                {
                    TaskAwaiter<int> taskAwaiter;

                    // Wenn im initialen Status
                    if (this.__state != 0)
                    {
                        // Ausführen des synchronen Codes vor dem ersten await
                        this.__result = this.__this.SomeSynchronousMethod(this.__parameter);

                        taskAwaiter = this.__this.MyMethodAsync(this.__parameter).GetAwaiter();

                        // Wenn der Task schon fertig; bleiben wir synchrn und geben das Result zurück
                        // Ansonsten machen wir in dem folgenden block weiter
                        if (!taskAwaiter.IsCompleted)
                        {
                            this.__state = 0;
                            this.__taskAwaiter = taskAwaiter;
                            DoSomethingAsyncStateMachine stateMachine = this;

                            this.__builder
                              .AwaitUnsafeOnCompleted(ref taskAwaiter, ref stateMachine);

                            return;
                        }
                    }

                    // Für weitere async Methoden werden hier weitere States definiert. Die States werden dann positiv hochgezählt

                    // Hier wird das Result aus dem Task geholt, der State auf completed gesetzt und das Result zurück gegeben
                    this.__result = this.__taskAwaiter.GetResult();
                    this.__state = -2;
                    this.__builder.SetResult(__result);
                }
                catch (Exception exception)
                {
                    // Exceptions werden hier gefangen und über den Builder an den aufrufer weiter gegeben
                    this.__state = -2;
                    this.__builder.SetException(exception);
                }
            }

            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

    }
}
