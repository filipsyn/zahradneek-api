using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zahradneek.Api.Contracts.v1.Requests;
using Zahradneek.Api.Contracts.v1.Responses;
using Zahradneek.Api.Exceptions;
using Zahradneek.Api.Models;
using Zahradneek.Api.Repositories.NewsRepository;

namespace Zahradneek.Api.Services.NewsService;

public class NewsService : INewsService
{
    private readonly INewsRepository _newsRepository;
    private readonly IMapper _mapper;

    public NewsService(INewsRepository newsRepository, IMapper mapper)
    {
        _newsRepository = newsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NewsInfoResponse>> GetAllAsync()
    {
        var newsList = await _newsRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<NewsInfoResponse>>(newsList);
    }

    public async Task<NewsInfoResponse> GetByIdAsync(int newsId)
    {
        var article = await _newsRepository.GetByIdAsync(newsId);
        if (article is null)
            throw new NotFoundException("News article was not found");

        return _mapper.Map<NewsInfoResponse>(article);
    }

    public async Task CreateAsync(CreateNewsRequest request)
    {
        var article = _mapper.Map<News>(request);

        try
        {
            await _newsRepository.CreateAsync(article);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }

    public async Task UpdateByIdAsync(UpdateNewsRequest request, int newsId)
    {
        var article = await _newsRepository.GetByIdAsync(newsId);
        if (article is null)
            throw new NotFoundException("News article was not found");

        var updatedArticle = _mapper.Map<News>(request);

        try
        {
            await _newsRepository.UpdateByIdAsync(updatedNews: updatedArticle, newsId: newsId);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }

    public async Task DeleteByIdAsync(int newsId)
    {
        var article = await _newsRepository.GetByIdAsync(newsId);
        if (article is null)
            throw new NotFoundException("News article was not found");

        try
        {
            await _newsRepository.DeleteByIdAsync(newsId);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DbConflictException();
        }
    }
}