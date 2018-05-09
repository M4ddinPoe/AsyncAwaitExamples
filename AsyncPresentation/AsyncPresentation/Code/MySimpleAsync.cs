namespace AsyncPresentation.Code
{
    using System.Threading.Tasks;

    public class MySimpleAsync
    {
        public async Task<int> DoSomethingAsync(int parameter)
        {
            var result = await this.MyMethodAsync(parameter);
            return result;
        }

        private async Task<int> MyMethodAsync(int parameter)
        {
            return await Task.FromResult(parameter + 1).ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
