namespace SimpleCqrs.ConsoleApp.Demo.Services
{
    public class SampleService : ISampleService
    {
        public string GetData(int id)
        {
            return $"Handled SampleService synchronously with Id: {id}";
        }

        public async Task<string> GetDataAsync(int id)
        {
            await Task.Delay(10);
            return $"Handled SampleService synchronously with Id: {id}";
        }
    }
}
