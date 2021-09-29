using Dominion.Test.Infrastructure.Reposiroty.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Dominion.Test.Infrastructure.Reposiroty.Service
{
    public class Context : IContext<DominionContext>
    {
        public DominionContext _context { get; }

        public Context(DominionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException($"The context is null");
            }
            _context = context;
        }

        #region Methods for unit of work
        
        public IDbContextTransaction BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            return _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _context.Database.CurrentTransaction?.Rollback();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Commit()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                using (_context)
                {
                }
            }

            GC.SuppressFinalize(this);
        }

        public void Reload(dynamic entity)
        {
            _context.Entry(entity).Reload();
        }


        #endregion

        #region <<<<< Respositories >>>>>

        private EnterpriseRepository enterpriseRepository;
        private DealerRepository dealerRepository;

        public IEnterpriseRepository GetEnterpriseRepository
            => enterpriseRepository ??= new EnterpriseRepository(_context);

        public IDealerRepository GetDealerRepository
            => dealerRepository ??= new DealerRepository(_context);

        #endregion

    }
}
