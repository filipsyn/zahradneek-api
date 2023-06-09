using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.NewsRepository;

public interface INewsRepository
{
    public Task<IEnumerable<News>> GetAllAsync();

    public Task<News?> GetByIdAsync(int newsId);

    public Task<bool> IsAuthor(int userId, int articleId);

    public Task CreateAsync(News news);

    public Task UpdateByIdAsync(News updatedNews, int newsId);

    public Task DeleteByIdAsync(int newsId);
}