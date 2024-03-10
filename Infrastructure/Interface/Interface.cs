namespace Infrastructure.Interface;

public interface Interface<T>
{
    public Task<List<T>> GetValues();
    public Task<string> AddValues(T value);
    public Task<string> UpdateValues(T value);
    public Task<string> DeleteValues(int id);
}