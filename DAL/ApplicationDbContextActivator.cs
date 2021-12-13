using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.DAL
{
    public partial class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _contextAccessor;

        [ActivatorUtilitiesConstructor]
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, 
            IHttpContextAccessor httpOptionsAccessor) : base(options)
        {
            _contextAccessor = httpOptionsAccessor;
        }
    }
}
