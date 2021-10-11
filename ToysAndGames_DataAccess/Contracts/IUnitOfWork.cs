using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGames_DataAccess.Repository;
using ToysAndGames_Models.Models;

namespace ToysAndGames_DataAccess.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> ProductRepository { get; }
        Task Save();
    }
}
