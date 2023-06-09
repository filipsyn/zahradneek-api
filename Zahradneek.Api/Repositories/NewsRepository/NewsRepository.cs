using System.Xml;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zahradneek.Api.Data;
using Zahradneek.Api.Exceptions;
using Zahradneek.Api.Models;

namespace Zahradneek.Api.Repositories.NewsRepository;

public class NewsRepository : INewsRepository
{
    private readonly DataContext _db;
    private readonly IMapper _mapper;

    public NewsRepository(DataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<News>> GetAllAsync()
        => await _db.News
            .Include(x => x.Author)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

    public async Task<News?> GetByIdAsync(int newsId) =>
        await _db.News
            .Include(x => x.Author)
            .Where(n => n.Id == newsId)
            .FirstOrDefaultAsync();

    public async Task<bool> IsAuthor(int userId, int articleId)
    {
        var article = await GetByIdAsync(articleId);
        if (article is null)
            throw new NotFoundException("News article was not found");

        return article.AuthorId == userId;
    }

    public async Task CreateAsync(News news)
    {
        _db.News.Add(news);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateByIdAsync(News updatedNews, int newsId)
    {
        var news = await this.GetByIdAsync(newsId);
        if (news is null)
            throw new NotFoundException("News article was not found");

        _mapper.Map(updatedNews, news);
        news.AuthorId = updatedNews.AuthorId;

        _db.News.Update(news);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int newsId)
    {
        var foundNews = await this.GetByIdAsync(newsId);
        if (foundNews is null)
            throw new NotFoundException("News article was not found");

        _db.News.Remove(foundNews);
        await _db.SaveChangesAsync();
    }
}