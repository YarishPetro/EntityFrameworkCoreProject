using System;
using System.Collections.Generic;
using System.Text;

namespace DALModel
{
    public class UnitOfWork : IUnitOfWork
    {
        private TeamDBContext context = new TeamDBContext();

        private GenericRepository<Players> playersRepository;
        private GenericRepository<Teams> teamsRepository;

        public GenericRepository<Players> PlayersRepository
        {
            get
            {
                if (playersRepository == null)
                {
                    this.playersRepository = new GenericRepository<Players>(context);
                }

                return playersRepository;
            }
        }

        public GenericRepository<Teams> TeamsRepository
        {
            get
            {
                if (teamsRepository == null)
                {
                    teamsRepository = new GenericRepository<Teams>(context);
                }

                return teamsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
