using BookAPI.DAL;
using BookAPI.Domain.Models;
using BookAPI.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Repository.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Book entity)
        {
            var objToCreate = await _db.Books.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Book entity)
        {
            var objToRemove = _db.Books.Remove(entity);
            return await Save();
        }

        public async Task<Book> FindById(int id)
        {
            var obj = await _db.Books.FindAsync(id);
            return obj;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var objList = await _db.Books.ToListAsync();
            return objList;
        }

        public async Task<bool> isExsists(int id)
        {
            return await _db.Books.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Book entity)
        {
            _db.Books.Update(entity);
            return await Save();
        }
    }
}
