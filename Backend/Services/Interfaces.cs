namespace Backend.Services;

public interface IReadService<TResponse> 
    where TResponse : class
{
    public Task<TResponse?> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    public IAsyncEnumerable<TResponse> GetAsync(
        Func<TResponse, bool> filter,
        CancellationToken cancellationToken);
}

public interface IWriteService<TRequest> 
    where TRequest : class
{
    public Task<int> CreateAsync(TRequest request, CancellationToken cancellationToken);
    
    public Task UpdateAsync(int id, TRequest request, CancellationToken cancellationToken);
    
    public Task DeleteAsync(int id, CancellationToken cancellationToken);
}

public interface IWebService<TRequest, TResponse> 
    : IReadService<TResponse>, IWriteService<TRequest> 
    where TRequest : class 
    where TResponse : class;

internal static class Extensions
{
    public static async Task<IEnumerable<T>> AsEnumerable<T>(this IAsyncEnumerable<T> value)
    {
        List<T> result = [];
        
        await foreach (var item in value)
        {
            result.Add(item);
        }

        return result;
    }
} 