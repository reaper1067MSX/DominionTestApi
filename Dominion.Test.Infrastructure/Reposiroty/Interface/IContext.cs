using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Dominion.Test.Infrastructure.Reposiroty.Interface
{
    public interface IContext<TContext>
    {
        IDbContextTransaction BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted);
        void Rollback();
        int Save();
        void Commit();
        void Dispose();
        void Reload(dynamic entity);
        TContext _context { get; }

        IEnterpriseRepository GetEnterpriseRepository { get; }
        IDealerRepository GetDealerRepository { get; }
    }
}
