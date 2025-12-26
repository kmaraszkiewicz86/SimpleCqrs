
namespace SimpleCqrs.ConsoleApp.Demo.Services
{
    public interface ISampleService
    {
        string GetData(int id);

        Task<string> GetDataAsync(int id);
    }
}
