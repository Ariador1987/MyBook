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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _db;
        public AuthorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Author entity)
        {
            var objToCreate = await _db.Authors.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Author entity)
        {
            var objToRemove =  _db.Authors.Remove(entity);
            return await Save();
        }

        public async Task<Author> FindById(int id)
        {
            var obj = await _db.Authors.FindAsync(id);
            return obj;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            var objList = await _db.Authors.ToListAsync();
            return objList;
        }

        public async Task<bool> isExsists(int id)
        {
            return await _db.Authors.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Author entity)
        {
            _db.Authors.Update(entity);
            return await Save();
        }
    }
}
