using BlazorApp.Components.Account.Pages;
using BlazorApp.Data;
using BlazorApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Services
{

    public class BlogService
    {
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Blog>> GetAllBlogs()
        {
            return await _context.Blogs.AsNoTracking().ToListAsync();
        }

        public async Task<List<Blog>> GetAllBlogsByID(string userId) 
        {
            return await _context.Blogs.Where(b => b.UserId == userId).ToListAsync();
        }

        public async Task<Blog>? GetBlogByID(long id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null) {
                throw new Exception("Can't find any blog with id");
            }
            return blog;
        }

        public async Task UpdateBlogByID(Blog blog, long id)
        {
            var OldBlog = await _context.Blogs.SingleAsync(b => b.Id == id);
            OldBlog = blog;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBlogByID(long id)
        {
            var blog = await _context.Blogs.SingleAsync(b => b.Id == id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }
    }
}
