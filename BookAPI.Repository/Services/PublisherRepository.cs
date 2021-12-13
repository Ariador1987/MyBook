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
    public class PublisherRepository : IPublisherRepository
    {
        private readonly ApplicationDbContext _db;
        public PublisherRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Publisher entity)
        {
            var objToCreate = await _db.Publishers.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Publisher entity)
        {
            var objToRemove = _db.Publishers.Remove(entity);
            return await Save();
        }

        public async Task<Publisher> FindById(int id)
        {
            var obj = await _db.Publishers.FindAsync(id);
            return obj;
        }

        public async Task<IEnumerable<Publisher>> GetAll()
        {
            var objList = await _db.Publishers.ToListAsync();
            return objList;
        }

        public async Task<bool> isExsists(int id)
        {
            return await _db.Publishers.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Publisher entity)
        {
            _db.Publishers.Update(entity);
            return await Save();
        }
    }
}
