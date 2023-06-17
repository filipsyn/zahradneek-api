using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.NewsRepository;

public interface INewsRepository
{
    public Task<IEnumerable<News>> GetAllAsync();

    public Task<News?> GetById(int newsId);

    public Task CreateAsync(News news);

    public Task UpdateByIdAsync(News news, int newsId);

    public Task DeleteByIdAsync(int newsId);
}