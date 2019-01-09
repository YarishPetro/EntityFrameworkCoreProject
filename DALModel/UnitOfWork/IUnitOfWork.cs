using System;
using System.Collections.Generic;
using System.Text;

namespace DALModel
{
    interface IUnitOfWork : IDisposable
    {
        GenericRepository<Players> PlayersRepository { get; }
        GenericRepository<Teams> TeamsRepository { get; }

    }
}
