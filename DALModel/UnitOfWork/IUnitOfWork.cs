using System;
using System.Collections.Generic;
using System.Text;

namespace DALModel
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Players> PlayersRepository { get; }
        GenericRepository<Teams> TeamsRepository { get; }

        void Save();
    }
}
