using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Diagnostics;

namespace M4.DataAccess.UnitOfWork.EFCore
{
    public class FakeTransaction : IDbContextTransaction
    {
        public Guid TransactionId => Guid.NewGuid();

        public void Commit()
        {
            Debug.WriteLine("FakeTransaction - Commit");
        }

        public void Dispose()
        {
            Debug.WriteLine("FakeTransaction - Dispose");
        }

        public void Rollback()
        {
            Debug.WriteLine("FakeTransaction - Rollback");
        }
    }
}