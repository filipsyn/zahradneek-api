using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Contracts.v1.Responses;

namespace Zahradneek.Api.Services.NewsService;

public interface INewsService
{
    public Task<IEnumerable<NewsInfoResponse>> GetAllAsync();
    public Task<NewsInfoResponse> GetByIdAsync(int newsId);

    public Task CreateAsync(CreateNewsRequest request);

    public Task UpdateByIdAsync(UpdateNewsRequest request, int newsId);

    public Task DeleteByIdAsync(int newsId);
}