using CompanyName.Entities.Data;
using System;

namespace CompanyName.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        ApplicationDbContext GetDbContext();
    }
}
