using System;

namespace UraApp.Repository.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        DatabaseContext Get();
    }
}