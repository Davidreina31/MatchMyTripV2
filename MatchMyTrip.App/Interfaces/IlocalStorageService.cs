namespace MatchMyTrip.App.Interfaces
{
    public interface IlocalStorageService
    {
        Task<T> GetItem<T>(string key);
        Task SetItem<T>(string key, T value);
        Task RemoveItem(string key);
    }
}
