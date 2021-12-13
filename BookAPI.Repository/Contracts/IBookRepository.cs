using BookAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Repository.Contracts
{
    public interface IBookRepository : IRepository<Book>
    {

    }
}
